using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// CRVSValidation - Stores header information of CRVS validation payload responses for each household member
/// </summary>
public class CRVSValidation : BaseAuditableEntity<int>
{
    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: CRVSValidation → HouseholdMember (Many-to-One, Mandatory)
    /// Links this CRVS validation record to the household member it validates
    /// </summary>
    public int HouseholdMemberId { get; set; }
    public HouseholdMember HouseholdMember { get; set; }

    /// <summary>
    /// Required relationship: CRVSValidation → SystemCodeDetail (Many-to-One, Mandatory)
    /// Status of the CRVS validation process (e.g., Validated, Failed, Pending)
    /// </summary>
    public int ValidationStatusId { get; set; }
    public virtual SystemCodeDetail ValidationStatus { get; set; }

    // CRVS Response Data
    public string FullNamesReturned { get; set; }
    public DateTime? DOBReturned { get; set; }
    public string PlaceBornReturned { get; set; }
    public string GenderReturned { get; set; }
}
