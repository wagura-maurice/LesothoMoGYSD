using MudBlazor;
using Microsoft.AspNetCore.Components;
using MoGYSD.Services;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Web.Components.Autocompletes;
public class VillageAutocomplete : MudAutocomplete<int?>
{
    public VillageAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchService<Village> SearchService { get; set; } = default!;
    [Parameter] public int? CommunityCouncilId { get; set; } = null!;
    [Parameter] public bool IsCascading { get; set; } = false;
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += VillageService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task VillageService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= VillageService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        if(CommunityCouncilId.HasValue && CommunityCouncilId.Value > 0)
        {
            // if text is null or empty, show complete list
            return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource.Where(c => c.CommunityCouncilId == CommunityCouncilId && c.IsActive == true)
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => x.Name!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.CommunityCouncilId == CommunityCouncilId && x.IsActive == true).Select(x => (int?)x.Id));
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
                        .Where(x => x.Name!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.IsActive == true).Select(x => (int?)x.Id));
            }
            else
            {
                // if text is null or empty, show complete list
                return Task.FromResult(Enumerable.Empty<int?>());
            }
        }
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var village = SearchService.DataSource.Find(x => x.Id == str);
            if(village != null)
            {
                return village!.Name!;

            }
        }
        return string.Empty;
    }
}
