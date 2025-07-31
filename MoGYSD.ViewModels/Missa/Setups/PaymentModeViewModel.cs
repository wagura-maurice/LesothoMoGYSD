using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Setups
{
    public class PaymentModeViewModel
    {
        [Display(Name = "Payment Mode ID")]
        public int PaymentModeId { get; set; }

        [Required(ErrorMessage = "Payment Mode Name is required.")]
        [StringLength(255, ErrorMessage = "Payment Mode Name cannot exceed 255 characters.")]
        [Display(Name = "Payment Mode Name")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

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
