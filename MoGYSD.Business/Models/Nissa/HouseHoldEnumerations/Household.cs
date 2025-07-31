using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.HouseHoldListings;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// Household - Stores household information captured during household enumeration
/// </summary>
public class Household : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string GUId { get; set; }

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: Household → HHEnumerationPlan (Many-to-One, Mandatory)
    /// Links this household to the enumeration plan under which it was enumerated
    /// </summary>
    public int HHEnumerationPlanId { get; set; }
    public virtual HHEnumerationPlan HHEnumerationPlan { get; set; }

    /// <summary>
    /// Required relationship: Household → HHListings (Many-to-One, Mandatory)
    /// Links this household to its original listing record
    /// </summary>
    public int HHListingId { get; set; }
    public virtual HHListing HHListing { get; set; }

    /// <summary>
    /// Required relationship: Household → Village (Many-to-One, Mandatory)
    /// Identifies the village where this household is located
    /// </summary>
    public int VillageId { get; set; }
    public virtual Village Village { get; set; }

    /// <summary>
    /// Required relationship: Household → SystemCodeDetail (Many-to-One, Mandatory)
    /// Tracks the current status of the household enumeration
    /// </summary>
    public int StatusId { get; set; }
    public virtual SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Required relationship: Household → SystemCodeDetail (Many-to-One, Mandatory)
    /// Status of community validation process for this household
    /// </summary>
    public int CommunityValidationStatusId { get; set; }
    public virtual SystemCodeDetail CommunityValidationStatus { get; set; }

    /// <summary>
    /// Required relationship: Household → SystemCodeDetail (Many-to-One, Mandatory)
    /// Status of final validation process for this household
    /// </summary>
    public int FinalValidationStatusId { get; set; }
    public virtual SystemCodeDetail FinalValidationStatus { get; set; }

    /// <summary>
    /// Required relationship: Household → SystemCodeDetail (Many-to-One, Mandatory)
    /// Result of the enumeration visit (e.g., Completed, Incomplete, Refused)
    /// </summary>
    public int EnumerationVisitResultId { get; set; }
    public virtual SystemCodeDetail EnumerationVisitStatus { get; set; }

    /// <summary>
    /// Required relationship: Household → SystemCodeDetail (Many-to-One, Mandatory)
    /// Agricultural services accessed by this household
    /// </summary>
    public int AgriculturalServicesId { get; set; }
    public virtual SystemCodeDetail AgriculturalService { get; set; }

    // Household Details
    public string GeoCoordinates { get; set; }
    public string PhysicalAddress { get; set; }
    public string OtherAgriculturalServices { get; set; }
    public bool HHRecieivingInKindSupport { get; set; }
    public string InKindSupportProgramme { get; set; }
    public string PovertyStatus { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: Household → HouseholdMember
    /// All members belonging to this household
    /// </summary>
    public virtual ICollection<HouseholdMember> HouseholdMembers { get; set; } = new List<HouseholdMember>();

    /// <summary>
    /// One-to-Many: Household → HHLivingConditions
    /// Living conditions data for this household
    /// </summary>
    public virtual ICollection<HHLivingCondition> HHLivingConditions { get; set; } = new List<HHLivingCondition>();

    /// <summary>
    /// One-to-Many: Household → HHDwellingCharacteristics
    /// Dwelling characteristics data for this household
    /// </summary>
    public virtual ICollection<HHDwellingCharacteristic> HHDwellingCharacteristics { get; set; } = new List<HHDwellingCharacteristic>();

    /// <summary>
    /// One-to-Many: Household → HouseholdAsset
    /// Assets owned by this household
    /// </summary>
    public virtual ICollection<HouseholdAsset> HouseholdAssets { get; set; } = new List<HouseholdAsset>();

    /// <summary>
    /// One-to-Many: Household → HHFoodSecurityVulnerability
    /// Food security and vulnerability data for this household
    /// </summary>
    public virtual ICollection<HHFoodSecurityVulnerability> HHFoodSecurityVulnerabilities { get; set; } = new List<HHFoodSecurityVulnerability>();
    // <summary>
    // One-to-Many: Household → Enrolments
    // All enrolments associated with this household.
    // </summary>
    public virtual ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();

    /// <summary>
    /// One-to-Many: Household → EnrolmentEventDetail
    /// All enrolment event details associated with this household.
    /// </summary>
    public virtual ICollection<EnrolmentEventDetail> EnrolmentEventDetails { get; set; } = new List<EnrolmentEventDetail>();
}
