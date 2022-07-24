using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sallamation.Server.Models;

namespace Sallamation.Server.Data
{
    public class SallamationContext : DbContext
    {
        public SallamationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
    }
}