using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// HHAsset - Stores assets owned by the household captured during household enumeration
/// </summary>
public class HouseholdAsset : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string GUId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Required relationship: HouseholdAsset → Household (Many-to-One, Mandatory)
    /// Links this asset record to the household that owns these assets
    /// </summary>
    public int HouseholdId { get; set; }
    public virtual Household Household { get; set; }

    // Household Asset Quantities
    public int ElectricGasStove { get; set; }
    public int Radio { get; set; }
    public int Television { get; set; }
    public int Fridge { get; set; }
    public int Bicycle { get; set; }
    public int CarTruck { get; set; }
    public int BatteryGenerator { get; set; }
    public int AnimalCart { get; set; }
    public int SewingMachine { get; set; }
    public int SatelliteDish { get; set; }
    public int Cattle { get; set; }
    public int Donkeys { get; set; }
    public int Horses { get; set; }
    public int Sheep { get; set; }
    public int Goats { get; set; }
    public int Pigs { get; set; }
    public int Poultry { get; set; }
}
