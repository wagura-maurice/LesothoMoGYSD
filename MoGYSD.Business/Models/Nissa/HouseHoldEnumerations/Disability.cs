using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// Disability - Stores details of disability status of each household member
/// </summary>
public class Disability : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string GUId { get; set; }

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: Disability → HouseholdMember (Many-to-One, Mandatory)
    /// Links this disability record to the household member it belongs to
    /// </summary>
    public int HouseholdMemberId { get; set; }
    public virtual HouseholdMember HouseholdMember { get; set; }

    // Vision-related disabilities
    /// <summary>
    /// Required relationship: Disability → SystemCodeDetail (Many-to-One, Mandatory)
    /// Level of difficulty seeing without glasses/aids
    /// </summary>
    public int DifficultySeeingIdId { get; set; }
    public virtual SystemCodeDetail DifficultySeeingDetails { get; set; }

    public bool MemberUsesGlasses { get; set; }

    /// <summary>
    /// Optional relationship: Disability → SystemCodeDetail (Many-to-One, Optional)
    /// Level of difficulty seeing with glasses (if applicable)
    /// </summary>
    public int? DifficultySeeingWGlassesId { get; set; }
    public virtual SystemCodeDetail DifficultySeeingWGlassesDetails { get; set; }

    // Hearing-related disabilities
    /// <summary>
    /// Required relationship: Disability → SystemCodeDetail (Many-to-One, Mandatory)
    /// Level of difficulty hearing without aids
    /// </summary>
    public int DifficultyHearingId { get; set; }
    public virtual SystemCodeDetail DifficultyHearingDetails { get; set; }

    public bool HasHearingAids { get; set; }

    /// <summary>
    /// Optional relationship: Disability → SystemCodeDetail (Many-to-One, Optional)
    /// Level of difficulty hearing with aids (if applicable)
    /// </summary>
    public int? DifficultyHearingWAidsId { get; set; }
    public virtual SystemCodeDetail DifficultyHearingWAidsDetails { get; set; }

    // Other disabilities
    /// <summary>
    /// Required relationship: Disability → SystemCodeDetail (Many-to-One, Mandatory)
    /// Level of difficulty walking or climbing steps
    /// </summary>
    public int DifficultyWalkingId { get; set; }
    public virtual SystemCodeDetail DifficultyWalkingDetails { get; set; }

    /// <summary>
    /// Required relationship: Disability → SystemCodeDetail (Many-to-One, Mandatory)
    /// Level of difficulty remembering or concentrating
    /// </summary>
    public int DifficultyRememberingId { get; set; }
    public virtual SystemCodeDetail DifficultyRememberingDetails { get; set; }

    /// <summary>
    /// Required relationship: Disability → SystemCodeDetail (Many-to-One, Mandatory)
    /// Level of difficulty with self-care activities
    /// </summary>
    public int DifficultySelfcareId { get; set; }
    public virtual SystemCodeDetail DifficultySelfcareDetails { get; set; }

    /// <summary>
    /// Required relationship: Disability → SystemCodeDetail (Many-to-One, Mandatory)
    /// Level of difficulty communicating or being understood
    /// </summary>
    public int DifficultyCommunicatingId { get; set; }
    public virtual SystemCodeDetail DifficultyCommunicatingDetails { get; set; }

    // Navigation properties for audit fields (IDs inherited from BaseAuditableEntity)
    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser ModifiedBy { get; set; }
}
