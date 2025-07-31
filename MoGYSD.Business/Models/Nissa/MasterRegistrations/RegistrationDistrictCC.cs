using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.MasterRegistrations;

/// <summary>
/// Represents a junction entity linking registration districts to community councils,
/// including projected household targets, while inheriting audit capabilities from 
/// <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class RegistrationDistrictCC : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the parent <see cref="RegistrationDistrict"/>.
    /// </summary>
    public int RegistrationDistrictId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="CommunityCouncil"/>.
    /// </summary>
    public int CCId { get; set; }

    /// <summary>
    /// Gets or sets the projected number of households to be registered in this community council.
    /// </summary>
    /// <remarks>
    /// Used for planning and resource allocation purposes.
    /// </remarks>
    public int ProjectedHHs { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the creating <see cref="ApplicationUser"/>.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the last modifying <see cref="ApplicationUser"/>.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="RegistrationDistrict"/>.
    /// </summary>
    public virtual RegistrationDistrict RegistrationDistrict { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="CommunityCouncil"/>.
    /// </summary>
    public virtual CommunityCouncil CommunityCouncil { get; set; }
}