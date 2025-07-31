namespace MoGYSD.Business.Views.Nissa.MasterRegistrations;

/// <summary>
/// Represents a view model for Registration District information.
/// This class contains properties related to district-specific registration details.
/// </summary>
public class RegistrationDistrictView
{
    /// <summary>Unique identifier for the district registration.</summary>
    public int Id { get; set; }

    /// <summary>Identifier of the master registration plan this district belongs to.</summary>
    public int MasterRegistrationPlanId { get; set; }

    /// <summary>Identifier of the district.</summary>
    public int DistrictId { get; set; }

    /// <summary>Current population of the district.</summary>
    public int CurrentPopulation { get; set; }
    /// <summary>Estimated population of the district.</summary>
    public int EstimatedPopulation { get; set; }

    /// <summary>Prior coverage information for the district.</summary>
    public int PriorCoverage { get; set; }
    /// <summary>Current coverage information for the district.</summary>
    public int CurrentCoverage { get; set; }

    /// <summary>Total number of households to target in the district.</summary>
    public int TotalHHsToTarget { get; set; }
    /// <summary>Total number of Population to target in the district.</summary>
    public int TotalPopulationToTarget { get; set; }

    /// <summary>Date and time when the record was created.</summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>Identifier of the user who created the record.</summary>
    public string CreatedById { get; set; }

    /// <summary>Date and time when the record was last modified (nullable).</summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>Identifier of the user who last modified the record (nullable).</summary>
    public string ModifiedById { get; set; }

    /// <summary>Name of the user who created the record (nullable).</summary>
    public string CreatedByName { get; set; }

    /// <summary>Name of the user who last modified the record (nullable).</summary>
    public string ModifiedByName { get; set; }

    /// <summary>Name of the district.</summary>
    public string DistrictName { get; set; }

    /// <summary>Name of the master plan associated with this district registration.</summary>
    public string MasterPlanName { get; set; }
    /// <summary>Identifier for the status of the registration.</summary>
    public int StatusId { get; set; }

    /// <summary>Name of the status.</summary>
    public string StatusName { get; set; }
    /// <summary>Projected start date of the registration (nullable).</summary>
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>Projected end date of the registration (nullable).</summary>
    public DateTime? ProjectedEndDate { get; set; }
}