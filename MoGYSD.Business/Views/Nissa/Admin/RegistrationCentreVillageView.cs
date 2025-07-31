using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Views.Nissa.Admin;

public class RegistrationCentreVillageView
{
    public int? Id { get; set; }
    public int? RegistrationCentreId { get; set; }
    public string RegistrationCentreName { get; set; }
    public string RegistrationCentreCode { get; set; }
    public bool RegistrationCentreIsActive { get; set; }
    public int VillageId { get; set; }
    public string VillageName { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int CommunityCouncilId { get; set; }
    public string CommunityCouncilName { get; set; }
    public int? ConstituencyId { get; set; }
    public string ConstituencyName { get; set; }
    /// <summary>
    /// Gets or sets the user ID of the assigned supervisor.
    /// </summary>
    public string SupervisorId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the assigned supervisor.
    /// </summary>
    /// <remarks>
    /// Format: "FirstName LastName" from associated user profile.
    /// </remarks>
    public string SupervisorName { get; set; }
    /// <summary>
    /// Gets or sets the ID of the user who created this registration center record.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this registration center record.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this registration center record.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this registration center record.
    /// </summary>
    public string ModifiedByName { get; set; }
    [NotMapped]
    public int TotalVillages { get; set; }
}