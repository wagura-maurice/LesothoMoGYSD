using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.HouseHoldListings;

//using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a Village entity in the system, inheriting audit tracking capabilities
/// from <see cref="BaseAuditableEntity{T}"/> with integer primary key.
/// </summary>
public class Village : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the unique code identifier for the village.
    /// </summary>
    /// <remarks>
    /// Typically a short alphanumeric code used for system reference.
    /// </remarks>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the official name of the village.
    /// </summary>
    /// <remarks>
    /// This is the formal name used for display and identification purposes.
    /// </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the parent <see cref="CommunityCouncil"/>.
    /// </summary>
    /// <remarks>
    /// Every village must belong to a community council.
    /// </remarks>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the village is currently active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the village is active and available for use; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="CommunityCouncil"/> entity.
    /// </summary>
    public virtual CommunityCouncil CommunityCouncil { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this village record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this village record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }

    public ICollection<EnumerationAreaVillage> EnumerationAreaVillages { get; set; }
    public ICollection<UserVillageAssignment> UserAssignments { get; set; } = new List<UserVillageAssignment>();
    // Navigation property to join entity
    public ICollection<CbcActivityVillage> CbcActivityVillages { get; set; }

}
