using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.UserManagement;

public class UserVillageAssignment
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int VillageId { get; set; }
    public Village Village { get; set; }

}

public class UserRegistrationCentreAssignment
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int RegistrationCentreId { get; set; }
    public RegistrationCentre RegistrationCentre { get; set; }

}