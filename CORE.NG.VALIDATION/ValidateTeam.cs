using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.NG.VALIDATION
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ValidateTeam : ValidationAttribute
    {
        string startsWith = string.Empty;
 
        public ValidateTeam(string startswith)
        {
            this.startsWith = startswith;           
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!value.ToString().StartsWith(startsWith))
            {
                return new ValidationResult(base.ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
