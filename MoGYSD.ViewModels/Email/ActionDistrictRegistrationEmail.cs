namespace MoGYSD.ViewModels.Email;

/// <summary>
/// Email template for district registration notifications
/// </summary>
public class ActionDistrictRegistrationEmail : EmailGlobal
{
    /// <summary>
    /// Name of the district plan
    /// </summary>
    public string DistrctPlanName { get; set; } = string.Empty;

    /// <summary>
    /// Type of action performed (e.g., "created", "approved", "rejected")
    /// </summary>
    public string Action { get; set; }
    public string Message { get; set; } = string.Empty;
}