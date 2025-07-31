using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class RegistrationCentreAutocomplete : MudAutocomplete<int?>
{
    public RegistrationCentreAutocomplete()
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
    [Inject] private ISearchService<RegistrationCentreVillageView> SearchService { get; set; } = default!;
    [Parameter] public int VillageId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        // Create the search service dynamically and choose whether to use DbContext
        SearchService = SearchServiceFactory.Create<RegistrationCentreVillageView>(useDbContext: true);

        SearchService.OnChange += RegistrationCentreService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task RegistrationCentreService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= RegistrationCentreService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        IEnumerable<RegistrationCentreVillageView> RegistrationCentres = SearchService.DataSource.DistinctBy(a => a.RegistrationCentreId);

        // Filter by village id if provided
        if (VillageId > 0)
        {
            RegistrationCentres = RegistrationCentres.Where(x => x.VillageId == VillageId && x.RegistrationCentreIsActive == true).Distinct();
        }

        // Filter by search value if provided
        if (!string.IsNullOrWhiteSpace(value))
        {
            value = value.Trim();
            RegistrationCentres = RegistrationCentres.Where(x => x.RegistrationCentreIsActive == true &&
                ContainsIgnoreCase(x.RegistrationCentreName, value)).Distinct();
        }

        return Task.FromResult(RegistrationCentres?.Select(x => (int?)x.RegistrationCentreId) ?? Enumerable.Empty<int?>());
    }

    // Helper to safely compare strings case-insensitively
    private static bool ContainsIgnoreCase(string? source, string value) =>
        !string.IsNullOrEmpty(source) && source.Contains(value, StringComparison.OrdinalIgnoreCase);

    private string ToString(int? str)
    {
        if (str.HasValue && str.Value > 0)
        {
            var registrationCentre = SearchService.DataSource.Where(x => x.RegistrationCentreId == str).FirstOrDefault();
            if (registrationCentre != null)
            {
                return registrationCentre.RegistrationCentreName;

            }
        }
        return string.Empty;
    }
}
