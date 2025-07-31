using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

public class EnumerationArea : BaseAuditableEntity<int>
{
    public string Name { get; set; }
    public int HHEnumerationPlanId { get; set; }
    public HHEnumerationPlan HHEnumerationPlan { get; set; }
    /// <summary>
    /// Gets or sets the user who created this district record.
    /// </summary>
    /// <remarks>
    /// Navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </remarks>
    public ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the user who last modified this district record.
    /// </summary>
    /// <remarks>
    /// Navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </remarks>
    public ApplicationUser ModifiedBy { get; set; }

    public ICollection<EnumerationAreaVillage> EnumerationAreaVillages { get; set; }
}
