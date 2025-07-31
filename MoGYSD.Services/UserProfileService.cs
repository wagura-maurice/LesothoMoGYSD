using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MoGYSD.Services
{
    public class UserProfileService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private ClaimsPrincipal _user;

        public UserProfileService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task InitializeAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            _user = authState.User;
        }

        public string UserProfile => _user?.FindFirst("UserProfile")?.Value ?? string.Empty;
        public string UserId => _user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public string AccessLevel => _user?.FindFirst("AccessLevel")?.Value ?? string.Empty;
        // Optionally expose other claims
        public ClaimsPrincipal User => _user;
    }
}