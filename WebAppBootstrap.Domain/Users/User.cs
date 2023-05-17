using Microsoft.AspNetCore.Identity;

namespace WebAppBootstrap.Domain.Users;

public class User : IdentityUser
{
    public InvoiceAddress? InvoiceAddress { get; set; }
}