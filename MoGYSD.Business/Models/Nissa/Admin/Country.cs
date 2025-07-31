using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

// This class represents a country entity with properties for code, name, population, and status.
public class Country : BaseAuditableEntity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Population { get; set; }
    public bool Status { get; set; }
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
