using MoGYSD.ViewModels.Missa.Programmes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MoGYSD.Business.Views.Missa.Programmes
{
    /// <summary>
    /// View model for displaying programme details from the ProgrammeView SQL view.
    /// </summary>
    public class ProgrammeView
    {
        /// <summary>
        /// Gets or sets the unique identifier of the programme.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique code identifying the programme.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the programme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the assistance unit associated with the programme.
        /// </summary>
        public int AssistanceUnitId { get; set; }

        /// <summary>
        /// Gets or sets the description of the assistance unit.
        /// </summary>
        public string AssistanceUnitDescription { get; set; }

        /// <summary>
        /// Gets or sets the ID of the programme type.
        /// </summary>
        public int ProgramTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description of the programme type.
        /// </summary>
        public string ProgramTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the programme is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the number of proxies allowed for the programme.
        /// </summary>
        public int ProxiesAllowed { get; set; }

        /// <summary>
        /// Gets or sets the payment amount for the programme.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the UI color scheme code for the programme.
        /// </summary>
        public string ColourScheme { get; set; }

        /// <summary>
        /// Gets or sets the ID of the payment frequency.
        /// </summary>
        public int PaymentFrequencyId { get; set; }

        /// <summary>
        /// Gets or sets the description of the payment frequency.
        /// </summary>
        public string PaymentFrequencyDescription { get; set; }

        /// <summary>
        /// Gets or sets the number of months a beneficiary remains valid without proof of life.
        /// </summary>
        public int? ProofOfLifeSpan { get; set; }

        /// <summary>
        /// Gets or sets the ID of the proof of life span code.
        /// </summary>
        public int ProofOfLifeSpanId { get; set; }

        /// <summary>
        /// Gets or sets the description of the proof of life span value.
        /// </summary>
        public string ProofOfLifeSpanValueDescription { get; set; }

        /// Rename these to exactly match the view column names
        public string PaymentModesAllowedIds { get; set; } = "[]";
        public string PaymentModesAllowedDescriptions { get; set; } = "[]";
        //public string EligibilityCriteriaDescriptions { get; set; } = "[]";
        //public string TopUps { get; set; } = "[]";
        //public string BenefitRules { get; set; } = "[]";
        // Add deserialized versions
        public List<int?> PaymentModesAllowedIdsList =>
            JsonSerializer.Deserialize<List<int?>>(PaymentModesAllowedIds ?? "[]") ?? new();

        public List<string> PaymentModesAllowedDescriptionsList =>
            JsonSerializer.Deserialize<List<string>>(PaymentModesAllowedDescriptions ?? "[]") ?? new();

    //    public List<string> EligibilityCriteriaDescriptionsList =>
    //        JsonSerializer.Deserialize<List<string>>(EligibilityCriteriaDescriptions ?? "[]") ?? new();
    //    public List<TopUpView> TopUpList =>
    //  JsonSerializer.Deserialize<List<TopUpView>>(TopUps ?? "[]") ?? new();

    //    public List<BenefitRuleView> BenefitRule =>
    //JsonSerializer.Deserialize<List<BenefitRuleView>>(BenefitRules ?? "[]") ?? new();
        /// <summary>
        /// Gets or sets the ID of the user who created the programme.
        /// </summary>
        public string CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who created the programme.
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the programme.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last modified the programme.
        /// </summary>
        public string ModifiedById { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last modified the programme.
        /// </summary>
        public string ModifiedByUserName { get; set; }

        /// <summary>
        /// Gets or sets the last modification timestamp of the programme.
        /// </summary>
        public DateTime ModifiedOn { get; set; }
    }
}
