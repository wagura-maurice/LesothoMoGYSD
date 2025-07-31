using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.DistrictRegistrations;
using MoGYSD.Business.Models.Nissa.HouseHoldListings;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// HHEnumerationPlans - Stores information of household enumeration plans created before field exercise to enumerate households.
/// Links the listing process to the household enumeration process.
/// </summary>
public class HHEnumerationPlan : BaseAuditableEntity<int>
{

    public int HHListingPlanId { get; set; }
    public HHListingPlan HHListingPlan { get; set; }

    /// <summary>
    /// Required relationship: HHEnumerationPlan → SystemCodeDetail (Many-to-One, Mandatory)
    /// Tracks the current status of the enumeration plan (e.g., Planned, In Progress, Completed)
    /// </summary>
    public int StatusId { get; set; }
    public SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Optional relationship: HHEnumerationPlan → RegistrationCentre (Many-to-One, Optional)
    /// Links to the registration centre where enumeration activities are coordinated
    /// </summary>
    public int? RegistrationCentreId { get; set; }
    public RegistrationCentre RegistrationCentre { get; set; }

    // Enumeration Plan Dates
    public DateTime ProjectedStartDate { get; set; }
    public DateTime? ProjectedEndDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: HHEnumerationPlan → Household
    /// All households enumerated under this enumeration plan
    /// </summary>
    public ICollection<Household> Households { get; set; } = new List<Household>();

    /// <summary>
    /// One-to-Many: HHEnumerationPlan → Approval
    /// All approvals related to this enumeration plan via TransactionId
    /// </summary>
    public ICollection<Approval> Approvals { get; set; } = new List<Approval>();
}

public class HHEnumerationPlanCC : BaseAuditableEntity<int>
{
    public int HHEnumerationPlanId { get; set; }
    public HHEnumerationPlan HHEnumerationPlan { get; set; }
    public int CCId { get; set; }
    public CommunityCouncil CC { get; set; }

    /// <summary>
    /// Required relationship: HHEnumerationPlan → CCRegistrationActivity (Many-to-One, Mandatory)
    /// Links this enumeration plan to the community council registration activity it belongs to
    /// </summary>
    public int CCRegistrationActivityId { get; set; }
    public CCRegistrationActivity CCRegistrationActivity { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null!;
}

public class EnumerationTeam : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the name of the enumeration team.
    /// </summary>
    public int EnumerationAreaId { get; set; }
    public EnumerationArea EnumerationArea { get; set; }
    /// <summary>
    /// Gets or sets the description of the enumeration team.
    /// </summary>
    public string EnumeratorId { get; set; }
    public ApplicationUser Enumerator{ get; set; }
    public bool IsSupervisor { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null!;
}