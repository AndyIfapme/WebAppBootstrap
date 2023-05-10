using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppBootstrap.Infrastructure;

namespace WebAppBootstrap.Pages
{
    public class ItemModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ItemView? Item { get; set; }

        public ItemModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio#the-editcshtml-file
        public void OnGet(Guid id)
        {
            Item = _applicationDbContext.Item
                .Where(x => x.Id == id)
                .Select(item => new ItemView
                {
                    ItemId = item.Id,

                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    ImageUrl = item.ImageUrl,

                    BrandId = item.BrandId,
                    BrandName = item.Brand.Name
                })
                .SingleOrDefault();
        }

        public class ItemView
        {
            public Guid ItemId { get; set; }

            public string Name { get; set; } = default!;

            public string Description { get; set; } = default!;

            public double Price { get; set; }
            public string? ImageUrl { get; set; }


            public Guid BrandId { get; set; }

            public string BrandName { get; set; } = default!;
        }
    }
}
