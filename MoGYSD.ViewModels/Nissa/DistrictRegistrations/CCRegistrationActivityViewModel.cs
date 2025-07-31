using Microsoft.AspNetCore.Components.Forms;
using MoGYSD.Business.Models.Nissa.DistrictRegistrations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.ViewModels.Nissa.DistrictRegistrations;
/// <summary>
/// ViewModel for Community Council Registration Activity tracking
/// </summary>
public class CCRegistrationActivityViewModel
{
    /// <summary>
    /// Unique identifier for the activity record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to the Community Council registration record
    /// </summary>
    //[Required(ErrorMessage = "Community Council registration reference is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid Community Council registration reference")]
    [Display(Name = "Community Council Registered")]
    public int CCsRegisteredId { get; set; }

    /// <summary>
    /// Type of activity being performed
    /// </summary>
    //[Required(ErrorMessage = "Activity type is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid activity type")]
    [Display(Name = "Activity Type")]
    public int? ActivityId { get; set; }

    /// <summary>
    /// Current status of the activity
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid status")]
    [Display(Name = "Activity Status")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Detailed description of the activity
    /// </summary>
    //[Required(ErrorMessage = "Activity description is required")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Activity Description")]
    public string ActivityDescription { get; set; }

    /// <summary>
    /// Number of households impacted by this activity
    /// </summary>
    //[Required(ErrorMessage = "Number of households is required")]
    //[Range(1, int.MaxValue, ErrorMessage = "Number of households must be greater 1")]
    //[Display(Name = "Households Impacted")]
    public int? NumberOfHouseholds { get; set; }

    /// <summary>
    /// Partner organization involved in the activity
    /// </summary>
    //[Required(ErrorMessage = "Partner organization is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid partner")]
    [Display(Name = "Partner Organization")]
    public int? PartnersId { get; set; }

    /// <summary>
    /// Primary contact person for the activity
    /// </summary>
    //[Required(ErrorMessage = "Contact person is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid contact person")]
    [Display(Name = "Primary Contact")]
    public int? ContactPersonId { get; set; }

    /// <summary>
    /// Date when the activity was recorded
    /// </summary>
    [DataType(DataType.DateTime)]
    [Display(Name = "Activity Date")]
    public DateTime? ActivityDate { get; set; }

    /// <summary>
    /// Location where the activity took place
    /// </summary>
    [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
    [Display(Name = "Activity Location")]
    public string Location { get; set; }

    /// <summary>
    /// Additional notes about the activity
    /// </summary>
    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Additional Notes")]
    public string Notes { get; set; }
    [Required(ErrorMessage = "Community Council is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid partner")]
    [Display(Name = "Community Council")]
    public int? CommunityCouncilId { get; set; }
    public string CommunityCouncilName { get; set; }
    public DateTime? ProjectedStartDate { get; set; }
    public DateTime? ProjectedEndDate { get; set; }
    // EF-mapped JSON string property for the DB column
    public string DocumentsJson { get; set; }

    // Not mapped property for use in your app, deserialized from JSON string
    [NotMapped]
    public List<DocumentImage> Documents
    {
        get
        {
            if (string.IsNullOrEmpty(DocumentsJson))
                return new List<DocumentImage>();
            return JsonConvert.DeserializeObject<List<DocumentImage>>(DocumentsJson);
        }
        set
        {
            DocumentsJson = JsonConvert.SerializeObject(value);
        }
    }
    public IReadOnlyList<IBrowserFile> UploadDocuments { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsRequired { get; set; } = true;
}
