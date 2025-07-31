using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

namespace MoGYSD.Business.Models.Nissa.PMTCalculations;

/// <summary>
/// HHPMT - Stores PMT scores of each household
/// </summary>
public class HHPMT : BaseAuditableEntity<int>
{
    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: HHPMT → Household (Many-to-One, Mandatory)
    /// Links this PMT score to the household it was calculated for
    /// </summary>
    public int HouseholdId { get; set; }
    public virtual Household Household { get; set; }

    /// <summary>
    /// Required relationship: HHPMT → PMTFormula (Many-to-One, Mandatory)
    /// Links this PMT score to the formula used for calculation
    /// </summary>
    public int PMTFormulaId { get; set; }
    public virtual PMTFormula PMTFormula { get; set; }

    /// <summary>
    /// Required relationship: HHPMT → SystemCodeDetail (Many-to-One, Mandatory)
    /// Classification threshold this PMT score falls into (e.g., Poor, Non-Poor, Vulnerable)
    /// </summary>
    public int PMTClassificationThreshhldsId { get; set; }
    public virtual SystemCodeDetail PMTClassificationThreshhlds { get; set; }

    // PMT Score Details
    public decimal PMT_Score { get; set; }
    public DateTime DatePMTGenerated { get; set; }
    public int Status { get; set; }
}
