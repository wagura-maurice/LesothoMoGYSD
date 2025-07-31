using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;
public class SystemCodeAutocomplete : MudAutocomplete<int?>
{
    public SystemCodeAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] public ISystemCodeSearchService SearchService { get; set; } = default!;
    [Parameter] public string ParentCode { get; set; } = null!;
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += SystemCodeService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task SystemCodeService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= SystemCodeService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        // if text is null or empty, show complete list
        return string.IsNullOrEmpty(value)
            ? Task.FromResult(SearchService.DataSource.Where(d => d.ParentCode == ParentCode)
                .OrderBy(x => x.OrderNo)
                .Select(x => (int?)x.Id))
            : Task.FromResult(SearchService.DataSource
                .Where(x => x.Name!.Contains(value, StringComparison.OrdinalIgnoreCase) && x.ParentCode == ParentCode)
                .Select(x => (int?)x.Id));
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var systemCode = SearchService.DataSource.Find(x => x.Id == str);
            if(systemCode != null)
            {
                return systemCode!.Name!;

            }
        }
        return string.Empty;
    }
}

public class SystemCodeAutocompleteExclude : SystemCodeAutocomplete
{
    /// <summary>
    /// List of IDs to exclude from the results.
    /// </summary>
    [Parameter] public List<int>? ExcludedIds { get; set; }

    public SystemCodeAutocompleteExclude()
    {
        // Override the SearchFunc in constructor
        SearchFunc = FilteredSearchFunc;
    }

    private Task<IEnumerable<int?>> FilteredSearchFunc(string value, CancellationToken cancellation = default)
    {
        var excluded = ExcludedIds ?? new();

        var results = string.IsNullOrWhiteSpace(value)
            ? SearchService.DataSource
                .Where(x => x.ParentCode == ParentCode && !excluded.Contains(x.Id))
                .OrderBy(x => x.OrderNo)
                .Select(x => (int?)x.Id)
            : SearchService.DataSource
                .Where(x => x.ParentCode == ParentCode &&
                            !excluded.Contains(x.Id) &&
                            x.Code.Contains(value, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x.OrderNo)
                .Select(x => (int?)x.Id);

        return Task.FromResult(results);
    }
}
