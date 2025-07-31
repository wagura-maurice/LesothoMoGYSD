using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.DistrictRegistrations;

/// <summary>
/// Represents a registered Community Council entity, tracking official registration status
/// within district registration plans. Inherits from <see cref="BaseAuditableEntity{T}"/>
/// for audit tracking with integer primary key.
/// </summary>
public class CCsRegistered : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="DistrictRegistrationPlan"/>.
    /// </summary>
    /// <remarks>
    /// Links this registration to a specific district registration initiative.
    /// </remarks>
    public int DistrictRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="DistrictRegistrationPlan"/>.
    /// </summary>
    public virtual DistrictRegistrationPlan DistrictRegistrationPlan { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the <see cref="CommunityCouncil"/> entity.
    /// </summary>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the registered <see cref="CommunityCouncil"/>.
    /// </summary>
    public virtual CommunityCouncil CommunityCouncil { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the registration status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Typical statuses might include "Pending", "Approved", or "Rejected".
    /// </remarks>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public virtual SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this registration record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this registration record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }
}
