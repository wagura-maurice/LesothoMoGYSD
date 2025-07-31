using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// ViewModel for ValidationList entity, representing a community validation exercise header.
    /// </summary>
    public class ValidationListViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Validation Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "Validation End Date")]
        [DateGreaterThan("StartDate")]
        public DateTime? EndDate { get; set; }    
     
        [Required(ErrorMessage = "District is required")]   
        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Required]
        [Display(Name = "Community Council")]
        public int? CommunityCouncilId { get; set; }
        public string CommunityCouncilName { get; set; }

        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        // ADD THIS: Collection of validation outcomes
        public List<ValidationDetailViewModel> Details { get; set; } = new();
    }
}
