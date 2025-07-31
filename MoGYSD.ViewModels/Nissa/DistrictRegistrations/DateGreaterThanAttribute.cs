namespace MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Custom validation attribute to ensure one date is greater than another
/// </summary>
public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var currentValue = value as DateTime?;

        // Get the comparison property
        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
        {
            return new ValidationResult($"Unknown property: {_comparisonProperty}");
        }

        var comparisonValue = property.GetValue(validationContext.ObjectInstance) as DateTime?;

        // Skip validation until both values are set
        if (!currentValue.HasValue || !comparisonValue.HasValue)
        {
            return ValidationResult.Success;
        }

        // Perform the comparison
        if (currentValue <= comparisonValue)
        {
            return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be greater than {_comparisonProperty}.");
        }

        return ValidationResult.Success;
    }
}
/// <summary>
/// Custom validation attribute to ensure date is not in the past
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue)
        {
            if (dateValue.Date < DateTime.Today)
            {
                return new ValidationResult(ErrorMessage ?? "Date cannot be in the past");
            }
        }
        return ValidationResult.Success;
    }
}