using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class PaymentDetailViewModel
    {
        [Display(Name = "Payment Detail ID")]
        public int PaymentDetailId { get; set; }

        [Required(ErrorMessage = "Enrolment is required.")]
        [Display(Name = "Enrolment ID")]
        public int EnrolmentId { get; set; }

        [Required(ErrorMessage = "Payment Mode is required.")]
        [Display(Name = "Payment Mode")]
        public int PaymentModeId { get; set; }

        [Display(Name = "Payment Mode Name")]
        public string PaymentModeName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile Number")]
        [Phone(ErrorMessage = "Invalid mobile number.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Facility is required.")]
        [Display(Name = "Facility")]
        public int FacilityId { get; set; }

        [Display(Name = "Facility Name")]
        public string FacilityName { get; set; }

        [Required(ErrorMessage = "Payee is required.")]
        [Display(Name = "Payee")]
        public int PayeeId { get; set; }

        [Display(Name = "Payee Full Name")]
        public string PayeeFullName { get; set; }

        [Required(ErrorMessage = "Pay Point is required.")]
        [Display(Name = "Pay Point")]
        public int PayPointId { get; set; }

        [Display(Name = "Pay Point Name")]
        public string PayPointName { get; set; }

        [Required(ErrorMessage = "Payee Type is required.")]
        [Display(Name = "Payee Type")]
        public int PayeeTypeId { get; set; }

        [Display(Name = "Payee Type Name")]
        public string PayeeTypeName { get; set; }

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
