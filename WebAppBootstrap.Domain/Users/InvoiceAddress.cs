using WebAppBootstrap.Domain.Common;

namespace WebAppBootstrap.Domain.Users;

public class InvoiceAddress : Entity
{
    public string Street { get; set; } = default!;
    public string StreetNumber { get; set; } = default!;

    public string PostalCode { get; set; } = default!;
    public string Locality { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;

    public User User { get; set; } = default!;
    public string UserId { get; set; } = default!;
}