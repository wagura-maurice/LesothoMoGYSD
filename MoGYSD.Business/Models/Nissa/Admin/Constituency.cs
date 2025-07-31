using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

public class Constituency : BaseAuditableEntity<int>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public bool Status { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    /// <summary>
    /// Gets or sets the user who created this district record.
    /// </summary>
    /// <remarks>
    /// Navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </remarks>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the user who last modified this district record.
    /// </summary>
    /// <remarks>
    /// Navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </remarks>
    public virtual ApplicationUser ModifiedBy { get; set; }
}
