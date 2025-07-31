using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;
using MudExtensions;

namespace MoGYSD.Web.Components.Autocompletes;
public class SystemParentCodeAutocomplete : MudAutocomplete<int?>
{
    public SystemParentCodeAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchService<SystemCode> SearchService { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += SystemParentCodeService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task SystemParentCodeService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= SystemParentCodeService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        // if text is null or empty, show complete list
        return string.IsNullOrEmpty(value)
            ? Task.FromResult(SearchService.DataSource
                .Select(x => (int?)x.Id))
            : Task.FromResult(SearchService.DataSource
                .Where(x => x.Code!.Contains(value, StringComparison.OrdinalIgnoreCase)).Select(x => (int?)x.Id));
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var systemParentCode = SearchService.DataSource.Find(x => x.Id == str);
            if (systemParentCode != null)
            {
                return systemParentCode!.Code!;

            }

        }
        return string.Empty;
    }
}
