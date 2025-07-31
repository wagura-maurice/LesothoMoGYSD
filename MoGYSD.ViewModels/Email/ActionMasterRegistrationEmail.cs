namespace MoGYSD.ViewModels.Email;

/// <summary>
/// Email template for master registration plan notifications
/// </summary>
public class ActionMasterRegistrationEmail : EmailGlobal
{
    /// <summary>
    /// Name of the master registration plan
    /// </summary>
    public string MasterPlanName { get; set; } = string.Empty;

    /// <summary>
    /// Type of action performed (e.g., "created", "approved", "rejected")
    /// </summary>
    public string Action { get; set; }

    public string Message { get; set; } = string.Empty;
}
