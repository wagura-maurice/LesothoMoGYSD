using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;
public class CommunityCouncilAutocomplete : MudAutocomplete<int?>
{
    public CommunityCouncilAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] public ISearchService<CommunityCouncil> SearchService { get; set; } = default!;
    [Parameter] public int? DistrictId { get; set; } = null!;
    [Parameter] public int? ConstituencyId { get; set; } = null!;
    [Parameter] public bool IsCascading { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += CommunityCouncilService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task CommunityCouncilService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= CommunityCouncilService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        if(DistrictId.HasValue && DistrictId.Value > 0)
        {
            // if text is null or empty, show complete list
            return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource.Where(d => d.DistrictId == DistrictId && d.IsActive == true)
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => x.CommunityCouncilName!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.DistrictId == DistrictId && x.IsActive == true).Select(x => (int?)x.Id));
        }
        else if(ConstituencyId.HasValue && ConstituencyId.Value > 0)
        {
            // if text is null or empty, show complete list
            return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource.Where(d => d.ConstituencyId == ConstituencyId && d.IsActive == true)
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => x.CommunityCouncilName!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.ConstituencyId == ConstituencyId && x.IsActive == true).Select(x => (int?)x.Id));
        }     
        else
        {
            if(!IsCascading)
            {
                // if text is null or empty, show complete list
                return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource.Where(d => d.IsActive == true)
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => x.CommunityCouncilName!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.IsActive == true).Select(x => (int?)x.Id));
            }
            else
            {
                return Task.FromResult(Enumerable.Empty<int?>());
            }
        }
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var communityCouncil = SearchService.DataSource.Find(x => x.Id == str);
            if(communityCouncil != null)
            {
                return communityCouncil!.CommunityCouncilName!;

            }

        }
        return string.Empty;
    }
}
public class CommunityCouncilAutocompleteExclude : CommunityCouncilAutocomplete
{
    /// <summary>
    /// List of CommunityCouncil IDs to exclude from the results.
    /// </summary>
    [Parameter]
    public List<int>? ExcludedCommunityCouncilIds { get; set; }

    // Override the SearchFunc_ to exclude specified community councils while keeping all filters and search intact
    private new Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        var excluded = ExcludedCommunityCouncilIds ?? new List<int>();

        IEnumerable<CommunityCouncil> filteredData;

        if (DistrictId.HasValue && DistrictId.Value > 0)
        {
            filteredData = string.IsNullOrEmpty(value)
                ? SearchService.DataSource.Where(d => d.DistrictId == DistrictId && d.IsActive && !excluded.Contains(d.Id))
                : SearchService.DataSource.Where(d => d.DistrictId == DistrictId
                                                      && d.IsActive
                                                      && !excluded.Contains(d.Id)
                                                      && d.CommunityCouncilName != null
                                                      && d.CommunityCouncilName.Contains(value, StringComparison.OrdinalIgnoreCase));
        }
        else if (ConstituencyId.HasValue && ConstituencyId.Value > 0)
        {
            filteredData = string.IsNullOrEmpty(value)
                ? SearchService.DataSource.Where(d => d.ConstituencyId == ConstituencyId && d.IsActive && !excluded.Contains(d.Id))
                : SearchService.DataSource.Where(d => d.ConstituencyId == ConstituencyId
                                                      && d.IsActive
                                                      && !excluded.Contains(d.Id)
                                                      && d.CommunityCouncilName != null
                                                      && d.CommunityCouncilName.Contains(value, StringComparison.OrdinalIgnoreCase));
        }
        else
        {
            filteredData = string.IsNullOrEmpty(value)
                ? SearchService.DataSource.Where(d => d.IsActive && !excluded.Contains(d.Id))
                : SearchService.DataSource.Where(d => d.IsActive
                                                      && !excluded.Contains(d.Id)
                                                      && d.CommunityCouncilName != null
                                                      && d.CommunityCouncilName.Contains(value, StringComparison.OrdinalIgnoreCase));
        }

        var result = filteredData.Select(x => (int?)x.Id);

        return Task.FromResult(result);
    }

    public CommunityCouncilAutocompleteExclude()
    {
        SearchFunc = SearchFunc_;
    }
}
