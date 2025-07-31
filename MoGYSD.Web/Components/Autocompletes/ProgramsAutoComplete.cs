using Microsoft.AspNetCore.Components;
using MudBlazor;
using MoGYSD.Business.Models.Missa.ProgrammeConfiguration;
using MoGYSD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoGYSD.Web.Components.Autocompletes
{
    public partial class ProgramsAutoComplete : MudAutocomplete<int?>
    {
        public ProgramsAutoComplete()
        {
            SearchFunc = SearchFunc_;
            ToStringFunc = ToStringFunc_;
            Clearable = true;
            Dense = true;
            ResetValueOnEmptyText = true;
            ShowProgressIndicator = true;
            MaxItems = 50;
        }

        // The IsActive parameter is no longer needed as we will always filter for active.
        // [Parameter] public bool? IsActive { get; set; } 

        [Inject] public ISearchService<Programmes> SearchService { get; set; }

        protected override void OnInitialized()
        {
            SearchService.OnChange += OnSearchServiceChanged;
            SearchService.Initialize();
        }

        public void Dispose()
        {
            SearchService.OnChange -= OnSearchServiceChanged;
        }

        private Task OnSearchServiceChanged()
        {
            return InvokeAsync(StateHasChanged);
        }

        protected Task<IEnumerable<int?>> SearchFunc_(string value, CancellationToken token)
        {
           
            IEnumerable<Programmes> filtered = SearchService.DataSource;      
            filtered = filtered.Where(x => x.IsActive);
            if (!string.IsNullOrWhiteSpace(value))
            {
                filtered = filtered.Where(x => x.Name != null && x.Name.Contains(value, StringComparison.OrdinalIgnoreCase));
            }

            return Task.FromResult(filtered.Select(x => (int?)x.Id));
        }

        protected string ToStringFunc_(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
              
                var programme = SearchService.DataSource.FirstOrDefault(x => x.Id == id.Value);
                return programme?.Name ?? string.Empty;
            }
            return string.Empty;
        }
    }
}