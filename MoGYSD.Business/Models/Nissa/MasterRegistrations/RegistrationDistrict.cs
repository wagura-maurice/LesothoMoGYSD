using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.MasterRegistrations;

/// <summary>
/// Represents a district within a master registration plan, containing key demographic targets
/// and coverage metrics, while inheriting audit capabilities from <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class RegistrationDistrict : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the parent <see cref="MasterRegistration"/> plan.
    /// </summary>
    public int MasterRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="District"/>.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the current population count for the district.
    /// </summary>
    /// <remarks>
    /// Used as baseline for registration coverage calculations.
    /// </remarks>
    public int CurrentPopulation { get; set; }
    /// <summary>
    /// Gets or sets the Estimated population count for the district.
    /// </summary>
    /// <remarks>
    /// Used as baseline for registration coverage calculations.
    /// </remarks>
    public int EstimatedPopulation { get; set; }

    /// <summary>
    /// Gets or sets the prior registration coverage percentage (0-100).
    /// </summary>
    /// <remarks>
    /// Represents historical coverage to measure progress against.
    /// </remarks>
    public int PriorCoverage { get; set; }
    /// <summary>
    /// Gets or sets the Current registration coverage percentage (0-100).
    /// </summary>
    /// <remarks>
    /// Represents historical coverage to measure progress against.
    /// </remarks>
    public int CurrentCoverage { get; set; }

    /// <summary>
    /// Gets or sets the total number of households targeted for registration.
    /// </summary>
    /// <remarks>
    /// Calculated based on population and coverage goals.
    /// </remarks>
    public int TotalHHsToTarget { get; set; }

    /// <summary>
    /// Gets or sets the total number of Population targeted for registration.
    /// </summary>
    /// <remarks>
    /// Calculated based on population and coverage goals.
    /// </remarks>
    public int TotalPopulationToTarget { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the creating <see cref="ApplicationUser"/>.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the last modifying <see cref="ApplicationUser"/>.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="District"/>.
    /// </summary>
    public virtual District District { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="MasterRegistration"/> plan.
    /// </summary>
    public virtual MasterRegistration MasterRegistration { get; set; }
}