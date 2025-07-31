namespace MoGYSD.Business.Models.Common;
/// <summary>
/// Base class for all auditable entities in the system, providing common audit tracking properties.
/// Implements both <see cref="IEntity{T}"/> and <see cref="IAuditableEntity"/> interfaces.
/// </summary>
/// <typeparam name="T">The type of the entity's primary key</typeparam>
public class BaseAuditableEntity<T> : IEntity<T>, IAuditableEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public T Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public virtual DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity.
    /// </summary>
    public virtual string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last modified.
    /// </summary>
    /// <remarks>
    /// Null if the entity has never been modified after creation.
    /// </remarks>
    public virtual DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who last modified the entity.
    /// </summary>
    /// <remarks>
    /// Empty if the entity has never been modified after creation.
    /// </remarks>
    public virtual string ModifiedById { get; set; }
}
