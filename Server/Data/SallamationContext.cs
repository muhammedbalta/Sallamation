using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sallamation.Server.Data
{
    public class SallamationContext : IdentityDbContext<IdentityUser>
    {
        public SallamationContext(DbContextOptions options) : base(options)
        {
        }
    }

}