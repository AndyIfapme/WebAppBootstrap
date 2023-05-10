using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppBootstrap.Domain.Items;

namespace WebAppBootstrap.Pages.Admins.Brands
{
    public class CreateModel : PageModel
    {
        private readonly Infrastructure.ApplicationDbContext _context;

        public CreateModel(Infrastructure.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BrandView Brand { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Brand.Add(new Brand
            {
                Name = Brand.Name,
                Description = Brand.Description
            });

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        public class BrandView
        {
            [Required(ErrorMessage = "Le nom de la marque est obligatoire"), MaxLength(64)]
            public string Name { get; set; } = default!;

            [MaxLength(256)]
            public string? Description { get; set; }
        }
    }
}
