using Microsoft.AspNetCore.Components.Forms;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.ViewModels.Nissa.Security.UserViewModels;
/// <summary>
/// ViewModel for user registration with comprehensive validation
/// </summary>
public class RegisterUserViewModel
{
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// Role identifier for the user
    /// </summary>
    [Required(ErrorMessage = "Role is required")]
    [Display(Name = "Role")]
    public string RoleId { get; set; }

    /// <summary>
    /// District identifier for the user
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid District")]
    [Display(Name = "District")]
    public int? DistrictId { get; set; }

    /// <summary>
    /// Community Council identifier for the user
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Community Council")]
    [Display(Name = "Community Council")]
    public int? CommunityCouncilId { get; set; }

    /// <summary>
    /// Village identifier for the user
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Village")]
    [Display(Name = "Village")]
    public int? VillageId { get; set; }

    /// <summary>
    /// User's first name
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    /// <summary>
    /// User's middle name
    /// </summary>
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Middle name must be between 2 and 50 characters")]
    [Display(Name = "Middle Name")]
    public string MiddleName { get; set; }

    /// <summary>
    /// User's surname
    /// </summary>
    [Required(ErrorMessage = "Surname is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters")]
    [Display(Name = "Surname")]
    public string Surname { get; set; }

    /// <summary>
    /// User's phone number
    /// </summary>
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [StringLength(10, MinimumLength = 8, ErrorMessage = "Phone number must be between 8 and 10 digits")]
    [RegularExpression(@"^\d{8,10}$", ErrorMessage = "Enter digits only (8 to 10 numbers).")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    public DateTime? ModifiedOn { get; set; }
    /// <summary>
    /// Registration center identifier
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Registration Centre")]
    [Display(Name = "Registration Centre")]
    public int? RegistrationCentreId { get; set; }

    /// <summary>
    /// Indicates if the user account is active
    /// </summary>
    [Display(Name = "Active")]
    public bool IsActive { get; set; } = false;

    /// <summary>
    /// User's email address
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Email confirmation field
    /// </summary>
    [Required(ErrorMessage = "Please confirm your email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [Display(Name = "Confirm Email")]
    [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
    public string ConfirmEmail { get; set; } = string.Empty;

    /// <summary>
    /// User's gender identifier
    /// </summary>
    [Required(ErrorMessage = "Sex is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid sex")]
    [Display(Name = "Gender")]
    public int? SexId { get; set; }

    /// <summary>
    /// User's identification number
    /// </summary>
    [StringLength(13, MinimumLength = 12, ErrorMessage = "Surname must be between 12 and 13 characters")]
    [Display(Name = "ID Number")]
    public string IDNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date when the user was created
    /// </summary>
    [Display(Name = "Created On")]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// User status identifier
    /// </summary>
    [Display(Name = "Status")]
    public int StatusId { get; set; } = 1; // Default to Active

    /// <summary>
    /// DateTime? 
    public string CreatedById { get; set; }
    public string ModifiedById { get; set; }
    public bool PrivacyProtocolsAccepted { get; set; }
    [NotMapped]
    public List<RegistrationImage> Documents { get; set; }
    [NotMapped]
    public List<RegistrationImage> PhotoDocuments { get; set; }

    [Required(ErrorMessage = "Please upload at least one document.")]
    public IReadOnlyList<IBrowserFile> UploadDocuments { get; set; }

    [Required(ErrorMessage = "Kindly enter captcha")]
    public string EnteredCaptchaText { set; get; }
    public string SourceOfRegistration { get; set; }
    [Required(ErrorMessage = "ID type is required")]
    public int? IDTypeId { get; set; }
    public string IDType { get; set; } = string.Empty;
    [Required(ErrorMessage = "Country code is required")]
    public string CountryCode { get; set; } = string.Empty;

}
