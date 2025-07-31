using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.HouseHoldListings;

public class CCHouseHoldListingAreaViewModel
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier in the CC (Community Center?) system
    /// </summary>
    [Required(ErrorMessage = "Community Center is required")]
    [Display(Name = "CC ID")]
    public int? CCId { get; set; }
    public int HHListingPlanId { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}