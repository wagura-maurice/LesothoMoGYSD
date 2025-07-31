using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Nissa.MasterRegistrations;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Business.Views.Nissa.MasterRegistrations;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes;

public class MasterRegistrationAutocomplete : MudAutocomplete<int?>
{
    public MasterRegistrationAutocomplete()
    {
        SearchFunc = SearchFunc_;
        ToStringFunc = ToString;
        Clearable = true;
        Dense = true;
        ResetValueOnEmptyText = true;
        ShowProgressIndicator = true;
        MaxItems = 50;
    }
    [Inject] private ISearchService<MasterRegistration> SearchService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        SearchService.OnChange += MasterRegistrationService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task MasterRegistrationService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= MasterRegistrationService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        // if text is null or empty, show complete list
        return string.IsNullOrEmpty(value)
            ? Task.FromResult(SearchService.DataSource
                .Select(x => (int?)x.Id))
            : Task.FromResult(SearchService.DataSource
                .Where(x => x.MasterPlanName!.Contains(value, StringComparison.OrdinalIgnoreCase)).Select(x => (int?)x.Id));
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var masterRegistration = SearchService.DataSource.Find(x => x.Id == str);
            if (masterRegistration != null)
            {
                return masterRegistration!.MasterPlanName!;
            }
        }
        return string.Empty;
    }
}

public class MasterRegistrationDistrictAutocomplete : MudAutocomplete<int?>
{
    public MasterRegistrationDistrictAutocomplete()
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
    [Inject] protected ISearchService<RegistrationDistrictView> SearchService { get; set; } = default!;
    [Parameter] public int? DistrictId { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        SearchService = SearchServiceFactory.Create<RegistrationDistrictView>(useDbContext: true);
        SearchService.OnChange += MasterRegistrationService_OnChange;
        SearchService.Initialize();
        await base.OnInitializedAsync();
    }

    private async Task MasterRegistrationService_OnChange()
    {
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        if (SearchService != null)
            SearchService.OnChange -= MasterRegistrationService_OnChange;
        await base.DisposeAsyncCore();
    }
    private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken cancellation = default)
    {
        // if text is null or empty, show complete list
        return string.IsNullOrEmpty(value)
            ? Task.FromResult(SearchService.DataSource.Where(x => x.StatusName == "Approved" && x.DistrictId == DistrictId)
                .Select(x => (int?)x.Id))
            : Task.FromResult(SearchService.DataSource
                .Where(x => x.StatusName == "Approved" && x.DistrictId == DistrictId && x.MasterPlanName!.Contains(value, StringComparison.OrdinalIgnoreCase)).Select(x => (int?)x.Id));
    }

    private string ToString(int? str)
    {
        if (str > 0)
        {
            var masterRegistration = SearchService.DataSource.Find(x => x.Id == str);
            if (masterRegistration != null)
            {
                return masterRegistration!.MasterPlanName!;
            }
        }
        return string.Empty;
    }
}
