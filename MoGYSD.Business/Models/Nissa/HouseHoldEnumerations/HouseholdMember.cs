using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;

/// <summary>
/// HouseholdMembers - Stores information of each household member captured during household enumeration
/// </summary>
public class HouseholdMember : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string GUId { get; set; }

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: HouseholdMember → Household (Many-to-One, Mandatory)
    /// Links this member to the household they belong to
    /// </summary>
    public int HouseholdId { get; set; }
    public virtual Household Household { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Type of household member (e.g., Head, Spouse, Child, Other)
    /// </summary>
    public int HHMemberTypeId { get; set; }
    public virtual SystemCodeDetail HHMemberType { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Gender/sex of the household member
    /// </summary>
    public int SexId { get; set; }
    public virtual SystemCodeDetail Sex { get; set; }

    /// <summary>
    /// Optional relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Optional)
    /// Where the member lived previously
    /// </summary>
    public int? WhereMemberLivedId { get; set; }
    public virtual SystemCodeDetail WhereMemberLived { get; set; }

    /// <summary>
    /// Optional relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Optional)
    /// Where the member is currently living
    /// </summary>
    public int? WhereMemberIsLivingId { get; set; }
    public virtual SystemCodeDetail WhereMemberIsLiving { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Main activity/occupation of the household member
    /// </summary>
    public int MainActivityId { get; set; }
    public virtual SystemCodeDetail MainActivity { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Marital status of the household member
    /// </summary>
    public int MaritalStatusId { get; set; }
    public virtual SystemCodeDetail MaritalStatus { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Whether the member is currently attending school
    /// </summary>
    public int IsAttendingSchoolId { get; set; }
    public virtual SystemCodeDetail IsAttendingSchool { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Education level attained by the household member
    /// </summary>
    public int EducationLevelId { get; set; }
    public virtual SystemCodeDetail EducationLevel { get; set; }

    /// <summary>
    /// Optional relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Optional)
    /// Social programme the member is enrolled in
    /// </summary>
    public int? SocialProgrammeId { get; set; }
    public virtual SystemCodeDetail SocialProgramme { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Primary caregiver for this household member
    /// </summary>
    public int CaregiverId { get; set; }
    public virtual SystemCodeDetail Caregiver { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Current school level if attending school
    /// </summary>
    public int SchoolLevelId { get; set; }
    public virtual SystemCodeDetail SchoolLevel { get; set; }

    /// <summary>
    /// Required relationship: HouseholdMember → SystemCodeDetail (Many-to-One, Mandatory)
    /// Current status of this household member record
    /// </summary>
    public int StatusId { get; set; }
    public virtual SystemCodeDetail Status { get; set; }

    // Personal Information
    public string FirstName { get; set; }
    public string OtherName { get; set; }
    public string Surname { get; set; }
    public string AgeYears { get; set; }
    public string AgeMonths { get; set; }
    public DateTime DOB { get; set; }
    public string PhoneNumber { get; set; }
    public string AlternatePhoneNumber { get; set; }
    public string OwnerAlternatePhoneNumber { get; set; }

    // Location and Mobility
    public bool MemberlivedSomewherein12months { get; set; }
    public string MonthsAwayLast12Months { get; set; }
    public bool IsMemberLivingOutsideHH { get; set; }

    // Identity Documentation
    public bool MemberRegisteredHomeAffairs { get; set; }
    public string NationalId { get; set; }
    public string NationalIDSecondCapture { get; set; }
    public string NationalIDPhotograph { get; set; }
    public string IDNumberBirthCertificate { get; set; }

    // Additional Information
    public string OtherActivity { get; set; }
    public bool IsMotherAlive { get; set; }
    public bool IsFatherAlive { get; set; }
    public string OtherSchoolLevel { get; set; }
    public string OtherEducationLevel { get; set; }
    public bool ChronicIllness { get; set; }
    public string OtherSocialProgramme { get; set; }
    public bool IWMPWP { get; set; }
    public bool HasClearanceFromMinistryOfDefence { get; set; }
    // Navigation properties for audit fields (IDs inherited from BaseAuditableEntity)
    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser ModifiedBy { get; set; }

    // Reverse Navigation Properties (One-to-Many relationships):

    /// <summary>
    /// One-to-Many: HouseholdMember → Disability
    /// All disability records for this household member
    /// </summary>
    public virtual ICollection<Disability> Disabilities { get; set; } = new List<Disability>();

    /// <summary>
    /// One-to-Many: HouseholdMember → NICRValidation
    /// All NICR validation records for this household member
    /// </summary>
    public virtual ICollection<NICRValidation> NICRValidations { get; set; } = new List<NICRValidation>();

    /// <summary>
    /// One-to-Many: HouseholdMember → CRVSValidation
    /// All CRVS validation records for this household member
    /// </summary>
    public virtual ICollection<CRVSValidation> CRVSValidations { get; set; } = new List<CRVSValidation>();
    /// <summary>
    /// One-to-Many: HouseholdMember → EnrolmentDetails
    /// All enrolment details associated with this household member.
    /// </summary>
    public virtual ICollection<EnrolmentDetail> EnrolmentDetails { get; set; } = new List<EnrolmentDetail>();
    public virtual ICollection<EnrolmentEventDetail> EnrolmentEventDetails { get; set; } = new List<EnrolmentEventDetail>();
    public virtual ICollection<PaymentDetail> PaymentDetailsAsPayee { get; set; } = new List<PaymentDetail>();
}





