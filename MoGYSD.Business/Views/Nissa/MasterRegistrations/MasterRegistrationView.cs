namespace MoGYSD.Business.Views.Nissa.MasterRegistrations;

/// <summary>
/// Represents a view model for Master Registration information.
/// This class contains properties that represent various details of a master registration plan.
/// </summary>
public class MasterRegistrationView
{
    /// <summary>Unique identifier for the master registration.</summary>
    public int Id { get; set; }

    /// <summary>Identifier for the type of data collection.</summary>
    public int DataCollectionTypeId { get; set; }

    /// <summary>Name of the data collection type.</summary>
    public string DataCollectionTypeName { get; set; }

    /// <summary>Identifier for the status of the registration.</summary>
    public int StatusId { get; set; }

    /// <summary>Name of the status.</summary>
    public string StatusName { get; set; }

    /// <summary>Identifier for the type of plan.</summary>
    public int PlanTypeId { get; set; }

    /// <summary>Name of the plan type.</summary>
    public string PlanTypeName { get; set; }

    /// <summary>Identifier for the PMT (Proxy Means Test) formula.</summary>
    public int PMTFormulaId { get; set; }

    /// <summary>Name of the PMT formula.</summary>
    public string PMTFormulaName { get; set; }

    /// <summary>Name of the master plan.</summary>
    public string MasterPlanName { get; set; }

    /// <summary>Description of the master registration.</summary>
    public string Description { get; set; }

    /// <summary>Financial year associated with the registration.</summary>
    public string FinancialYear { get; set; }

    /// <summary>Amount of the approved budget.</summary>
    public decimal ApprovedBudgetAmount { get; set; }

    /// <summary>Estimated number of households (nullable).</summary>
    public int? EstimatedHHs { get; set; }

    /// <summary>Projected start date of the registration (nullable).</summary>
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>Projected end date of the registration (nullable).</summary>
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>Actual start date of the registration (nullable).</summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>Actual end date of the registration (nullable).</summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>Date and time when the record was created.</summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>Identifier of the user who created the record.</summary>
    public string CreatedById { get; set; }

    /// <summary>Name of the user who created the record (nullable).</summary>
    public string CreatedByName { get; set; }

    /// <summary>Email of the user who created the record (nullable).</summary>
    public string CreatedByEmail { get; set; }

    /// <summary>Date and time when the record was last modified (nullable).</summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>Identifier of the user who last modified the record (nullable).</summary>
    public string ModifiedById { get; set; }

    /// <summary>Name of the user who last modified the record (nullable).</summary>
    public string ModifiedByName { get; set; }
    public decimal CategorizationDiscrepancy { get; set; }
    public int CurrencyId { get; set; }

    /// <summary>Currency name associated with the registration.</summary>
    public string CurrencyName { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal? CurrencyAmount { get; set; }
}
