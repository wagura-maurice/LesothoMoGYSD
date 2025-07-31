namespace MoGYSD.ViewModels.Nissa.Security;
/// <summary>
/// ViewModel for tracking and recording audit trail/activity log entries
/// </summary>
public class AuditTrailVm
{
    /// <summary>Unique identifier of the user performing the action</summary>
    public string UserId { get; set; }

    /// <summary>Indicates whether the operation was successful</summary>
    public bool WasSuccessful { get; set; }

    /// <summary>Primary key reference for the audited record (optional)</summary>
    public int? Key1 { get; set; }

    /// <summary>Secondary key reference for the audited record (optional)</summary>
    public int? Key2 { get; set; }

    /// <summary>Tertiary key reference for the audited record (optional)</summary>
    public int? Key3 { get; set; }

    /// <summary>Additional key reference for the audited record (optional)</summary>
    public int? Key4 { get; set; }

    /// <summary>Additional key reference for the audited record (optional)</summary>
    public int? Key5 { get; set; }

    /// <summary>Serialized data of the affected record</summary>
    public string Record { get; set; }

    /// <summary>Code identifying the module/right associated with the action</summary>
    public string ModuleRightCode { get; set; }

    /// <summary>Description of the audited action/event</summary>
    public string Description { get; set; } = "";

    /// <summary>Management Information System identifier (optional)</summary>
    public int? MisId { get; set; }

    /// <summary>Device IMEI number for mobile activity tracking (optional)</summary>
    public string IMEI { get; set; } = "";

    /// <summary>Name of the database table affected by the action (optional)</summary>
    public string TableName { get; set; } = "";
}
