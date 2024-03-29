using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Models;

namespace MyEmployee.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<ApplicationRole> ApplicationRoles { get; set; }
    }
}
