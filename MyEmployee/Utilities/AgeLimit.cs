using System.ComponentModel.DataAnnotations;

namespace MyEmployee.Utilities
{
    public sealed class AgeLimit : ValidationAttribute
    {
        private readonly int _maxyears;
        private readonly int _minyears;


        public AgeLimit(int maxyears, int minyears)
        {
            _maxyears = maxyears;
            _minyears = minyears;

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateOnly dateOfBirth)
            {
                return new ValidationResult("Invalid date of birth");
            }

            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - dateOfBirth.Year;

            if (age > _maxyears || age < _minyears)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
