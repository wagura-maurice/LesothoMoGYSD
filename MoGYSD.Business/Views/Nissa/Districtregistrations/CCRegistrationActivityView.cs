using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Views.Nissa.Districtregistrations;

/// <summary>
/// Represents a detailed view of community council registration activities including
/// partner collaborations, contact information, and household impact metrics.
/// </summary>
public class CCRegistrationActivityView
{
    /// <summary>
    /// Gets or sets the unique identifier for the registration activity.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the foreign key reference to the district registration plan.
    /// </summary>
    public int DistrictRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the name of the associated district registration plan.
    /// </summary>
    public string DistrictRegistrationPlanName { get; set; } = null;

    /// <summary>
    /// Gets or sets the foreign key reference to the community council.
    /// </summary>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets the name of the registered community council.
    /// </summary>
    public string CommunityCouncilName { get; set; } = null;

    /// <summary>
    /// Gets or sets the foreign key reference to the community council registration.
    /// </summary>
    public int CCsRegisteredId { get; set; }

    /// <summary>
    /// Gets or sets the name of the associated registered community council.
    /// </summary>
    public string CCsRegisteredName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the activity type.
    /// </summary>
    public int ActivityId { get; set; }

    /// <summary>
    /// Gets or sets the name of the activity type (e.g., "Census", "Survey").
    /// </summary>
    public string ActivityName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the activity status.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the name of the activity status (e.g., "Completed", "In Progress").
    /// </summary>
    public string StatusName { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the registration activity.
    /// </summary>
    public string ActivityDescription { get; set; }

    /// <summary>
    /// Gets or sets the number of households impacted by this activity.
    /// </summary>
    public int NumberOfHouseholds { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the collaborating partner.
    /// </summary>
    public int PartnersId { get; set; }

    /// <summary>
    /// Gets or sets the name of the collaborating partner organization.
    /// </summary>
    public string PartnersName { get; set; }
    public string OrgTypeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the foreign key reference to the partner contact person.
    /// </summary>
    public int ContactPersonId { get; set; }

    /// <summary>
    /// Gets or sets the name of the partner contact person.
    /// </summary>
    public string ContactPersonName { get; set; }

    /// <summary>
    /// Gets or sets the email of the partner contact person.
    /// </summary>
    public string ContactPersonEmail { get; set; }
    public DateTime ProjectedStartDate { get; set; }
    public DateTime ProjectedEndDate { get; set; }
    public string DocumentsJson { get; set; }
    /// <summary>
    /// Gets or sets the date and time when the activity was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this activity.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this activity.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the activity was last modified.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this activity.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this activity.
    /// </summary>
    public string ModifiedByName { get; set; }
    public bool IsRequired { get; set; }
    [NotMapped]
    public bool IsSelected { get; set; }

}

public class CCRegistrationActivityGroupView
{
    /// <summary>
    /// Gets or sets the foreign key reference to the community council.
    /// </summary>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets the name of the registered community council.
    /// </summary>
    public string CommunityCouncilName { get; set; } = null;
    public int NumberOfHouseholds { get; set; }

    public int NumberOfActiveActivities { get; set; }
    public int NumberOfNotActiveActivities { get; set; }
    public string DistrictName { get; set; } = null;


}
