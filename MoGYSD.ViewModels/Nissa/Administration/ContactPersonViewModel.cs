using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// ViewModel representing a contact person entity for UI interaction and validation
/// </summary>
public class ContactPersonViewModel
{
    /// <summary>
    /// Unique identifier for the contact person record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Identifier of the associated partner organization
    /// </summary>
    [Required(ErrorMessage = "Partner selection is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid partner")]
    [Display(Name = "Partner")]
    public int PartnerId { get; set; }

    /// <summary>
    /// Identifier of the contact type classification
    /// </summary>
    [Required(ErrorMessage = "Contact type is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid contact type")]
    [Display(Name = "Contact Type")]
    public int ContactTypeId { get; set; }

    /// <summary>
    /// First name of the contact person
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    /// <summary>
    /// Surname (last name) of the contact person
    /// </summary>
    [Required(ErrorMessage = "Surname is required")]
    [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters")]
    [Display(Name = "Surname")]
    public string Surname { get; set; }

    /// <summary>
    /// Mobile phone number of the contact person
    /// </summary>
    [Phone(ErrorMessage = "Invalid mobile number format")]
    [StringLength(20, ErrorMessage = "Mobile number cannot exceed 20 characters")]
    [Display(Name = "Mobile Number")]
    public string MobileNumber { get; set; }

    /// <summary>
    /// Email address of the contact person
    /// </summary>
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    [StringLength(100, ErrorMessage = "Email address cannot exceed 100 characters")]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}