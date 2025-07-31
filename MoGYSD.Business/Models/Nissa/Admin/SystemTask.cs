namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a hierarchical system task or menu item in the application
/// </summary>
public class SystemTask
{
    /// <summary>
    /// Gets or sets the unique identifier for the system task
    /// </summary>
    /// <remarks>
    /// Nullable to support new task creation before persistence
    /// </remarks>
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the parent task identifier for hierarchical relationships
    /// </summary>
    /// <remarks>
    /// Null for root-level tasks
    /// </remarks>
    public int? ParentId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the system task
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="SystemTask"/>
    /// </summary>
    public SystemTask Parent { get; set; }

    /// <summary>
    /// Gets or sets the collection of child tasks in the hierarchy
    /// </summary>
    public ICollection<SystemTask> Children { get; set; }

    /// <summary>
    /// Gets or sets the display order position for the task
    /// </summary>
    /// <remarks>
    /// Used to control sorting/ordering of tasks in menus
    /// </remarks>
    public int OrderNo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this task is a parent container
    /// </summary>
    /// <value>
    /// <c>true</c> if this task contains child tasks; otherwise, <c>false</c>
    /// </value>
    public bool IsParent { get; set; }
}