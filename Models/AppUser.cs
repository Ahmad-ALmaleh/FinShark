using Microsoft.AspNetCore.Identity;

namespace FINSHARK.Models
{
    public class AppUser : IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    }
}
