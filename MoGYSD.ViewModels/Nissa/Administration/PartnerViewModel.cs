using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// ViewModel representing a partner organization for registration and management
/// </summary>
public class PartnerViewModel
{
    /// <summary>
    /// Unique identifier for the partner record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Identifier of the organization type (optional)
    /// </summary>
    public int? OrgTypeId { get; set; }

    /// <summary>
    /// Official name of the partner organization
    /// </summary>
    [Required(ErrorMessage = "Partner name is required")]
    [StringLength(100, ErrorMessage = "Partner name cannot exceed 100 characters")]
    [Display(Name = "Partner Name")]
    public string PartnerName { get; set; }

    /// <summary>
    /// Physical location address of the partner
    /// </summary>
    [Required(ErrorMessage = "Physical address is required")]
    [StringLength(200, ErrorMessage = "Physical address cannot exceed 200 characters")]
    [Display(Name = "Physical Address")]
    public string PhysicalAddress { get; set; }

    /// <summary>
    /// Mailing address for correspondence
    /// </summary>
    [Required(ErrorMessage = "Postal address is required")]
    [StringLength(200, ErrorMessage = "Postal address cannot exceed 200 characters")]
    [Display(Name = "Postal Address")]
    public string PostalAddress { get; set; }

    /// <summary>
    /// Primary landline contact number
    /// </summary>
    [Required(ErrorMessage = "Telephone number is required")]
    [RegularExpression(@"^(\+?\d{1,3}[- ]?)?\d{3,4}[- ]?\d{4}$",
        ErrorMessage = "Invalid telephone number format")]
    [StringLength(20, ErrorMessage = "Telephone number cannot exceed 20 characters")]
    [Display(Name = "Telephone Number")]
    public string TelephoneNumber { get; set; }

    /// <summary>
    /// Mobile contact number
    /// </summary>
    [Required(ErrorMessage = "Mobile number is required")]
    [RegularExpression(@"^(\+?\d{1,3}[- ]?)?(5|6)\d{3}[- ]?\d{4}$",
        ErrorMessage = "Invalid mobile number format")]
    [StringLength(20, ErrorMessage = "Mobile number cannot exceed 20 characters")]
    [Display(Name = "Mobile Number")]
    public string MobileNumber { get; set; }

    [Required(ErrorMessage = "Mobile number prefix is required.")]
    [StringLength(5, ErrorMessage = "Prefix must be at most 5 characters.")]
    [RegularExpression(@"^\+?\d{1,4}$", ErrorMessage = "Enter a valid prefix (e.g. +254 or 254).")]
    public string MobileNumberPrefix { get; set; }

    /// <summary>
    /// Primary email contact address
    /// </summary>
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    [StringLength(100, ErrorMessage = "Email address cannot exceed 100 characters")]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    /// <summary>
    /// District where the partner is located
    /// </summary>
    [Required(ErrorMessage = "District selection is required")]
    [Range(-1, int.MaxValue, ErrorMessage = "Please select a valid district")]
    [Display(Name = "District")]
    public int? DistrictId { get; set; }

    /// <summary>
    /// Purpose for registration with the system
    /// </summary>
    [Required(ErrorMessage = "Registration purpose is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid registration purpose")]
    [Display(Name = "Registration Purpose")]
    public int? RegistrationPurposeId { get; set; }

    /// <summary>
    /// Custom purpose description (when 'Other' is selected)
    /// </summary>
    [StringLength(500, ErrorMessage = "Other purpose cannot exceed 500 characters")]
    [Display(Name = "Other Purpose")]
    public string OtherPurpose { get; set; }

    /// <summary>
    /// Additional notes or comments about the partner
    /// </summary>
    [StringLength(1000, ErrorMessage = "Detailed remarks cannot exceed 1000 characters")]
    [Display(Name = "Detailed Remarks")]
    public string DetailedRemarks { get; set; }

    /// <summary>
    /// Indicates acceptance of data privacy protocols
    /// </summary>
    [Required(ErrorMessage = "You must accept the privacy protocols")]
    [Display(Name = "Accept Privacy Protocols")]
    public bool PrivacyProtocolsAccepted { get; set; }

    /// <summary>
    /// Active/inactive status flag
    /// </summary>
    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Current operational status of the partner
    /// </summary>
    [Required(ErrorMessage = "Status selection is required")]
    [Display(Name = "Status")]
    public int StatusId { get; set; }
    [Display(Name = "Area of operation")]
    public string AreaOfOperation { get; set; } = null;
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }

}