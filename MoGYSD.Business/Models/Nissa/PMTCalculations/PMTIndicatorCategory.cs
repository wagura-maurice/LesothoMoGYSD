using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Nissa.PMTCalculations;

/// <summary>
/// PMTIndicatorCategories - Stores categories of PMT indicators
/// </summary>
public class PMTIndicatorCategory : BaseAuditableEntity<int>
{
    // Category Details
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: PMTIndicatorCategories → PMTIndicators
    /// All PMT indicators belonging to this category
    /// </summary>
    public virtual ICollection<PMTIndicator> PMTIndicators { get; set; } = new List<PMTIndicator>();
}
