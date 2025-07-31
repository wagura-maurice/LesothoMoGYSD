namespace MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System.ComponentModel.DataAnnotations;

public class CCsRegisteredViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "District Registration Plan ID is required")]
    [Display(Name = "District Registration Plan")]
    public int DistrictRegistrationPlanId { get; set; }
    public string DistrictRegistrationPlanName { get; set; }
    [Required(ErrorMessage = "Community Council ID is required")]
    [Display(Name = "Community Council")]
    public int CommunityCouncilId { get; set; }
    public string CommunityCouncilName { get; set; }
    [Required(ErrorMessage = "Status is required")]
    [Display(Name = "Status")]
    public int? StatusId { get; set; }
    //public string StatusName { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}
