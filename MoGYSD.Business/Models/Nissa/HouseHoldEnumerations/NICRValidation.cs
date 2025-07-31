using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// NICRValidation - Stores header information of NICR validation payload responses for each household member
/// </summary>
public class NICRValidation : BaseAuditableEntity<int>
{
    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: NICRValidation → HouseholdMember (Many-to-One, Mandatory)
    /// Links this NICR validation record to the household member it validates
    /// </summary>
    public int HouseholdMemberId { get; set; }
    public virtual HouseholdMember HouseholdMember { get; set; }

    /// <summary>
    /// Required relationship: NICRValidation → SystemCodeDetail (Many-to-One, Mandatory)
    /// Status of the NICR validation process (e.g., Validated, Failed, Pending)
    /// </summary>
    public int ValidationStatusId { get; set; }
    public virtual SystemCodeDetail ValidationStatus { get; set; }

    // NICR Response Data
    public string FullNamesReturned { get; set; }
    public DateTime? DOBReturned { get; set; }
    public string PlaceBornReturned { get; set; }
    public string SexReturned { get; set; }
}
public class PersonResponse
{
    public string IDNumber { get; set; }
    public string Status { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public string BirthDate { get; set; }
    public string DeathDate { get; set; }
    public string PlaceOfBirth { get; set; }
    public string MaritalStatus { get; set; }
    public string Nationality { get; set; }
    public string NationalityCode { get; set; }
    public string IDCollected { get; set; }
    public string BirthCertNumber { get; set; }
    public string DistrictCode { get; set; }
    public string District { get; set; }
    public string CellPhoneNumber { get; set; }
    public string Email { get; set; }
}
