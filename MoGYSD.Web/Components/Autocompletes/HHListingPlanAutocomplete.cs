using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Views.HouseHoldListings;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class HHListingPlanAutocomplete : MudAutocomplete<int?>
{
    public HHListingPlanAutocomplete()
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
    [Inject] private ISearchService<HHListingPlanView> SearchService { get; set; } = default!;
    [Parameter] public int? DistrictId { get; set; } = default!;
    [Parameter] public bool IsCascading { get; set; } = false;
    protected override async Task OnInitializedAsync()
    {
        // Create the search service dynamically and choose whether to use DbContext
        SearchService = SearchServiceFactory.Create<HHListingPlanView>(useDbContext: true);

        SearchService.OnChange += HHListPlanService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task HHListPlanService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= HHListPlanService_OnChange;
        await base.DisposeAsyncCore();
    }

    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken _ = default)
    {
        IEnumerable<HHListingPlanView> activities = SearchService.DataSource;

        if(DistrictId != null && DistrictId > 0)
        {
            activities = activities.Where(d => d.DistrictId == DistrictId && d.StatusName == "Approved");
        }
        else if (IsCascading)
        {
            // If cascading but no district, return empty
            return Task.FromResult(Enumerable.Empty<int?>());
        }
        // Filter by search value if provided
        if (!string.IsNullOrWhiteSpace(value))
        {
            value = value.Trim();
            activities = activities.Where(x => x.StatusName == "Approved" &&
                (ContainsIgnoreCase(x.HHListingActivityName, value)));
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
                return $"{activity.HHListingActivityName}";
            }
        }
        return string.Empty;
    }
}
