using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.HouseHoldListings;

public class CbcActivitiesViewModel
{
    public int Id { get; set; }
    public int DistrictId { get; set; }

    [Required(ErrorMessage = "CommunityCouncil is required")]
    public int? CommunityCouncilId { get; set; }

    [Required(ErrorMessage = "HH Listing Plan is required")]
    [Display(Name = "HH Listing Plan")]
    public int? HHListingPlanId { get; set; }

    [Required(ErrorMessage = "Date CBC Conducted is required")]
    [Display(Name = "Date CBC Conducted")]
    [DataType(DataType.Date)]
    public DateTime? DateCBCConducted { get; set; }

    [Display(Name = "Total Number of CBC Participants")]
    [Range(0, 10000, ErrorMessage = "Total Number of CBC Participants must be between 0 and 10000")]
    public int TotalNumberofCBCParticipants { get; set; }

    public int? ContactPersonId { get; set; }
    public int? PartnerId { get; set; }
    public int StatusId { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}