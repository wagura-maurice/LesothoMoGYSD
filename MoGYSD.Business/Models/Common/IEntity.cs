namespace MoGYSD.Business.Models.Common;

/// <summary>
/// Marker interface indicating that an object is an entity in the domain model.
/// </summary>
/// <remarks>
/// Used to identify domain entities and provide a common base type
/// for entity-related operations. Prefer <see cref="IEntity{T}"/> for
/// entities that need to expose their primary key.
/// </remarks>
public interface IEntity
{
}

/// <summary>
/// Generic interface for entities with a strongly-typed primary key.
/// Inherits from the non-generic <see cref="IEntity"/> marker interface.
/// </summary>
/// <typeparam name="T">The type of the entity's primary key</typeparam>
/// <remarks>
/// This interface should be implemented by all domain entities
/// that need to expose their identifier property. Common key types
/// include <see cref="int"/>, <see cref="string"/>, or <see cref="Guid"/>.
/// </remarks>
public interface IEntity<T> : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    /// <value>
    /// The primary key value of the entity. The actual type is determined
    /// by the generic type parameter T.
    /// </value>
    T Id { get; set; }
}