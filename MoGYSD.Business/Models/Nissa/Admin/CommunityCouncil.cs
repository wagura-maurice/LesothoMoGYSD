using MoGYSD.Business.Models.Common;
//using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a Community Council entity in the database.
/// Inherits from <see cref="BaseAuditableEntity{T}"/> for audit tracking with integer primary key.
/// </summary>
public class CommunityCouncil : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the unique code identifier for the community council.
    /// </summary>
    /// <remarks>
    /// Typically a short alphanumeric code used for system reference.
    /// Maximum length should be enforced via data annotations or Fluent API.
    /// </remarks>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the official name of the community council.
    /// </summary>
    /// <remarks>
    /// This is the full formal name used for display purposes.
    /// Maximum length should be enforced via data annotations or Fluent API.
    /// </remarks>
    public string CommunityCouncilName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this community council is currently active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the community council is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }
    public int? DistrictId { get; set; }
    public District District { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the parent <see cref="Constituency"/> entity.
    /// </summary>
    /// <remarks>
    /// Every community council must belong to a district.
    /// </remarks>
    public int? ConstituencyId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="Constituency"/> entity.
    /// </summary>
    public virtual Constituency Constituency { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }
    public ICollection<UserCommunityCouncilAssignment> UserAssignments { get; set; } = new List<UserCommunityCouncilAssignment>();


}