using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Setups
{
    public class PayPointViewModel
    {
        [Display(Name = "Pay Point ID")]
        public int PayPointId { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [StringLength(50, ErrorMessage = "Code cannot exceed 50 characters.")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Community Council is required.")]
        [Display(Name = "Community Council ID")]
        public int CommunityCouncilId { get; set; }

        [Display(Name = "Community Council Name")]
        public string CommunityCouncilName { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District ID")]
        public int DistrictId { get; set; }

        [Display(Name = "District Name")]
        public string DistrictName { get; set; }

        [Display(Name = "Created By (ID)")]
        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By (ID)")]
        public string ModifiedById { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}
