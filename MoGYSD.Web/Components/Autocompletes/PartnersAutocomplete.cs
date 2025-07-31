using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class PartnersAutocomplete : MudAutocomplete<int?>
{
    public PartnersAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchService<Partner> SearchService { get; set; } = default!;
    [Parameter] public int? DistrictId { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += PartnerService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task PartnerService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= PartnerService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        if (DistrictId.HasValue && DistrictId.Value > 0)
        {
            // if text is null or empty, show complete list
            return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource.Where(d => d.DistrictId == DistrictId)
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => x.PartnerName!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.DistrictId == DistrictId).Select(x => (int?)x.Id));
        }
        else
        {
            // if text is null or empty, show complete list
            return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => x.PartnerName!.Contains(value, StringComparison.OrdinalIgnoreCase)).Select(x => (int?)x.Id));
        }
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var partner = SearchService.DataSource.Find(x => x.Id == str);
            if(partner  != null)
            {
                return partner!.PartnerName!;

            }
        }
        return string.Empty;
    }
}
