using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.UserManagement;

public class UserCommunityCouncilAssignment
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int CommunityCouncilId { get; set; }
    public CommunityCouncil CommunityCouncil { get; set; }

}
