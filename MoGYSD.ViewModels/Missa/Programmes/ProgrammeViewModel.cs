using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// View model for displaying and editing programme details.
    /// </summary>
    public class ProgrammeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Programme Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Programme name must be between 3 and 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Programme name must contain only letters and spaces")]
        [Display(Name = "Programme Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Programme Code is required")]
        [StringLength(20, ErrorMessage = "Programme code must be up to 20 characters")]
        [RegularExpression(@"^[A-Za-z\-]+$", ErrorMessage = "Programme Code must contain only letters and hyphens")]
        [Display(Name = "Programme Code")]
        public string Code { get; set; }


        [Required(ErrorMessage = "Assistance Unit is required")]
        [Display(Name = "Assistance Unit")]
        public int? AssistanceUnitId { get; set; }
        public string AssistanceUnitName { get; set; }

        [Required(ErrorMessage = "Benefit Type is required")]
        [Display(Name = "Benefit Type")]
        public int? ProgramTypeId { get; set; }
        public string ProgramType { get; set; }  

        [Required(ErrorMessage = "Delivery Frequency is required")]
        [Display(Name = "Delivery Frequency")]
        public int PaymentFrequencyId { get; set; }
        public string PaymentFrequencyName { get; set; }

        [Required(ErrorMessage = "Number Of Proxies Allowed is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Number Of Proxies Allowed must be 0 or greater")]
        [Display(Name = "Number Of Proxies Allowed")]
        public int? ProxiesAllowed { get; set; }

        [Required(ErrorMessage = "Payment Amount(Loti) is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Payment Amount must be greater than 0")]
        [Display(Name = "Payment Amount(Loti)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Programme Color Scheme is required")]
        [Display(Name = "Programme Color Scheme")]
        public string? ColourScheme { get; set; }
        [Required(ErrorMessage = "Proof Of Life Duration is required")]
        [Range(1, 4, ErrorMessage = "Proof Of Life Duration must be between 1 and 4 years")]
        [Display(Name = "Proof Of Life Duration")]
        public int? ProofOfLifeSpan { get; set; }
        [Required(ErrorMessage = "Proof Of Life Span Type is required")]

        [Display(Name = "Proof Of Life Span Type")]
        public int? ProofOfLifeSpanId { get; set; }

        public string ProofOfLifeSpanValueDescription { get; set; }

        [Display(Name = "Is Active")]
        [Required(ErrorMessage = "IsActive must be specified")]
        public bool IsActive { get; set; }

        
        [Display(Name = "Created By")]
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }

      
        [Display(Name = "Modified By")]
        public string ModifiedById { get; set; }
        public string ModifiedByName { get; set; }
       
        [Required(ErrorMessage = "At least one Payment Mode is required")]
        [Display(Name = "Payment Modes Allowed")]       
        public IEnumerable<int?> PaymentModesAllowedIds { get; set; } = new List<int?>();
        public List<string> PaymentModesAllowedDescriptions { get; set; } = new();

        // Eligibility Criteria
        [MinLength(1, ErrorMessage = "At least one eligibility criterion is required")]
        public List<EligibilityCriteriaViewModel> EligibilityCriteria { get; set; } = new();
        public List<TopUpViewModel> TopUps { get; set; } = new();
        public List<BenefitRuleViewModel> BenefitRule { get; set; } = new();
        public List<OVCBConfigurationFormViewModel> OVCBConfigurations { get; set; } = new();
        public List<ArrearsConfigurationViewModel> ArrearsConfigurations { get; set; } = new();
    }
}
