using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MoGYSD.ViewModels.Missa.Programmes
{
    public class OVCBConfigurationFormViewModel
    {
        public int Id { get; set; }

      
        public int ProgrammeId { get; set; }       

        [Required]
        [Display(Name = "Facility Type")]
        public int? FacilityTypeId { get; set; }
        public string? FacilityTypeName { get; set; }

        [Required]
        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        public string? GradeName { get; set; }

        [Required]
        [Display(Name = "Fee Type")]
        public int? FeeTypeId { get; set; }
        public string? FeeTypeName { get; set; }


        [Required]
        [Display(Name = "Fee Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Fee must be a positive number.")]
        public decimal FeeAmount { get; set; }

     
        [Display(Name = "Financial Year")]
        public int? FinYearId { get; set; }
        public string? FinYearName { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; } = true;
    }
}
