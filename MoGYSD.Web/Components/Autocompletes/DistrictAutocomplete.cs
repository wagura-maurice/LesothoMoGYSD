using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;
public class DistrictAutocomplete : MudAutocomplete<int?>
{
    public DistrictAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Parameter] public List<int>? DistrictsWithPlans { get; set; } = default!;
    [Inject] private ISearchServiceFactory SearchServiceFactory { get; set; } = default!;
    [Inject] protected ISearchService<DistrictView> SearchService { get; set; } = default!;
    [Inject] protected ISearchService<CommunityCouncil> CommunityCouncilSearchService { get; set; } = default!;
    [Parameter] public int? CommunityCouncilId { get; set; }
    protected override async Task OnInitializedAsync()
    {
        SearchService = SearchServiceFactory.Create<DistrictView>(useDbContext: true);
        CommunityCouncilSearchService = SearchServiceFactory.Create<CommunityCouncil>(useDbContext: true); 
        SearchService.OnChange += DistrictService_OnChange;
        CommunityCouncilSearchService.OnChange += CommunityCouncilService_OnChange; 
        SearchService.Initialize();
        CommunityCouncilSearchService.Initialize(); 
        await base.OnInitializedAsync();
    }

    private async Task DistrictService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }
    private async Task CommunityCouncilService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= DistrictService_OnChange;
        if (CommunityCouncilSearchService != null)
            CommunityCouncilSearchService.OnChange -= CommunityCouncilService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        IEnumerable<DistrictView> filteredDistricts;
        if (CommunityCouncilId.HasValue && CommunityCouncilId.Value > 0)
        {
            // Find the Community Council and then its associated District
            var communityCouncil = CommunityCouncilSearchService.DataSource.FirstOrDefault(cc => cc.Id == CommunityCouncilId.Value);
            if (communityCouncil != null)
            {
                filteredDistricts = SearchService.DataSource
                    .Where(d => d.IsActive == true && d.Id == communityCouncil.DistrictId); 
            }
            else
            {
                filteredDistricts = new List<DistrictView>();
            }
        }
        else if (DistrictsWithPlans != null && DistrictsWithPlans.Count > 0)
        {
            var allowedDistrictIds = DistrictsWithPlans ?? new List<int>();

            var filtered = SearchService.DataSource
                .Where(d => d.IsActive && allowedDistrictIds.Contains(d.Id));

            if (!string.IsNullOrWhiteSpace(value))
            {
                filtered = filtered.Where(d => d.Name != null && d.Name.Contains(value, StringComparison.OrdinalIgnoreCase));
            }

            filteredDistricts = filtered;
        }
        else
        {
          
            filteredDistricts = string.IsNullOrEmpty(value)
                ? SearchService.DataSource.Where(d => d.IsActive == true)
                : SearchService.DataSource.Where(x => x.Name!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.IsActive == true);
        }

        return Task.FromResult(filteredDistricts.Select(x => (int?)x.Id));
    }


    private string ToString(int? str)
    {
        if (str != null)
        {
            var district = SearchService.DataSource.Find(x => x.Id == str);
            if(district != null)
            {
                return district!.Name!;
            }
        }
        return string.Empty;
    }
}
public class LocalDistrictAutocomplete : DistrictAutocomplete
{

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        // Inject "Others" only for this specific page
        if (!SearchService.DataSource.Any(x => x.Id == -1))
        {
            SearchService.DataSource.Add(new DistrictView
            {
                Id = -1,
                Name = "Other Location",
                IsActive = true,
                CountryId = 0,
                CensusYear = 0,
                CensusHouseholdData = 0,
                CensusPopulationData = 0
            });
        }

        // Override the SearchFunc to make "Others" show first
        SearchFunc = SearchFunc_;
    }

    private new Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        var results = string.IsNullOrEmpty(value)
            ? SearchService.DataSource.Where(d => d.IsActive)
            : SearchService.DataSource.Where(d => d.IsActive && d.Name!.Contains(value, StringComparison.OrdinalIgnoreCase));

        var ordered = results
            .OrderByDescending(d => d.Id == -1) // "Others" first
            .ThenBy(d => d.Name)
            .Select(d => (int?)d.Id);

        return Task.FromResult(ordered);
    }
}

public class DistrictAutocompleteExclude : DistrictAutocomplete
{
    /// <summary>
    /// List of district IDs to exclude from the results.
    /// </summary>
    [Parameter]
    public List<int>? ExcludedDistrictIds { get; set; }

    // Override the SearchFunc_ to exclude the specified districts
    private new Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        var excluded = ExcludedDistrictIds ?? new List<int>();

        IEnumerable<DistrictView> filteredData;

        if (string.IsNullOrEmpty(value))
        {
            filteredData = SearchService.DataSource
                .Where(d => d.IsActive && !excluded.Contains(d.Id));
        }
        else
        {
            filteredData = SearchService.DataSource
                .Where(d => d.IsActive
                    && !excluded.Contains(d.Id)
                    && d.Name != null
                    && d.Name.Contains(value, StringComparison.OrdinalIgnoreCase));
        }

        var result = filteredData.Select(x => (int?)x.Id);

        return Task.FromResult(result);
    }

    public DistrictAutocompleteExclude()
    {
        // Replace SearchFunc with the new one that excludes districts
        SearchFunc = SearchFunc_;
    }
}
