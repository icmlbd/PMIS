using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace PMIS.WebApp.ValidationAttributes
{
    public class AgeAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string ErrorMessage { get; set; }
        public AgeAttribute(int minAge, int maxAge)
        {
            MinAge = minAge;
            MaxAge = maxAge;

        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult("Min Age is not provided!");
            }

            if ((int)value < MinAge || (int)value > MaxAge)
            {
                string errorMessage = ErrorMessage;
                if (string.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "Age requirement is: Min Age: " + MinAge + " and Max Age: " + MaxAge;
                }
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;

        }
    }
}
