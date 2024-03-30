using FluentValidation;
using MyEmployee.Data;
using System.ComponentModel.DataAnnotations;

namespace MyEmployee.Models.Admin_Management
{
    public class ApplicationUserEditADMIN : ApplicationUser
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Must be between 3 and 50 characters")]
        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be between 3 and 50 characters")]
        public string? LastName { get; set; }

        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
