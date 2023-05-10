using WebAppBootstrap.Domain.Common;

namespace WebAppBootstrap.Domain.Items;

public class Item : Entity
{
    public string Name { get; set; } = default!;
   
    public string Description { get; set; } = default!;

    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public Brand? Brand { get; set; }/* = default!;*/
    public Guid BrandId { get; set; }
}   