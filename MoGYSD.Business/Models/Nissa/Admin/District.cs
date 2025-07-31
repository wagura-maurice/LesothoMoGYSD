using MoGYSD.Business.Models.Common;
//using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System.Linq.Expressions;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a District entity in the database.
/// Inherits from <see cref="BaseAuditableEntity{T}"/> for audit tracking.
/// </summary>
public class District : BaseAuditableEntity<int>, IHasUniqueKey<District>
{
    /// <summary>
    /// Gets or sets the unique code identifier for the district.
    /// </summary>
    /// <remarks>
    /// This is typically a short alphanumeric code used for quick reference.
    /// </remarks>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the name of the district.
    /// </summary>
    /// <remarks>
    /// This is the full official name of the district.
    /// </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the district is currently active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the district is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; }

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
    public ICollection<UserDistrictAssignment> UserAssignments { get; set; } = new List<UserDistrictAssignment>();
    public Expression<Func<District, bool>> GetUniquePredicate()
    {
        return ed => ed.Code == Code; //&& ed.RegionId == this.RegionId;
    }
    //public virtual ICollection<EnrolmentEvent> EnrolmentEvents { get; set; } = new List<EnrolmentEvent>();
    //public virtual ICollection<EnrolmentSchedule> EnrolmentSchedules { get; set; } = new List<EnrolmentSchedule>();
    //public virtual ICollection<PayPoint> PayPoints { get; set; } = new List<PayPoint>();
}
