using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Nissa.PMTCalculations;

/// <summary>
/// PMTFormulaCoefficients - Stores PMT weights for each indicator in a formula
/// </summary>
public class PMTFormulaCoefficient : BaseAuditableEntity<int>
{
    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: PMTFormulaCoefficients → PMTFormula (Many-to-One, Mandatory)
    /// Links this coefficient to the PMT formula it belongs to
    /// </summary>
    public int PMTFormulaId { get; set; }
    public virtual PMTFormula PMTFormula { get; set; }

    /// <summary>
    /// Required relationship: PMTFormulaCoefficients → PMTIndicators (Many-to-One, Mandatory)
    /// Links this coefficient to the indicator being weighted
    /// </summary>
    public int PMTIndicatorId { get; set; }
    public virtual PMTIndicator PMTIndicator { get; set; }

    // Coefficient Details
    public decimal Coefficient { get; set; }
    public bool IsIntercept { get; set; }
    public string Comment { get; set; }
}
