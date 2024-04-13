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
        [AgeLimit]
        public DateOnly DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Description { get; set; }
        public decimal Salary { get; set; } = 0;
        [WorkYears]
        public DateOnly HireDate { get; set; }
        public string Profession { get; set; }
        public string EmploymentStatus { get; set; }

        [Required]
        public string ManagerId { get; set; }
        [Required]
        public ApplicationUser Manager { get; set; }

        public sealed class AgeLimit : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                var datebirth = (DateOnly)value;
                var today = DateOnly.FromDateTime(DateTime.Today);
                var age = today.Year - datebirth.Year;

                if (age > 100 || age < 16)
                {
                    return new ValidationResult("Age must be between 16 and 100");
                }
                return ValidationResult.Success;
            }
        }
        public sealed class WorkYears : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                var workYear = (DateOnly)value;
                var today = DateOnly.FromDateTime(DateTime.Today);
                var yearsWork = today.Year - workYear.Year;
                var MonthWork = today.Month - workYear.Month ;
                var DayWork = today.Day - workYear.Day;

                if (yearsWork < 0 || yearsWork > 80 || MonthWork < 0 || DayWork < 0 )
                {
                    return new ValidationResult("Please enter serious values");
                }
                return ValidationResult.Success;
            }
        }
    }
}