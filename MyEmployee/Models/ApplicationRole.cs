using Microsoft.AspNetCore.Identity;

namespace MyEmployee.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string? Color { get; set; } = "#FFFFFF";
    }
}
