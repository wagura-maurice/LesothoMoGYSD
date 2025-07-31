using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Make sure the namespace matches your project's structure for ViewModels.
namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// View model for creating and editing a consolidated eligibility criteria configuration for a programme.
    /// </summary>
    public class EligibilityCriteriaViewModel
    {
        /// <summary>
        /// Unique identifier for the eligibility criterion. 0 for a new criterion.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the programme this criterion belongs to.
        /// </summary>
        [Required(ErrorMessage = "The Programme is required")]
        [Display(Name = "Programme")]
        public int? ProgrammeId { get; set; }

        /// <summary>
        /// The unit of assistance (e.g., Individual, Household). This will be a dropdown.
        /// </summary>
        [Required(ErrorMessage = "The Assistance Unit is required")]
        [Display(Name = "Assistance Unit")]
        public int? AssistanceUnitId { get; set; }

        /// <summary>
        /// The type of vulnerability, applicable if Assistance Unit is 'Individual'. This will be a dropdown.
        /// </summary>
        [Display(Name = "Vulnerability Type")]
        public int? VulnerabilityTypeId { get; set; }

        /// <summary>
        /// The minimum age for eligibility.
        /// </summary>
        [Display(Name = "Minimum Age")]
        public int? StartAge { get; set; }

        /// <summary>
        /// The maximum age for eligibility.
        /// </summary>
        [Display(Name = "Maximum Age")]
        public int? EndAge { get; set; }

        /// <summary>
        /// The required poverty status. This will be a dropdown.
        /// </summary>
        [Required]
        [Display(Name = "Poverty Status")]
        public int? PovertyStatusId { get; set; }

        /// <summary>
        /// The required community-based categorization. This will be a dropdown.
        /// </summary>
        [Required]
        [Display(Name = "Community Based Categorisation")]
        public int? CommunityBasedCategorisationId { get; set; }

        /// <summary>
        /// The required community validation status. This will be a dropdown.
        /// </summary>
        [Required]
        [Display(Name = "Community Validation Status")]
        public int? CommunityValidationStatusId { get; set; }

        /// <summary>
        /// Indicates if MoD clearance is required. Can be true, false, or null (not applicable).
        /// </summary>
        [Display(Name = "MoD Clearance Required?")]
        public bool? HasMoDClearance { get; set; }

        /// <summary>
        /// Indicates if disability registry registration is required.
        /// </summary>
        [Display(Name = "Disability Registry Registration Required?")]
        public bool? HasDisabilityRegistryRegistration { get; set; }

        /// <summary>
        /// Indicates if school enrolment is required.
        /// </summary>
        [Display(Name = "School Enrolment Required?")]
        public bool? HasSchoolEnrolment { get; set; }

        /// <summary>
        /// Indicates if the entire criteria set is active.
        /// </summary>
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }


        /// </summary>
        [Required]
        [Display(Name = "Districts")]
        public List<int?> SelectedLocationIds { get; set; }

        /// <summary>      
        /// </summary>
        [Display(Name = "Must be Enrolled in Other Programmes")]
        public List<int?> SelectedOtherProgrammeIds { get; set; }
        /// <summary>
        /// Selected multiple vulnerability type IDs.
        /// </summary>
        [Display(Name = "Vulnerability Types")]
        public List<int?> SelectedVulnerabilityTypeIds { get; set; }

        /// <summary>
        /// Selected multiple poverty status IDs.
        /// </summary>
        [Display(Name = "Poverty Statuses")]
        public List<int?> SelectedPovertyStatusIds { get; set; }

        /// <summary>
        /// Selected multiple community-based categorisation IDs.
        /// </summary>
        [Display(Name = "Community Based Categorisations")]
        public List<int?> SelectedCBCIds { get; set; }

        /// <summary>
        /// Initializes collections to prevent null reference exceptions.
        /// </summary>
        public EligibilityCriteriaViewModel()
        {
            IsActive = true; // Default to active for new criteria
            SelectedLocationIds = new List<int?>();
            SelectedOtherProgrammeIds = new List<int?>();
             SelectedVulnerabilityTypeIds = new List<int?>();
            SelectedPovertyStatusIds = new List<int?>();
            SelectedCBCIds = new List<int?>();
        }
    }
}