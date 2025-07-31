using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a junction entity between roles and system tasks, defining task permissions for roles
/// </summary>
public class RoleProfile
{
    /// <summary>
    /// Gets or sets the foreign key to the <see cref="SystemTask"/> entity (part of composite key)
    /// </summary>
    /// <remarks>
    /// Nullable to support optional task assignments
    /// </remarks>
    [Key, Column(Order = 1)]
    public int? TaskId { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the Role entity (part of composite key)
    /// </summary>
    /// <remarks>
    /// References the application role this permission applies to
    /// </remarks>
    [Key, Column(Order = 2)]
    public string RoleId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="SystemTask"/>
    /// </summary>
    [ForeignKey("TaskId")]
    public SystemTask SystemTask { get; set; }
}
