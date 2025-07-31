using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.Persistence;
using System.Security.Claims;

namespace MoGYSD.Services.Extensions
{
    public class CustomUserClaimsPrincipalFactory(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor,
        ApplicationDbContext context) : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>(userManager, roleManager, optionsAccessor)
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            var role = userRoles.FirstOrDefault();
            var userProfiles = "";
            var accessLevel = string.Empty;
            if (role != null)
            {
                var userRole = _context.Roles.Include(r => r.SystemCodeDetail).Single(i => i.Name == role);
                var userprofiles = _context.RoleProfiles.Where(p => p.RoleId == userRole.Id)
                    .Select(p => p.SystemTask.Parent.Name + ":" + p.SystemTask.Name).ToList();

                foreach (var task in userprofiles)
                {
                    userProfiles += $"|{task?.ToUpper()}";
                }

                accessLevel = userRole.SystemCodeDetail?.Name?.ToUpper();
            }

            identity.AddClaim(new Claim("UserProfile", userProfiles ?? string.Empty));
            identity.AddClaim(new Claim("AccessLevel", accessLevel ?? string.Empty));
            return identity;
        }
    }
}