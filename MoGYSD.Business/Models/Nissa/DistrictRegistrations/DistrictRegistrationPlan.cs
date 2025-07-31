using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.MasterRegistrations;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.DistrictRegistrations;
/// <summary>
/// Represents a district-level registration plan that implements a master registration strategy,
/// inheriting audit tracking capabilities from <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class DistrictRegistrationPlan : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the parent <see cref="MasterRegistration"/> plan.
    /// </summary>
    public int MasterRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="MasterRegistration"/> plan.
    /// </summary>
    public MasterRegistration MasterRegistration { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the target <see cref="District"/>.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the target <see cref="District"/>.
    /// </summary>
    public District District { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the plan status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Common statuses: "Draft", "Approved", "InProgress", "Completed"
    /// </remarks>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Gets or sets the name of the district registration plan.
    /// </summary>
    public string RegistrationPlanName { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the registration plan.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the approved budget amount for the registration plan.
    /// </summary>
    public decimal ApprovedBudgetAmount { get; set; }

    /// <summary>
    /// Gets or sets the expected number of households to be registered.
    /// </summary>
    public int ExpectedNoHouseholds { get; set; }

    /// <summary>
    /// Gets or sets the planned start date for registration activities.
    /// </summary>
    public DateTime ProjectedStartDate { get; set; }

    /// <summary>
    /// Gets or sets the planned completion date for registration activities.
    /// </summary>
    /// <remarks>
    /// Nullable as completion date may not be known during planning.
    /// </remarks>
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Gets or sets the actual start date of registration activities.
    /// </summary>
    public DateTime ActualStartDate { get; set; }

    /// <summary>
    /// Gets or sets the actual completion date of registration activities.
    /// </summary>
    /// <remarks>
    /// Will be null until registration is fully completed.
    /// </remarks>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this plan.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this plan.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; }
}