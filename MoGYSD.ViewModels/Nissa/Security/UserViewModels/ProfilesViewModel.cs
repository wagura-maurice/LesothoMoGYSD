using MoGYSD.Business.Models.Nissa.Admin;
using System.ComponentModel;

namespace MoGYSD.ViewModels.Nissa.Security.UserViewModels;

/// <summary>
/// ViewModel for managing user profile assignments and permissions
/// </summary>
public class ProfilesViewModel
{
    /// <summary>
    /// Collection of system tasks available for assignment
    /// </summary>
    public ICollection<SystemTask> SystemTasks { get; set; }

    /// <summary>
    /// Array of selected task IDs for profile assignment
    /// </summary>
    public int[] Ids { get; set; }

    /// <summary>
    /// The user group/role identifier for profile association
    /// </summary>
    [DisplayName("User Group")]
    public string RoleId { get; set; }

    /// <summary>
    /// Collection of existing role profile IDs associated with the user
    /// </summary>
    public ICollection<int> RoleProfileIds { get; set; }
}