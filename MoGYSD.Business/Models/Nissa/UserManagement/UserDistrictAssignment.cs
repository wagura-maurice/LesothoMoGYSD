using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.UserManagement;

public class UserDistrictAssignment
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int DistrictId { get; set; }
    public District District { get; set; }

}
