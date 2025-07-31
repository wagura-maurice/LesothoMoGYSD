using System;
using System.Collections.Generic;

namespace MoGYSD.Business.Views.Missa.Programmes
{
    /// <summary>
    /// A flattened view model representing a consolidated set of eligibility criteria for a programme.
    /// This view is designed for display in grids and for populating create/edit forms.
    /// </summary>
    public class EligibilityCriteriaView
    {
        /// <summary>
        /// Unique identifier for the eligibility criteria configuration.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key for the programme this criterion belongs to.
        /// </summary>
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Name of the associated programme.
        /// </summary>
        public string ProgrammeName { get; set; }

        /// <summary>
        /// Foreign key for the Assistance Unit (e.g., Individual, Household).
        /// </summary>
        public int AssistanceUnitId { get; set; }

        /// <summary>
        /// Name of the Assistance Unit.
        /// </summary>
        public string AssistanceUnitName { get; set; }

        // --- Multi-Select Fields Start ---

        /// <summary>
        /// A comma-separated string of Vulnerability Type IDs for this criterion.
        /// e.g., "1,5,12"
        /// </summary>
        public string VulnerabilityTypeIds { get; set; }

        /// <summary>
        /// A comma-separated string of Vulnerability Type names for display.
        /// e.g., "Vulnerable Child, Orphan, Disabled"
        /// </summary>
        public string VulnerabilityTypeNames { get; set; }

        /// <summary>
        /// A comma-separated string of Poverty Status IDs for this criterion.
        /// e.g., "10,20"
        /// </summary>
        public string PovertyStatusIds { get; set; }

        /// <summary>
        /// A comma-separated string of Poverty Status names for display.
        /// e.g., "Extreme Poor, Moderate Poor"
        /// </summary>
        public string PovertyStatusNames { get; set; }

        /// <summary>
        /// A comma-separated string of Community Based Categorisation IDs for this criterion.
        /// e.g., "100,101"
        /// </summary>
        public string CBCIds { get; set; }

        /// <summary>
        /// A comma-separated string of Community Based Categorisation names for display.
        /// e.g., "Category A, Category B"
        /// </summary>
        public string CBCNames { get; set; }

        // --- Multi-Select Fields End ---

        /// <summary>
        /// The minimum age for eligibility (nullable).
        /// </summary>
        public int? StartAge { get; set; }

        /// <summary>
        /// The maximum age for eligibility (nullable).
        /// </summary>
        public int? EndAge { get; set; }

        /// <summary>
        /// Foreign key for Community Validation Status (nullable).
        /// </summary>
        public int? CommunityValidationStatusId { get; set; }

        /// <summary>
        /// Name of the Community Validation Status.
        /// </summary>
        public string CommunityValidationStatusName { get; set; }

        /// <summary>
        /// Requirement for MoD Clearance (Yes/No).
        /// </summary>
        public bool? HasMoDClearance { get; set; }

        /// <summary>
        /// Requirement for Disability Registry Registration (Yes/No).
        /// </summary>
        public bool? HasDisabilityRegistryRegistration { get; set; }

        /// <summary>
        /// Requirement for School Enrolment (Yes/No).
        /// </summary>
        public bool? HasSchoolEnrolment { get; set; }

        /// <summary>
        /// A comma-separated string of District IDs for this criterion.
        /// e.g., "1,5,12"
        /// </summary>
        public string LocationIds { get; set; }

        /// <summary>
        /// A comma-separated string of District names for display.
        /// e.g., "District A, District C, District F"
        /// </summary>
        public string LocationNames { get; set; }

        /// <summary>
        /// A comma-separated string of required Programme IDs.
        /// e.g., "2,3"
        /// </summary>
        public string EnrolledInOtherProgrammeIds { get; set; }

        /// <summary>
        /// A comma-separated string of required Programme names for display.
        /// e.g., "Programme X, Programme Y"
        /// </summary>
        public string EnrolledInOtherProgrammeNames { get; set; }

        /// <summary>
        /// Indicates if the eligibility criterion is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Date the criterion was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Username of the user who created the criterion.
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// Date the criterion was last modified.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Username of the user who last modified the criterion.
        /// </summary>
        public string ModifiedByUserName { get; set; }
    }
}