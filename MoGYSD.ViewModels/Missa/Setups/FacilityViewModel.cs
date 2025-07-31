using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Setups
{
    public class FacilityViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Facility code is required.")]
        [StringLength(20, ErrorMessage = "Facility code cannot exceed 20 characters.")]
        [RegularExpression(@"^[A-Za-z\s\-]+$", ErrorMessage = "Facility code can only contain letters, spaces, and hyphens.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Facility name is required.")]
        [StringLength(50, ErrorMessage = "Facility name cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s\-]+$", ErrorMessage = "Facility name can only contain letters, spaces, and hyphens.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bank is required.")]
        public int? BankId { get; set; }

        public string BankName { get; set; }

        [Required(ErrorMessage = "Account No is required.")]
        [StringLength(20, ErrorMessage = "Account No cannot exceed 30 characters.")]
        public string AccountNo { get; set; }

        [Required(ErrorMessage = "Branch Code is required.")]
        [StringLength(20, ErrorMessage = "Branch Code cannot exceed 20 characters.")]
        public string BranchCode { get; set; }

        [Required(ErrorMessage = "Identification Number is required.")]
        [StringLength(20, ErrorMessage = "Identification Number cannot exceed 20 characters.")]
        [RegularExpression(@"^[A-Za-z0-9\-]+$", ErrorMessage = "Only letters, numbers, and hyphens allowed.")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Facility type is required.")]
        public int? FacilityTypeId { get; set; }

        public string FacilityTypeName { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Head Name is required.")]
        [StringLength(50, ErrorMessage = "Head Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "Head Name can only contain letters, spaces, hyphens, or apostrophes.")]
        public string HeadName { get; set; }

        [Required(ErrorMessage = "Head Surname is required.")]
        [StringLength(50, ErrorMessage = "Head Surname cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "Head Surname can only contain letters, spaces, hyphens, or apostrophes.")]
        public string HeadSurname { get; set; }


        [Required(ErrorMessage = "Head Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Head Email")]
        public string HeadEmail { get; set; }

        [Required(ErrorMessage = "Head Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid Head phone number.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Head Phone number must be between 8 and 10 digits.")]
        [RegularExpression(@"^\d{8,10}$", ErrorMessage = "Enter digits only (8 to 10 numbers).")]
        [Display(Name = "Head Phone Number")]
        public string HeadPhoneNumber { get; set; }

        public bool IsActive { get; set; }
        public List<int> SelectedGradesIds { get; set; } = new List<int>();
    }
}
