/// <summary>
/// Generic email view model that encapsulates email content and metadata
/// </summary>
/// <typeparam name="T">Type of the email content being sent</typeparam>
public class EmailViewModel<T>
{
    /// <summary>
    /// Subject line of the email
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Recipient email address(es)
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Templated email content object
    /// </summary>
    public T Email { get; set; }

    /// <summary>
    /// Flag indicating whether the email content is HTML formatted
    /// </summary>
    public bool IsHtml { get; set; } = true;
}

/// <summary>
/// Base class containing common email properties used across all email templates
/// </summary>
public class EmailGlobal
{
    /// <summary>
    /// First name of the email recipient
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// URL link to the web portal
    /// </summary>
    public string PortalLink { get; set; } = string.Empty;

    /// <summary>
    /// Name of the web portal/system
    /// </summary>
    public string PortalName { get; set; } = string.Empty;

    /// <summary>
    /// Email subject line
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Title/heading for the email content
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Recipient email address(es)
    /// </summary>
    public string To { get; set; } = string.Empty;

    /// <summary>
    /// Display name of the email sender
    /// </summary>
    public string FromName { get; set; } = string.Empty;
}