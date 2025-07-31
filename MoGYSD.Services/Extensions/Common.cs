using System.Security.Claims;

namespace MoGYSD.Services.Extensions;

public static class ExtensionMethods
{
    /// <summary>
    /// User ID
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static string GetUserId(this ClaimsPrincipal user)
    {
        if (!user.Identity.IsAuthenticated)
            return null;

        var currentUser = user;
        return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
    }

    public static string GetDisplayName(this ClaimsPrincipal user)
    {
        if (!user.Identity.IsAuthenticated)
            return null;

        var currentUser = user;
        var displayName = currentUser.FindFirstValue("DisplayName");
        return displayName;
    }

    public static string GetCountyId(this ClaimsPrincipal user)
    {
        if (!user.Identity.IsAuthenticated)
            return null;

        var currentUser = user;
        var countyId = currentUser.FindFirstValue("CountyId");
        return countyId;
    }

    public static int? GetPartnerId(this ClaimsPrincipal user)
    {
        if (!user.Identity.IsAuthenticated)
            return null;

        var currentUser = user;
        var id = currentUser.FindFirstValue("PartnerId");
        if (string.IsNullOrEmpty(id))
            return null;
        return int.Parse(id);
    }

    public static string GetRole(this ClaimsPrincipal user)
    {
        if (!user.Identity.IsAuthenticated)
            return null;

        var currentUser = user;
        var displayName = currentUser.FindFirstValue("DisplayName");
        return displayName;
    }
}