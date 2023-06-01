using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppBootstrap.Domain.Items;
using WebAppBootstrap.Infrastructure;

namespace WebAppBootstrap.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public List<ItemView> Items { get; set; }

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void OnGet()
        {
            Items = _applicationDbContext.Set<Item>()
                .Select(item => new ItemView
                {
                    ItemId = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    BrandName = item.Brand.Name
                })
                .ToList();
        }

        /*
        * dto (Data transfert object) permet de mettre le plus 'flat' possible les données pour le rendu HTML.
        * Le FE n'a pas besoin de savoir l'existence d'autres données que ceux qui doit utiliser
        * et évite d'avoir des structures trop complexe.
        */
        public class ItemView
        {
            public Guid ItemId { get; set; }
            public string Name { get; set; } = default!;
            public double Price { get; set; }

            public string BrandName { get; set; } = default!;
        }
    }
}