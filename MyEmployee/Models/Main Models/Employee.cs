using System.ComponentModel.DataAnnotations;
using MyEmployee.Utilities;

namespace MyEmployee.Models.Main_Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string ProfilePicturePath { get; set; }
        [Required]
        [AgeLimit(maxyears: 120, minyears:16, ErrorMessage = "Enter your real age please")]
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        [Phone(ErrorMessage = "Enter your phone number here")]
        public string Phone { get; set; }
        public string? Description { get; set; }
        public decimal Salary { get; set; } = 0;
        [Required]
        [AgeLimit(maxyears:60, minyears:0, ErrorMessage = "Enter serious values please")]
        public DateOnly HireDate { get; set; }
        public string Profession { get; set; }
        public string EmploymentStatus { get; set; }

        [Required]
        public string ManagerId { get; set; }
        public ApplicationUser? Manager { get; set; }

        public List<EmployeeHistory> EmployeeHistory { get; set; }

    }
}
