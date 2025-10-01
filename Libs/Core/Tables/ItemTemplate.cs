using Core.Items;
using MasterMemory;
using MessagePack;
using VYaml.Annotations;

namespace Core.Tables;

[YamlObject]
[MemoryTable("ItemTemplates")]
[MessagePackObject(true)]
public partial record ItemTemplate
{
    [PrimaryKey] public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Desc { get; set; }
    public required ItemType ItemType { get; set; }
    public int MaxStack { get; set; } = int.MaxValue;
}