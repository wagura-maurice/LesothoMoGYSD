using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class ProxieViewModel
    {
        [Display(Name = "Proxy ID")]
        public int ProxieId { get; set; }

        [Display(Name = "Proxy GUID")]
        public string GUId { get; set; }

        [Required(ErrorMessage = "Payment Details is required.")]
        [Display(Name = "Payment Details ID")]
        public int PaymentDetailsId { get; set; }

        [Required(ErrorMessage = "ID Number is required.")]
        [StringLength(50, ErrorMessage = "ID Number cannot exceed 50 characters.")]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Middle Name cannot exceed 100 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Gender Name")]
        public string GenderName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [StringLength(20, ErrorMessage = "Phone Number cannot exceed 20 characters.")]
        [Display(Name = "Phone Number")]
        // [Phone(ErrorMessage = "Invalid Phone Number.")] // Uncomment if desired
        public string PhoneNumber { get; set; }

        [Display(Name = "Created By (ID)")]
        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By (ID)")]
        public string ModifiedById { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Modified On")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }
    }
}
