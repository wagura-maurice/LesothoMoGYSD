using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// HHLivingConditions - Stores header information on household living conditions captured during household enumeration
/// </summary>
public class HHLivingCondition : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string GUId { get; set; }

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: HHLivingConditions → Household (Many-to-One, Mandatory)
    /// Links this living conditions record to the household it belongs to
    /// </summary>
    public int HouseholdId { get; set; }
    public virtual Household Household { get; set; }

    /// <summary>
    /// Required relationship: HHLivingConditions → SystemCodeDetail (Many-to-One, Mandatory)
    /// Type of cooking fuel used by the household
    /// </summary>
    public int CookingFuelId { get; set; }
    public virtual SystemCodeDetail CookingFuel { get; set; }

    /// <summary>
    /// Required relationship: HHLivingConditions → SystemCodeDetail (Many-to-One, Mandatory)
    /// Type of heating fuel used by the household
    /// </summary>
    public int HeatingFuelId { get; set; }
    public virtual SystemCodeDetail HeatingFuel { get; set; }

    // Living Conditions Details
    public string OtherCookingFuel { get; set; }
    public string OtherHeatingFuel { get; set; }

    // Navigation properties for audit fields (IDs inherited from BaseAuditableEntity)
    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser ModifiedBy { get; set; }
}