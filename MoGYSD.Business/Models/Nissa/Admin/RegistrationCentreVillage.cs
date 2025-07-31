using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;
public class RegistrationCentreVillage : BaseAuditableEntity<int>
{
    public int RegistrationCentreId { get; set; }
    public RegistrationCentre RegistrationCentre { get; set; } = null!;
    /// <summary>
    /// Gets or sets the foreign key reference to the <see cref="Village"/> where this center is located.
    /// </summary>
    public int VillageId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="Village"/> entity.
    /// </summary>
    public Village Village { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null!;
}
