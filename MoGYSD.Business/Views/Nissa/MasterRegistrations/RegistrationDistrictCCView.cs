namespace MoGYSD.Business.Views.Nissa.MasterRegistrations;

/// <summary>
/// Represents a view model for Registration District Community Council information.
/// This class contains properties related to community council-specific registration details
/// within a district registration.
/// </summary>
public class RegistrationDistrictCCView
{
    /// <summary>Unique identifier for the community council registration record.</summary>
    public int Id { get; set; }

    /// <summary>Identifier of the parent district registration record.</summary>
    public int RegistrationDistrictId { get; set; }

    /// <summary>Identifier of the community council.</summary>
    public int CCId { get; set; }

    /// <summary>Name of the community council.</summary>
    public string CommunityCouncilName { get; set; }

    /// <summary>Projected number of households in the community council.</summary>
    public int ProjectedHHs { get; set; }
    public int TotalHHsToTarget { get; set; }
    public int DistrictId { get; set; }

    /// <summary>Date and time when the record was created.</summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>Identifier of the user who created the record.</summary>
    public string CreatedById { get; set; }

    /// <summary>Name of the user who created the record (nullable).</summary>
    public string CreatedByName { get; set; }

    /// <summary>Date and time when the record was last modified (nullable).</summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>Identifier of the user who last modified the record.</summary>
    public string ModifiedById { get; set; }

    /// <summary>Name of the user who last modified the record (nullable).</summary>
    public string ModifiedByName { get; set; }
    public string MasterPlanName { get; set; }
    /// <summary>Identifier for the status of the registration.</summary>
    public int StatusId { get; set; }

    /// <summary>Name of the status.</summary>
    public string StatusName { get; set; }
    /// <summary>Projected start date of the registration (nullable).</summary>
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>Projected end date of the registration (nullable).</summary>
    public DateTime? ProjectedEndDate { get; set; }
    /// <summary>Projected start date of the registration (nullable).</summary>
    public DateTime? DistrictProjectedStartDate { get; set; }

    /// <summary>Projected end date of the registration (nullable).</summary>
    public DateTime? DistrictProjectedEndDate { get; set; }
}