using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// HHDwellingCharacteristics - Stores header information on household dwelling characteristics details captured during household enumeration
/// </summary>
public class HHDwellingCharacteristic : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string GUId { get; set; }

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: HHDwellingCharacteristics → Household (Many-to-One, Mandatory)
    /// Links this dwelling characteristics record to the household it belongs to
    /// </summary>
    public int HouseholdId { get; set; }
    public virtual Household Household { get; set; }

    /// <summary>
    /// Required relationship: HHDwellingCharacteristics → SystemCodeDetail (Many-to-One, Mandatory)
    /// Type of roof material used in the dwelling
    /// </summary>
    public int RoofMaterialId { get; set; }
    public virtual SystemCodeDetail RoofMaterial { get; set; }

    /// <summary>
    /// Required relationship: HHDwellingCharacteristics → SystemCodeDetail (Many-to-One, Mandatory)
    /// Type of floor material used in the dwelling
    /// </summary>
    public int FloorMaterialId { get; set; }
    public virtual SystemCodeDetail FloorMaterial { get; set; }

    /// <summary>
    /// Required relationship: HHDwellingCharacteristics → SystemCodeDetail (Many-to-One, Mandatory)
    /// Type of toilet facility available to the household
    /// </summary>
    public int ToiletTypeId { get; set; }
    public virtual SystemCodeDetail ToiletType { get; set; }

    // Dwelling Details
    public string OtherRoofMaterial { get; set; }
    public string OtherFloorMaterial { get; set; }
    public string AvailableRooms { get; set; } = string.Empty;

    // Navigation properties for audit fields (IDs inherited from BaseAuditableEntity)
    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser ModifiedBy { get; set; }
}
