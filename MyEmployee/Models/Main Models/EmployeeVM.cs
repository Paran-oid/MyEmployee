using System.ComponentModel.DataAnnotations;

namespace MyEmployee.Models.Main_Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public IFormFile ProfilePicture { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Description { get; set; }
        public double Salary { get; set; } = 0;
        public DateOnly HireDate { get; set; }
        public string Profession { get; set; }
        public string EmploymentStatus { get; set; }

        [Required]
        public string ManagerId { get; set; }
        [Required]
        public ApplicationUser Manager { get; set; }
    }
}