using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// View model for displaying benefit rule details.
    /// </summary>
    public class BenefitRuleViewModel:IValidatableObject
    {
        /// <summary>
        /// Unique identifier for the benefit rule.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the associated programme.
        /// </summary>     
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Name of the associated programme.
        /// </summary>    
        public string ProgrammeName { get; set; }

        /// <summary>
        /// Minimum number of household members eligible for the benefit.
        /// </summary>
        [Required(ErrorMessage = "Min HH Members is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum household members must be at least 1.")]
        public int? MinHHMembers { get; set; }

        /// <summary>
        /// Maximum number of household members eligible for the benefit.
        /// </summary>
        [Required(ErrorMessage = "Max HH Members is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Maximum household members must be at least 1.")]
        public int? MaxHHMembers { get; set; }

        /// <summary>
        /// Benefit amount.
        /// </summary>
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Indicates if the benefit rule is active.
        /// </summary>
        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {           
            if (MinHHMembers.HasValue && MaxHHMembers.HasValue)
            {
                if (MinHHMembers.Value > MaxHHMembers.Value)
                {
                    yield return new ValidationResult(
                        "Minimum household members cannot be greater than Maximum household members.",
                        new[] { nameof(MinHHMembers), nameof(MaxHHMembers) } 
                    );
                }
                if (MaxHHMembers.Value>30)
                {
                    yield return new ValidationResult(
                        "Maximum household members cannot exceed 30.",
                        new[] { nameof(MinHHMembers), nameof(MaxHHMembers) }
                    );
                }
            }
            
        }
    }
}