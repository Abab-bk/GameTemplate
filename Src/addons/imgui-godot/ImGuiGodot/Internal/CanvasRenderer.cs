#if GODOT_PC
using Godot;
using ImGuiNET;
using System;
using System.Collections.Generic;

namespace ImGuiGodot.Internal;

internal sealed class CanvasRenderer : IRenderer
{
    private sealed class ViewportData
    {
        public Rid Canvas { set; get; }
        public Rid RootCanvasItem { set; get; }
    }

    private readonly Dictionary<Rid, List<Rid>> _canvasItemPools = [];
    private readonly Dictionary<Rid, ViewportData> _vpData = [];

    public string Name => "godot4_net_canvas";

    public void InitViewport(Rid vprid)
    {
        var canvas = RenderingServer.CanvasCreate();
        var canvasItem = RenderingServer.CanvasItemCreate();
        RenderingServer.ViewportAttachCanvas(vprid, canvas);
        RenderingServer.CanvasItemSetParent(canvasItem, canvas);

        _vpData[vprid] = new ViewportData()
        {
            Canvas = canvas,
            RootCanvasItem = canvasItem
        };
    }

    public void Render()
    {
        var pio = ImGui.GetPlatformIO();
        for (var vpidx = 0; vpidx < pio.Viewports.Size; vpidx++)
        {
            var vp = pio.Viewports[vpidx];
            var vprid = Util.ConstructRid((ulong)vp.RendererUserData);

            RenderOne(vprid, vp.DrawData);
        }
    }

    private void RenderOne(Rid vprid, ImDrawDataPtr drawData)
    {
        var vd = _vpData[vprid];
        var parent = vd.RootCanvasItem;

        if (!_canvasItemPools.ContainsKey(parent))
            _canvasItemPools[parent] = [];

        var children = _canvasItemPools[parent];

        // allocate our CanvasItem pool as needed
        var neededNodes = 0;
        for (var i = 0; i < drawData.CmdLists.Size; ++i)
        {
            var cmdBuf = drawData.CmdLists[i].CmdBuffer;
            neededNodes += cmdBuf.Size;
            for (var j = 0; j < cmdBuf.Size; ++j)
                if (cmdBuf[j].ElemCount == 0)
                    --neededNodes;
        }

        while (children.Count < neededNodes)
        {
            var newChild = RenderingServer.CanvasItemCreate();
            RenderingServer.CanvasItemSetParent(newChild, parent);
            RenderingServer.CanvasItemSetDrawIndex(newChild, children.Count);
            children.Add(newChild);
        }

        // trim unused nodes
        while (children.Count > neededNodes)
        {
            var idx = children.Count - 1;
            RenderingServer.FreeRid(children[idx]);
            children.RemoveAt(idx);
        }

        // render
        drawData.ScaleClipRects(ImGui.GetIO().DisplayFramebufferScale);
        var nodeN = 0;

        for (var n = 0; n < drawData.CmdLists.Size; ++n)
        {
            var cmdList = drawData.CmdLists[n];

            var nVert = cmdList.VtxBuffer.Size;

            var vertices = new Vector2[nVert];
            var colors = new Color[nVert];
            var uvs = new Vector2[nVert];

            for (var i = 0; i < cmdList.VtxBuffer.Size; ++i)
            {
                var v = cmdList.VtxBuffer[i];
                vertices[i] = new Vector2(v.pos.X, v.pos.Y);
                // need to reverse the color bytes
                var rgba = v.col;
                var r = (rgba & 0xFFu) / 255f;
                rgba >>= 8;
                var g = (rgba & 0xFFu) / 255f;
                rgba >>= 8;
                var b = (rgba & 0xFFu) / 255f;
                rgba >>= 8;
                var a = (rgba & 0xFFu) / 255f;
                colors[i] = new Color(r, g, b, a);
                uvs[i] = new Vector2(v.uv.X, v.uv.Y);
            }

            for (var cmdi = 0; cmdi < cmdList.CmdBuffer.Size; ++cmdi)
            {
                var drawCmd = cmdList.CmdBuffer[cmdi];

                if (drawCmd.ElemCount == 0) continue;

                var indices = new int[drawCmd.ElemCount];
                var idxOffset = drawCmd.IdxOffset;
                for (uint i = idxOffset, j = 0; i < idxOffset + drawCmd.ElemCount; ++i, ++j)
                    indices[j] = cmdList.IdxBuffer[(int)i];

                var cmdvertices = vertices;
                var cmdcolors = colors;
                var cmduvs = uvs;
                if (drawCmd.VtxOffset > 0)
                {
                    // this implementation of RendererHasVtxOffset is awful,
                    // but we can't do much better without using RenderingDevice directly
                    var localSize = cmdList.VtxBuffer.Size - drawCmd.VtxOffset;
                    cmdvertices = new Vector2[localSize];
                    cmdcolors = new Color[localSize];
                    cmduvs = new Vector2[localSize];
                    Array.Copy(vertices, drawCmd.VtxOffset, cmdvertices, 0, localSize);
                    Array.Copy(colors, drawCmd.VtxOffset, cmdcolors, 0, localSize);
                    Array.Copy(uvs, drawCmd.VtxOffset, cmduvs, 0, localSize);
                }

                var child = children[nodeN++];

                var texrid = Util.ConstructRid((ulong)drawCmd.GetTexID());
                RenderingServer.CanvasItemClear(child);
                var xform = Transform2D.Identity;
                if (drawData.DisplayPos != System.Numerics.Vector2.Zero)
                    xform = xform.Translated(drawData.DisplayPos.ToVector2I()).Inverse();
                RenderingServer.CanvasItemSetTransform(child, xform);
                RenderingServer.CanvasItemSetClip(child, true);
                RenderingServer.CanvasItemSetCustomRect(child, true, new Rect2(
                    drawCmd.ClipRect.X,
                    drawCmd.ClipRect.Y,
                    drawCmd.ClipRect.Z - drawCmd.ClipRect.X,
                    drawCmd.ClipRect.W - drawCmd.ClipRect.Y)
                );

                RenderingServer.CanvasItemAddTriangleArray(
                    child,
                    indices,
                    cmdvertices,
                    cmdcolors,
                    cmduvs,
                    null,
                    null,
                    texrid,
                    -1);
            }
        }
    }

    public void CloseViewport(Rid vprid)
    {
        var vd = _vpData[vprid];
        ClearCanvasItems(vd.RootCanvasItem);
        RenderingServer.FreeRid(vd.RootCanvasItem);
        RenderingServer.FreeRid(vd.Canvas);
    }

    public void OnHide()
    {
        ClearCanvasItems();
    }

    public void Dispose()
    {
        ClearCanvasItems();
        foreach (var vd in _vpData.Values)
        {
            RenderingServer.FreeRid(vd.RootCanvasItem);
            RenderingServer.FreeRid(vd.Canvas);
        }
    }

    private void ClearCanvasItems(Rid rootci)
    {
        foreach (var ci in _canvasItemPools[rootci]) RenderingServer.FreeRid(ci);
    }

    private void ClearCanvasItems()
    {
        foreach (var parent in _canvasItemPools.Keys) ClearCanvasItems(parent);
        _canvasItemPools.Clear();
    }
}
#endif