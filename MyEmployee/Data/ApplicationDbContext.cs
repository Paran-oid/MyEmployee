using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEmployee.Models;
using MyEmployee.Models.Admin_Management;


namespace MyEmployee.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationLog> ApplicationLogs { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           //ROLES
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole {Id = "1", Name = "Manager", Color = "#88b892", NormalizedName = "MANAGER", }
                );

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "2", Name = "Admin", Color = "#72b5a8", NormalizedName = "ADMIN", }
            );

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "3", Name = "User", Color = "#86918f", NormalizedName = "USER", }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
