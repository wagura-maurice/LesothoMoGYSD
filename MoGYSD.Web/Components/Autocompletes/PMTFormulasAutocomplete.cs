using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.PMTCalculations;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;
public class PMTFormulasAutocomplete : MudAutocomplete<int?>
{
    public PMTFormulasAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchService<PMTFormula> SearchService { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += PMTFormulasService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }
    private async Task PMTFormulasService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }
    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= PMTFormulasService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        return string.IsNullOrEmpty(value)
            ? Task.FromResult(SearchService.DataSource.Select(x => (int?)x.Id))
            : Task.FromResult(SearchService.DataSource
                .Where(x => x.Name.Contains(value, StringComparison.OrdinalIgnoreCase))
                .Select(x => (int?)x.Id));
    }
    private string ToString(int? str)
    {
        if (str > 0)
        {
            var pPMTFormula = SearchService.DataSource.Find(x => x.Id == str);

            if(pPMTFormula != null)
            {
                return pPMTFormula.Name!;
            }
        }
        return string.Empty;
    }
}
