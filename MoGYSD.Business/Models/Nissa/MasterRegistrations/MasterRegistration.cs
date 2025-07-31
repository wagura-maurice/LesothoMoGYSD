using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.PMTCalculations;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.MasterRegistrations;
/// <summary>
/// Represents a master registration plan that coordinates large-scale registration initiatives,
/// inheriting audit tracking capabilities from <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class MasterRegistration : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the data collection type in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Examples: "Census", "Survey", "Administrative Data"
    /// </remarks>
    public int DataCollectionTypeId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the data collection type <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail DataCollectionType { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the plan status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Common statuses: "Draft", "Approved", "In Progress", "Completed"
    /// </remarks>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the plan type in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Examples: "National Census", "Targeted Survey", "Pilot Program"
    /// </remarks>
    public int PlanTypeId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the plan type <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail PlanType { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the <see cref="PMTFormula"/> for poverty assessment.
    /// </summary>
    public int PMTFormulaId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="PMTFormula"/>.
    /// </summary>
    public PMTFormula PMTFormula { get; set; }

    /// <summary>
    /// Gets or sets the official name of the master registration plan.
    /// </summary>
    public string MasterPlanName { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the registration plan.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the financial year this registration plan applies to.
    /// </summary>
    public string FinancialYear { get; set; }

    /// <summary>
    /// Gets or sets the total approved budget amount for the registration plan.
    /// </summary>
    public decimal ApprovedBudgetAmount { get; set; }

    /// <summary>
    /// Gets or sets the estimated number of households to be registered.
    /// </summary>
    /// <remarks>
    /// Nullable as estimate may not be available during initial planning.
    /// </remarks>
    public int? EstimatedHHs { get; set; }

    /// <summary>
    /// Gets or sets the planned start date for registration activities.
    /// </summary>
    public DateTime ProjectedStartDate { get; set; }

    /// <summary>
    /// Gets or sets the planned completion date for registration activities.
    /// </summary>
    /// <remarks>
    /// Nullable as end date may depend on preliminary results.
    /// </remarks>
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Gets or sets the actual start date when registration began.
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Gets or sets the actual completion date when registration finished.
    /// </summary>
    /// <remarks>
    /// Will remain null until all registration activities are complete.
    /// </remarks>
    public DateTime? ActualEndDate { get; set; }
    public decimal CategorizationDiscrepancy { get; set; }
    public decimal? CurrencyAmount { get; set; }
    public int? CurrencyId { get; set; }
    public SystemCodeDetail Currency { get; set; }
    public decimal ExchangeRate { get; set; }
    public ApplicationUser CreatedBy { get; set; }
    public ApplicationUser ModifiedBy { get; set; }
}
