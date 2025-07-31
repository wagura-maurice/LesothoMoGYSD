using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Views.Nissa.Districtregistrations;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class CCRegistrationActivityAutocomplete : MudAutocomplete<int?>
{
    public CCRegistrationActivityAutocomplete()
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
    [Inject] private ISearchService<CCRegistrationActivityView> SearchService { get; set; } = default!;
    [Parameter] public int? CCsRegisteredId { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        // Create the search service dynamically and choose whether to use DbContext
        SearchService = SearchServiceFactory.Create<CCRegistrationActivityView>(useDbContext: true);

        SearchService.OnChange += CCRegistrationActivityService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task CCRegistrationActivityService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= CCRegistrationActivityService_OnChange;
        await base.DisposeAsyncCore();
    }

    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken _ = default)
    {
        IEnumerable<CCRegistrationActivityView> activities = SearchService.DataSource;

        // Filter by CCsRegisteredId if provided
        if (CCsRegisteredId.HasValue && CCsRegisteredId.Value > 0)
        {
            activities = activities.Where(x => x.CCsRegisteredId == CCsRegisteredId.Value && x.StatusName == "Approved");
        }

        // Filter by search value if provided
        if (!string.IsNullOrWhiteSpace(value))
        {
            value = value.Trim();
            activities = activities.Where(x => x.StatusName == "Approved" &&
                (ContainsIgnoreCase(x.ActivityDescription, value) ||
                ContainsIgnoreCase(x.ActivityName, value) ||
                ContainsIgnoreCase(x.CCsRegisteredName, value)));
        }

        return Task.FromResult(activities?.Select(x => (int?)x.Id) ?? Enumerable.Empty<int?>());
    }    // Helper to safely compare strings case-insensitively
    private static bool ContainsIgnoreCase(string source, string value) =>
        !string.IsNullOrEmpty(source) && source.Contains(value, StringComparison.OrdinalIgnoreCase);

    private string ToString(int? str)
    {
        if (str.HasValue && str.Value > 0)
        {
            var activity = SearchService.DataSource.FirstOrDefault(x => x.Id == str.Value);
            if (activity != null)
            {
                return $"{activity.ActivityName} - {activity.ActivityDescription}";
            }
        }
        return string.Empty;
    }
}
