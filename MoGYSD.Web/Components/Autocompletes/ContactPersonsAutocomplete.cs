using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class ContactPersonsAutocomplete : MudAutocomplete<int?>
{
    public ContactPersonsAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchService<ContactPerson> SearchService { get; set; } = default!;
    [Parameter] public int? PartnerId { get; set; } = null!;
    [Parameter] public bool IsCascading { get; set; }
    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += ContactPersonService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task ContactPersonService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= ContactPersonService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        if (PartnerId.HasValue && PartnerId.Value > 0)
        {
            // if text is null or empty, show complete list
            return string.IsNullOrEmpty(value)
                ? Task.FromResult(SearchService.DataSource.Where(d => d.PartnerId == PartnerId)
                    .Select(x => (int?)x.Id))
                : Task.FromResult(SearchService.DataSource
                    .Where(x => 
                    (x.FirstName!.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                        x.Surname!.Contains(value, StringComparison.OrdinalIgnoreCase))
                    && x.PartnerId == PartnerId).Select(x => (int?)x.Id));
        }
        else
        {
            // if text is null or empty, show complete list
            if(IsCascading)
            {
                return Task.FromResult(Enumerable.Empty<int?>());
            }
            else
            {
                return string.IsNullOrEmpty(value)
                    ? Task.FromResult(SearchService.DataSource
                        .Select(x => (int?)x.Id))
                    : Task.FromResult(SearchService.DataSource
                        .Where(x => (x.FirstName!.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                            x.Surname!.Contains(value, StringComparison.OrdinalIgnoreCase))).Select(x => (int?)x.Id));

            }
        }
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var contactPerson = SearchService.DataSource.Find(x => x.Id == str);

            if (contactPerson != null)
            {
                return $"{contactPerson.FirstName} {contactPerson.Surname}";
            }
        }
        return string.Empty;
    }
}