namespace MoGYSD.ViewModels.Email;

/// <summary>
/// Email template for account action notifications (activation/deactivation)
/// </summary>
public class ActionAccountEmail : EmailGlobal
{
    /// <summary>
    /// Full name or username of the affected user
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Type of action performed (e.g., "activated", "deactivated")
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// Temporary password for the account (if applicable)
    /// </summary>
    public string Password { get; set; }
}
