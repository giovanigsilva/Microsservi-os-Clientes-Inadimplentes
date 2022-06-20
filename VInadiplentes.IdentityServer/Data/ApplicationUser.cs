using Microsoft.AspNetCore.Identity;

namespace VInadiplentes.IdentityServer.Data;

public class ApplicationUser: IdentityUser
{
    public String FirstName { get; set; } = String.Empty;
    public String LastName { get; set; } = String.Empty;
}
