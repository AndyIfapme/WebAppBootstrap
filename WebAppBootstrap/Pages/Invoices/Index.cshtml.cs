using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppBootstrap.Domain.Users;
using WebAppBootstrap.Infrastructure;

namespace WebAppBootstrap.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public InvoiceAddressView InvoiceAddress { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return Redirect("/Identity/Account/Login");
            }

            InvoiceAddress = await _context.Set<InvoiceAddress>()
                .Where(x => x.UserId == user.Id)
                .Select(x => new InvoiceAddressView
                {
                    City = x.City,
                    Country = x.Country,
                    Locality = x.Locality,
                    PostalCode = x.PostalCode,
                    Street = x.Street,
                    StreetNumber = x.StreetNumber
                })
                .SingleOrDefaultAsync() ?? new InvoiceAddressView();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return Redirect("/Identity/Account/Login");
            }

            var invoiceAddress = await _context.Set<InvoiceAddress>()
                .SingleOrDefaultAsync(x => x.UserId == user.Id);

            if (invoiceAddress is not null)
            {
                //edition
                invoiceAddress.City = InvoiceAddress.City;
                invoiceAddress.Country = InvoiceAddress.Country;
                invoiceAddress.Locality = InvoiceAddress.Locality;
                invoiceAddress.PostalCode = InvoiceAddress.PostalCode;
                invoiceAddress.Street = InvoiceAddress.Street;
                invoiceAddress.StreetNumber = InvoiceAddress.StreetNumber;
            }
            else
            {
                await _context.InvoiceAddress.AddAsync(new InvoiceAddress
                {
                    City = InvoiceAddress.City,
                    Country = InvoiceAddress.Country,
                    Locality = InvoiceAddress.Locality,
                    PostalCode = InvoiceAddress.PostalCode,
                    Street = InvoiceAddress.Street,
                    StreetNumber = InvoiceAddress.StreetNumber,
                    User = user
                });
                //creation
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool InvoiceAddressExists(Guid id)
        {
            return _context.InvoiceAddress.Any(e => e.Id == id);
        }

        public class InvoiceAddressView
        {
            [Required, MaxLength(255)]
            public string Street { get; set; } = default!;
            public string StreetNumber { get; set; } = default!;

            public string PostalCode { get; set; } = default!;
            public string Locality { get; set; } = default!;
            public string City { get; set; } = default!;
            public string Country { get; set; } = default!;
        }
    }
}
