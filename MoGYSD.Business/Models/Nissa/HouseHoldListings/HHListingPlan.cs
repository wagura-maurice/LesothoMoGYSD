using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.DistrictRegistrations;

namespace MoGYSD.Business.Models.Nissa.HouseHoldListings;

public class HHListingPlan : BaseAuditableEntity<int>
{
    public int DistrictId { get; set; }
    public District District { get; set; }

    public int DistrictRegistrationPlanId { get; set; }
    public DistrictRegistrationPlan DistrictRegistrationPlan { get; set; }

    public string HHListingActivityName { get; set; }
    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="Partner"/> organization.
    /// </summary>
    public int PartnersId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="Partner"/> entity.
    /// </summary>
    public Partner Partners { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the <see cref="ContactPerson"/> responsible.
    /// </summary>
    public int ContactPersonId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the responsible <see cref="ContactPerson"/>.
    /// </summary>
    public ContactPerson ContactPerson { get; set; }

    /// <summary>
    /// Required relationship: HHListingPlan → SystemCodeDetail (Many-to-One, Mandatory)
    /// Tracks the current status of the listing plan (e.g., Planned, In Progress, Completed)
    /// </summary>
    public int StatusId { get; set; }
    public SystemCodeDetail Status { get; set; }
    public DateTime? ProjectedStartDate { get; set; }
    public DateTime? ProjectedEndDate { get; set; }
    public DateTime? ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: HHListingPlan → HHListings
    /// All household listings created under this listing plan
    /// </summary>
    public ICollection<HHListing> HHListings { get; set; } = new List<HHListing>();

    /// <summary>
    /// One-to-Many: HHListingPlan → CbcActivities
    /// All CBC activities conducted under this listing plan
    /// </summary>
    public ICollection<CbcActivity> CbcActivities { get; set; } = new List<CbcActivity>();

    // Navigation property for approvals (One-to-Many relationship via TransactionId)
    public ICollection<Approval> Approvals { get; set; } = new List<Approval>();
}
