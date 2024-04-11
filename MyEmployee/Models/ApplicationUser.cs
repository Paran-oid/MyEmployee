using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Evaluation;
using MyEmployee.Models.Main_Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyEmployee.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
