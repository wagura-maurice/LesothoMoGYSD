using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.HouseHoldListings;
public class HHListing : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string Guid { get; set; }

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: HHListings → HHListingPlan (Many-to-One, Mandatory)
    /// Links this household listing to the listing plan it was created under
    /// </summary>
    public int HHListingPlanId { get; set; }
    public virtual HHListingPlan HHListingPlan { get; set; }

    /// <summary>
    /// Required relationship: HHListings → Village (Many-to-One, Mandatory)
    /// Identifies the village where this household is located
    /// </summary>
    public int VillageId { get; set; }
    public virtual Village Village { get; set; }

    /// <summary>
    /// Required relationship: HHListings → SystemCodeDetail (Many-to-One, Mandatory)
    /// Tracks the current status of the household listing (e.g., Active, Inactive, Verified)
    /// </summary>
    public int StatusId { get; set; }
    public virtual SystemCodeDetail Status { get; set; }

    // Household Head Information
    public string HHHeadFirstName { get; set; }
    public string HHHeadMiddleName { get; set; }
    public string HHHeadSurname { get; set; }
    public string NationalId { get; set; } 
    public string NationalIDPhoto { get; set; }

    // Household Details
    public int HHSize { get; set; }
    public string GeoCoordinates { get; set; }
    public string PhysicalAddress { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: HHListings → CbcCategorization
    /// All CBC categorizations assigned to this household
    /// </summary>
    public virtual ICollection<CbcCategorization> CbcCategorizations { get; set; } = new List<CbcCategorization>();
}
