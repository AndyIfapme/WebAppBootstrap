using WebAppBootstrap.Domain.Common;

namespace WebAppBootstrap.Domain.Items;

public class Brand : Entity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<Item> Items { get; set; } = new HashSet<Item>();
}