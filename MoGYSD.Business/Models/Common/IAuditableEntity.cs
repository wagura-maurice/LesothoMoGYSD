namespace MoGYSD.Business.Models.Common;

/// <summary>
/// Interface defining the standard audit trail properties for trackable entities
/// </summary>
/// <remarks>
/// Implement this interface to enable automatic tracking of creation and modification
/// timestamps and user references for all entities in the system.
/// </remarks>
public interface IAuditableEntity
{
    /// <summary>
    /// Gets or sets the UTC date and time when the entity was created
    /// </summary>
    DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity
    /// </summary>
    /// <remarks>
    /// Typically stores the user ID or username of the creator
    /// </remarks>
    string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the entity was last modified
    /// </summary>
    /// <remarks>
    /// Will be null if the entity has never been modified after creation
    /// </remarks>
    DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who last modified the entity
    /// </summary>
    /// <remarks>
    /// Will be empty/null if the entity has never been modified after creation
    /// </remarks>
    string ModifiedById { get; set; }
}
