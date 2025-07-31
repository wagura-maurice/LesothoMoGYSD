using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;
public class UserAutocomplete : MudAutocomplete<string>
{
    public UserAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchServiceFactory SearchServiceFactory { get; set; } = default!;
    [Inject] private ISearchService<UserSummaryView> SearchService { get; set; } = default!;
    [Parameter] public string RoleId { get; set; } = string.Empty;
    [Parameter] public int? VillageId { get; set; } = null;
    [Parameter] public int? CommunityCouncelId { get; set; } = null;
    [Parameter] public int? DistrictId { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        // Create the search service dynamically and choose whether to use DbContext
        SearchService = SearchServiceFactory.Create<UserSummaryView>(useDbContext: true);

        SearchService.OnChange += UserService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task UserService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= UserService_OnChange;
        await base.DisposeAsyncCore();
    }
    private async Task<IEnumerable<string>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        IEnumerable<UserSummaryView> users = SearchService.DataSource;

        // Filter by RoleId if provided
        if (!string.IsNullOrEmpty(RoleId))
        {
            users = users.Where(x => x.RoleId == RoleId && x.IsActive == true);
        }

        // Filter by search value if provided
        if (!string.IsNullOrWhiteSpace(value))
        {
            value = value.Trim();
            users = users.Where(x => x.IsActive == true &&
                (ContainsIgnoreCase(x.FirstName, value) ||
                ContainsIgnoreCase(x.MiddleName, value) ||
                ContainsIgnoreCase(x.Surname, value) ||
                ContainsIgnoreCase(x.Email, value) ||
                ContainsIgnoreCase(x.PhoneNumber, value)));
        }

        return await Task.FromResult(users.Select(x => x.Id));
    }

    // Helper to safely compare strings case-insensitively
    private static bool ContainsIgnoreCase(string? source, string value) =>
        !string.IsNullOrEmpty(source) && source.Contains(value, StringComparison.OrdinalIgnoreCase);

    private string ToString(string str)
    {
        if (!string.IsNullOrEmpty(str))
        {
            var user = SearchService.DataSource.Where(x => x.Id == str).FirstOrDefault();
            if(user != null)
            {
                return $"{user!.FirstName!} {user!.MiddleName} {user.Surname}";

            }
        }
        return string.Empty;
    }
}
