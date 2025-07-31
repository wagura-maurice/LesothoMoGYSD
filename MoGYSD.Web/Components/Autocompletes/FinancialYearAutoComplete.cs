using Microsoft.AspNetCore.Components;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Services;
using MudBlazor;

namespace MoGYSD.Web.Components.Autocompletes
{
    public partial class FinancialYearAutoComplete : MudAutocomplete<int?>
    {
        public FinancialYearAutoComplete()
        {
            SearchFunc = SearchFunc_;
            ToStringFunc = ToStringFunc_;
            Clearable = true;
            Dense = true;
            ResetValueOnEmptyText = true;
            ShowProgressIndicator = true;
            MaxItems = 50;
        }

        [Inject]
        private ISearchService<FinancialYear> SearchService { get; set; } = default!;

        [Parameter]
        public bool OnlyActive { get; set; } = true;

        protected override void OnInitialized()
        {
            SearchService.OnChange += OnSearchServiceChanged;
            SearchService.Initialize();
            base.OnInitialized();
        }

        public void Dispose()
        {
            if (SearchService != null)
            {
                SearchService.OnChange -= OnSearchServiceChanged;
            }
        }

        private Task OnSearchServiceChanged()
        {
            return InvokeAsync(StateHasChanged);
        }

        private Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken token)
        {
            IEnumerable<FinancialYear> filtered = SearchService.DataSource;

            if (OnlyActive)
            {
                filtered = filtered.Where(ft => ft.IsActive);
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                filtered = filtered.Where(ft => ft.Name != null && ft.Name.Contains(value, StringComparison.OrdinalIgnoreCase));
            }

            return Task.FromResult(filtered.Select(ft => (int?)ft.Id));
        }

        private string ToStringFunc_(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var facilityType = SearchService.DataSource.FirstOrDefault(ft => ft.Id == id.Value);
                return facilityType?.Name ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
