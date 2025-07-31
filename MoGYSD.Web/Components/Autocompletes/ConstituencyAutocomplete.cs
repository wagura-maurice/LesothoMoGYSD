using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class ConstituencyAutocomplete : MudAutocomplete<int?>
{
    public ConstituencyAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] protected ISearchService<Constituency> SearchService { get; set; } = default!;
    [Parameter] public int? DistrictId { get; set; }
    [Parameter] public bool IsCascading { get; set; } = false;
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += ConstituencyService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task ConstituencyService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= ConstituencyService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        // if text is null or empty, show complete list
        if(DistrictId > 0)
        {
            return string.IsNullOrEmpty(value)
                        ? Task.FromResult(SearchService.DataSource.Where(d => d.Status == true && d.DistrictId == DistrictId)
                            .Select(x => (int?)x.Id))
                        : Task.FromResult(SearchService.DataSource
                            .Where(x => x.Name!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.DistrictId == DistrictId && x.Status == true).Select(x => (int?)x.Id));
        }
        else
        {
            if(!IsCascading)
            {
                return string.IsNullOrEmpty(value)
                    ? Task.FromResult(SearchService.DataSource.Where(d => d.Status == true)
                        .Select(x => (int?)x.Id))
                    : Task.FromResult(SearchService.DataSource
                        .Where(x => x.Name!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.Status == true).Select(x => (int?)x.Id));

            }
            else
            {
                return Task.FromResult(Enumerable.Empty<int?>());
            }
        }
    }

    private string ToString(int? str)
    {
        if (str != null)
        {
            var constituency = SearchService.DataSource.Find(x => x.Id == str);
            if (constituency != null)
            {
                return constituency!.Name!;
            }
        }
        return string.Empty;
    }
}
