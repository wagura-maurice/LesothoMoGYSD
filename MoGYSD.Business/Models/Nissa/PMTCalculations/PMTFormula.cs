using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Nissa.PMTCalculations;
/// <summary>
/// Represents a Poverty Means Test (PMT) formula used for eligibility calculations,
/// inheriting audit tracking capabilities from <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class PMTFormula : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the name of the PMT formula.
    /// </summary>
    /// <remarks>
    /// Example: "Urban Household Formula 2023" or "Rural Agricultural Formula"
    /// </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the optional detailed description of the formula.
    /// </summary>
    /// <remarks>
    /// May include calculation methodology or target population details.
    /// </remarks>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the date when this formula becomes effective.
    /// </summary>
    /// <remarks>
    /// Determines when the formula can be used for assessments.
    /// </remarks>
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the settlement type in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Determines which geographic areas (urban/rural/etc.) the formula applies to.
    /// </remarks>
    public int SettlementTypeId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Common statuses: "Draft", "Active", "Archived"
    /// </remarks>
    public int StatusId { get; set; }
    public virtual ICollection<PMTFormulaCoefficient> PMTFormulaCoefficients { get; set; } = new List<PMTFormulaCoefficient>();

}
