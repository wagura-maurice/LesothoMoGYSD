using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Nissa.PMTCalculations;

/// <summary>
/// PMTIndicators - Defines the set of indicators that can be used in PMT formulas
/// </summary>
public class PMTIndicator : BaseAuditableEntity<int>
{
    /// <summary>
    /// Required relationship: PMTIndicators → PMTIndicatorCategories (Many-to-One, Mandatory)
    /// Links this indicator to its category (e.g., Demographics, Assets, Housing)
    /// </summary>
    public int PMTIndicatorCategoryId { get; set; }
    public virtual PMTIndicatorCategory PMTIndicatorCategory { get; set; }

    // Indicator Details
    public string IndicatorName { get; set; }
    public string Description { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: PMTIndicators → PMTFormulaCoefficients
    /// All formula coefficients that use this indicator
    /// </summary>
    public virtual ICollection<PMTFormulaCoefficient> PMTFormulaCoefficients { get; set; } = new List<PMTFormulaCoefficient>();
}
