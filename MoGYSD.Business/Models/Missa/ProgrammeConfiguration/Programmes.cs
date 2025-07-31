using MoGYSD.Business.Models.Common;
//using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents the configuration settings for a social support programme.
    /// </summary>
    public class Programmes : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the programme.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique programme code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the programme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the assistance unit.
        /// </summary>
        public int AssistanceUnitId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the assistance unit.
        /// </summary>
        public virtual SystemCodeDetail AssistanceUnit { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the programme type.
        /// </summary>
        public int ProgramTypeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the programme type.
        /// </summary>
        public virtual SystemCodeDetail ProgramType { get; set; }

    

        /// <summary>
        /// Gets or sets a value indicating whether the programme is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the payee modality (e.g. Bank, Mobile Money).
        /// </summary>
        public int ProxiesAllowed { get; set; }

        /// <summary>
        /// Gets or sets the payment amount allocated per beneficiary.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the color scheme code used for UI display.
        /// </summary>
        public string ColourScheme { get; set; }

       

        /// <summary>
        /// Gets or sets the foreign key to the payment frequency.
        /// </summary>
        public int PaymentFrequencyId { get; set; }

        /// <summary>
        /// Gets or sets the payment frequency (e.g. Monthly, Quarterly).
        /// </summary>
        public virtual PaymentFrequencies PaymentFrequency { get; set; }

        /// <summary>
        /// Gets or sets the number of months a beneficiary remains valid without proof of life.
        /// </summary>
        public int? ProofOfLifeSpan { get; set; }

        public int ProofOfLifeSpanId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the ProofOfLifeSpanValue.
        /// </summary>
        public virtual SystemCodeDetail ProofOfLifeSpanValue { get; set; }

        /// <summary>
        /// Gets or sets the collection of allowed payment modes for this programme.
        /// </summary>
        public virtual ICollection<SystemCodeDetail> PaymentModesAllowed { get; set; } = new List<SystemCodeDetail>();


        /// <summary>
        /// Gets or sets the collection of eligibility criteria for the programme.
        /// </summary>
        public virtual ICollection<EligibilityCriteria> EligibilityCriteria { get; set; } = new List<EligibilityCriteria>();
        public virtual ICollection<TopUps> TopUps { get; set; } = new List<TopUps>();
        public virtual ICollection<BenefitRule> BenefitRule { get; set; } = new List<BenefitRule>();
        public virtual ICollection<OVCBConfiguration> OVCBConfigurations { get; set; } = new List<OVCBConfiguration>();
        public virtual ICollection<ArrearsConfiguration> ArrearsConfigurations { get; set; } = new List<ArrearsConfiguration>();
        //public virtual ICollection<EnrolmentEvent> EnrolmentEvents { get; set; } = new List<EnrolmentEvent>();
    }
}
