using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.DistrictRegistrations;

/// <summary>
/// Represents a Community Council registration activity entity, tracking events and operations
/// performed during community registration processes. Inherits from <see cref="BaseAuditableEntity{T}"/>
/// for audit tracking with integer primary key.
/// </summary>
public class CCRegistrationActivity : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="CCsRegistered"/> record.
    /// </summary>
    public int CCsRegisteredId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="CCsRegistered"/> entity.
    /// </summary>
    public virtual CCsRegistered CCsRegistered { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the activity type in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int ActivityId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the activity type <see cref="SystemCodeDetail"/>.
    /// </summary>
    public virtual SystemCodeDetail Activity { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public virtual SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the registration activity.
    /// </summary>
    public string ActivityDescription { get; set; }

    /// <summary>
    /// Gets or sets the number of households impacted by this registration activity.
    /// </summary>
    public int NumberOfHouseholds { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="Partner"/> organization.
    /// </summary>
    public int PartnersId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="Partner"/> entity.
    /// </summary>
    public virtual Partner Partners { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the <see cref="ContactPerson"/> responsible.
    /// </summary>
    public int ContactPersonId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the responsible <see cref="ContactPerson"/>.
    /// </summary>
    public virtual ContactPerson ContactPerson { get; set; }
    public DateTime ProjectedStartDate { get; set; }
    public DateTime ProjectedEndDate { get; set; }
    public List<DocumentImage> Documents { get; set; }
    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }
    public bool IsRequired { get; set; }
}
public class DocumentImage
{
    public required string Name { get; set; }
    public decimal Size { get; set; }
    public required string Url { get; set; }
}