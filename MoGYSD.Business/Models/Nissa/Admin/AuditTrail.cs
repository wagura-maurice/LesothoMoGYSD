using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents an audit trail record tracking changes to system entities
/// </summary>
public class AuditTrail
{
    /// <summary>
    /// Gets or sets the unique identifier for the audit record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who made the change
    /// </summary>
    [DisplayName("User")]
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the change occurred
    /// </summary>
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm }")]
    [DisplayName("Date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the adjusted timestamp (UTC+3) for display purposes
    /// </summary>
    public DateTime DateNow => Date.AddHours(3);

    /// <summary>
    /// Gets or sets the user agent/browser information from the request
    /// </summary>
    [DisplayName("User Agent")]
    public string UserAgent { get; set; }

    /// <summary>
    /// Gets or sets the IP address from which the change was made
    /// </summary>
    [DisplayName("Request Ip Address")]
    public string RequestIpAddress { get; set; }

    /// <summary>
    /// Gets or sets the type of change (Create/Update/Delete)
    /// </summary>
    [DisplayName("Change Type")]
    public string ChangeType { get; set; }

    /// <summary>
    /// Gets or sets the name of the database table that was modified
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// Gets or sets the primary key of the affected record
    /// </summary>
    [DisplayName("Record Id")]
    public string RecordId { get; set; }

    /// <summary>
    /// Gets or sets the JSON representation of the record before changes
    /// </summary>
    [DisplayName("Old Value")]
    public string OldValue { get; set; }

    /// <summary>
    /// Gets or sets the JSON representation of the record after changes
    /// </summary>
    [DisplayName("New Record")]
    public string NewValue { get; set; }

    /// <summary>
    /// Gets or sets the name of the computer where the change originated
    /// </summary>
    [DisplayName("PC Name")]
    public string PcName { get; set; }

    /// <summary>
    /// Gets or sets a human-readable description of the change
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the user who made the change
    /// </summary>
    public ApplicationUser User { get; set; }
}