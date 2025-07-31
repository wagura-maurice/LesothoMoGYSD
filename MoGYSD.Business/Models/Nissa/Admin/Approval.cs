//using MoGYSD.Business.Models.Missa.Enrolments;

namespace MoGYSD.Business.Models.Nissa.Admin;
/// <summary>
/// Represents an approval record for tracking authorization of system transactions
/// </summary>
public class Approval
{
    /// <summary>
    /// Gets or sets the unique identifier for the approval record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who performed the approval
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the numeric identifier of the transaction being approved
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// Gets or sets the string identifier of the transaction (alternative to TransactionId)
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Gets or sets the type/category of the transaction being approved
    /// </summary>
    /// <remarks>
    /// Examples: "PurchaseOrder", "ExpenseReport", "UserAccessRequest"
    /// </remarks>
    public string TransactionType { get; set; }

    /// <summary>
    /// Gets or sets the current status of the approval
    /// </summary>
    /// <remarks>
    /// Typically references an approval status lookup table (Pending/Approved/Rejected)
    /// </remarks>
    public int StatusId { get; set; }

    /// Gets or sets the foreign key to the associated EnrolmentEvent.
    /// </summary>
    //public int EnrolmentEventId { get; set; }

    ///// <summary>
    ///// Gets or sets the navigation property to the associated EnrolmentEvent.
    ///// </summary>
    //public virtual EnrolmentEvent EnrolmentEvent { get; set; }
    /// <summary>
    /// Gets or sets the timestamp when the approval record was created
    /// </summary>
    public DateTime CreatedOn { get; set; }
}
