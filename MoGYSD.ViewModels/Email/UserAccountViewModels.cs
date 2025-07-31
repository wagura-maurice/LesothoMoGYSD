namespace MoGYSD.ViewModels.Email;
/// <summary>
/// Email template for account confirmation notifications
/// </summary>
public class ConfirmationEmail : EmailGlobal
{
    /// <summary>
    /// URL link for the user to confirm their account
    /// </summary>
    public string ConfirmationLink { get; set; }

    /// <summary>
    /// Full name or username of the recipient
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Temporary password for the account (if applicable)
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Download link for the mobile application
    /// </summary>
    public string MobileAppLink { get; set; }
}

public class ResetPasswordEmail : EmailGlobal
{
    /// <summary>
    /// URL link for the user to confirm their account
    /// </summary>
    public string ResetPasswordLink { get; set; }
}