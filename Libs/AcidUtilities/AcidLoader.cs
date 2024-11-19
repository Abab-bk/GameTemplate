using System;
using Godot;
using Array = Godot.Collections.Array;

namespace AcidUtilities;

public class AcidLoader(string[] paths, AcidLoader.LoadMode loadMode = AcidLoader.LoadMode.Godot)
{
    public event Action<float> OnProgressChanged;
    public event Action<string> OnResourceLoad;
    public event Action<string, Resource> OnResourceLoaded; 
    public event Action OnAllLoaded;
    
    public enum LoadMode
    {
        Godot,
        CSharp
    }
    
    public void LoadResources()
    {
        switch (loadMode)
        {
            case LoadMode.Godot:
                LoadGodotResources();
                break;
            case LoadMode.CSharp:
                LoadCSharpResources();
                break;
        }
    }

    private void LoadCSharpResources()
    {
    }

    private void LoadGodotResources()
    {
        foreach (var path in paths)
        {
            ResourceLoader.LoadThreadedRequest(path);
            
            OnResourceLoad?.Invoke(path);
            Array progress = [];

            while (true)
            {
                var loadStatus = ResourceLoader.LoadThreadedGetStatus(path, progress);
                switch (loadStatus)
                {
                    case ResourceLoader.ThreadLoadStatus.Loaded:
                        OnProgressChanged?.Invoke((float)progress[0]);
                        break;
                    case ResourceLoader.ThreadLoadStatus.InProgress:
                        OnProgressChanged?.Invoke((float)progress[0]);
                        continue;
                    case ResourceLoader.ThreadLoadStatus.Failed:
                        break;
                    case ResourceLoader.ThreadLoadStatus.InvalidResource:
                        break;
                }
                break;
            }
            
            OnResourceLoaded?.Invoke(path, ResourceLoader.LoadThreadedGet(path));
        }
        
        OnAllLoaded?.Invoke();
    }
}