
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace MoGYSD.Services;

public interface IUserService
{
    string? GetCurrentUserId();
    string? GetUserIp();
    string? GetUserName();
    // Remove this only for demo purposes
    string? SystemBeingUsed { get; set; } // This property is not used in the current implementation but can be added for future use.
    Task UpdateSystemPreferenceAsync(string system);
    event Action OnSystemChanged;
}


public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserProfileService _userProfileService;
    private readonly IJSRuntime _jsRuntime;

    private const string SystemCookieKey = "CurrentSystem";
    private const int CookieExpirationDays = 1;
    private string _systemBeingUsed;
    public event Action? OnSystemChanged;

    public UserService(
        IHttpContextAccessor httpContextAccessor,
        UserProfileService userProfileService,
        IJSRuntime jsRuntime)
    {
        _httpContextAccessor = httpContextAccessor;
        _userProfileService = userProfileService;
        _jsRuntime = jsRuntime;

        _systemBeingUsed = _httpContextAccessor.HttpContext?.Request.Cookies[SystemCookieKey] ?? "NISSA";
    }

    public string SystemBeingUsed
    {
        get => _systemBeingUsed;
        set
        {
            if (_systemBeingUsed != value)
            {
                _systemBeingUsed = value;
                OnSystemChanged?.Invoke(); // Trigger UI update

            }
        }
    }

    public async Task UpdateSystemPreferenceAsync(string system)
    {
        _systemBeingUsed = system;

        await SetSystemCookieAsync(system);

        if (IsAuthenticated)
        {
            var userId = _userProfileService.UserId;
            if (!string.IsNullOrEmpty(userId))
            {
                await UpdateUserSystemClaim(userId, system);
            }
        }

        OnSystemChanged?.Invoke();
    }

    private async Task SetSystemCookieAsync(string system)
    {
        await _jsRuntime.InvokeVoidAsync("setCookie", SystemCookieKey, system, CookieExpirationDays);
    }

    private async Task UpdateUserSystemClaim(string userId, string system)
    {
        // Implement logic to persist the system selection to user claims or database.
        await Task.CompletedTask;
    }

    public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public string? GetCurrentUserId() =>
        _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? GetUserName() =>
        _httpContextAccessor.HttpContext?.User?.Identity?.Name;

    public string? GetUserIp() =>
        _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "unknown";

}
