using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyEmployee.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Color { get; set; } = "#FFFFFF";
    }
}
