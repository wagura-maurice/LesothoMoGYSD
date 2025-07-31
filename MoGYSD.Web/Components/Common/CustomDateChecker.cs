using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Web.Components.Common
{
    public class CustomDateChecker : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public CustomDateChecker(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString ?? "End Date must be on or after the Start Date.";

            var currentValue = (DateTime?)value;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException($"Property with name {_comparisonProperty} not found.");
            }

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue == null || comparisonValue == null)
            {
                return ValidationResult.Success;
            }

            if (currentValue < comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
