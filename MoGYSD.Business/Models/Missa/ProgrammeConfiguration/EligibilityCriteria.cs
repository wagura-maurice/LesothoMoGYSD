using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents the eligibility criteria for a programme, defining specific conditions
    /// that determine a household's or individual's qualification.
    /// </summary>
    /// <remarks>
    /// This entity consolidates various eligibility rules such as age, location, poverty status,
    /// and other verification requirements into a single configuration for a programme.
    /// </remarks>
    public class EligibilityCriteria : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the eligibility criterion.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the Assistance Unit (e.g., Individual, Household).
        /// Referenced from <see cref="SystemCodeDetail"/>.
        /// </summary>
        public int AssistanceUnitId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the Assistance Unit.
        /// </summary>
        public virtual SystemCodeDetail AssistanceUnit { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="Programmes"/>.
        /// </summary>
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated programme.
        /// </summary>
        public virtual Programmes Programme { get; set; }
       

        /// <summary>
        /// Gets or sets the minimum age for eligibility. Can be null if not applicable.
        /// </summary>
        public int? StartAge { get; set; }

        /// <summary>
        /// Gets or sets the maximum age for eligibility. Can be null if not applicable.
        /// </summary>
        public int? EndAge { get; set; }   

      

        /// <summary>
        /// Gets or sets the foreign key for the Community Validation Status.
        /// Referenced from <see cref="SystemCodeDetail"/>. Can be null.
        /// </summary>
        public int? CommunityValidationStatusId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the Community Validation Status.
        /// </summary>
        public virtual SystemCodeDetail CommunityValidationStatus { get; set; }

        /// <summary>
        /// Gets or sets a nullable boolean value indicating if MoD Clearance is a requirement.
        /// </summary>
        public bool? HasMoDClearance { get; set; }

        /// <summary>
        /// Gets or sets a nullable boolean value indicating if Disability Registry Registration is a requirement.
        /// </summary>
        public bool? HasDisabilityRegistryRegistration { get; set; }

        /// <summary>
        /// Gets or sets a nullable boolean value indicating if School Enrolment is a requirement.
        /// </summary>
        public bool? HasSchoolEnrolment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the eligibility criterion is currently active.
        /// </summary>
        public bool IsActive { get; set; } = true;
        public virtual ICollection<EligibilityCriteriaPovertyStatus> EligibilityCriteriaPovertyStatuses { get; set; }

        // Many-to-many: Vulnerability Type (multi-select)
        public virtual ICollection<EligibilityCriteriaVulnerabilityType> EligibilityCriteriaVulnerabilityTypes { get; set; }

        // Many-to-many: Community Based Categorisation (multi-select)
        public virtual ICollection<EligibilityCriteriaCBC> EligibilityCriteriaCBCs { get; set; }
        /// <summary>
        /// Gets or sets the collection of applicable locations (Districts) for this criterion.
        /// This represents a many-to-many relationship via the EligibilityCriteriaLocation join table.
        /// </summary>
        public virtual ICollection<EligibilityCriteriaLocation> EligibilityCriteriaLocations { get; set; }

        /// <summary>
        /// Gets or sets the collection of other programmes that an applicant must be enrolled in.
        /// This represents a many-to-many relationship via the EnrolledInOtherProgramme join table.
        /// </summary>
        public virtual ICollection<EnrolledInOtherProgramme> EnrolledInOtherProgrammes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EligibilityCriteria"/> class.
        /// </summary>
        public EligibilityCriteria()
        {
            EligibilityCriteriaLocations = new HashSet<EligibilityCriteriaLocation>();
            EnrolledInOtherProgrammes = new HashSet<EnrolledInOtherProgramme>();
            EligibilityCriteriaPovertyStatuses = new HashSet<EligibilityCriteriaPovertyStatus>();
            EligibilityCriteriaVulnerabilityTypes = new HashSet<EligibilityCriteriaVulnerabilityType>();
            EligibilityCriteriaCBCs = new HashSet<EligibilityCriteriaCBC>();
        }
    }
}