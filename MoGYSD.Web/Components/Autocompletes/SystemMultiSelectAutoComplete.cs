using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Services;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoGYSD.Web.Components.Autocompletes 
{
    public class SystemMultiSelectAutoComplete : ComponentBase
    {
        [Inject]
        private ISystemCodeSearchService SearchService { get; set; } = default!;

        [Parameter]
        public string ParentCode { get; set; } = string.Empty;

        [Parameter]
        public string Label { get; set; } = "Select Items";
        [Parameter]
        public Variant Variant { get; set; } = Variant.Text;

        [Parameter]
        public bool ShowSelectedSummary { get; set; }

        [Parameter]
        public IEnumerable<int?> SelectedValues { get; set; } = Enumerable.Empty<int?>();

        [Parameter]
        public EventCallback<IEnumerable<int?>> SelectedValuesChanged { get; set; }

        private List<SystemCodeDetailsView> _options = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadOptionsAsync();
        }

        private async Task LoadOptionsAsync()
        {
            // This assumes your SearchService.DataSource is readily available.
            // If it needs to be fetched, you would await a method here.
            _options = SearchService.DataSource
                .Where(x => x.ParentCode == ParentCode)
                .OrderBy(x => x.OrderNo)
                .ToList();

            await Task.CompletedTask; // Placeholder if the above is synchronous
        }

        /// <summary>
        /// This function is the core of the solution. It looks up the name for a given ID.
        /// </summary>
        private string GetItemName(int? id)
        {
            if (id is null) return string.Empty;

            // Find the item in our list of options and return its name.
            // If it's not found (e.g., during initial load), it returns the ID as a string as a fallback.
            return _options.FirstOrDefault(o => o.Id == id)?.Name ?? id.ToString() ?? string.Empty;
        }

        private Task OnValuesChanged(IEnumerable<int?> values)
        {
            SelectedValues = values;
            return SelectedValuesChanged.InvokeAsync(SelectedValues);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int seq = 0;

            // Open MudSelect component
            builder.OpenComponent<MudSelect<int?>>(seq++);

            // Add attributes
            builder.AddAttribute(seq++, "MultiSelection", true);
            builder.AddAttribute(seq++, "Label", Label);
            builder.AddAttribute(seq++, "Variant", Variant);
            builder.AddAttribute(seq++, "Dense", true);
            builder.AddAttribute(seq++, "SelectedValues", SelectedValues);
            builder.AddAttribute(seq++, "SelectedValuesChanged", EventCallback.Factory.Create<IEnumerable<int?>>(this, OnValuesChanged));

            // --- THIS IS THE KEY FIX ---
            // Provide a function to convert the value (ID) to a string (Name) for display.
            builder.AddAttribute(seq++, "ToStringFunc", new Func<int?, string>(GetItemName));

            // Add dropdown items as ChildContent
            builder.AddAttribute(seq++, "ChildContent", (RenderFragment)(childBuilder =>
            {
                int childSeq = 0;
                if (_options != null)
                {
                    foreach (var item in _options)
                    {
                        childBuilder.OpenComponent<MudSelectItem<int?>>(childSeq++);
                        childBuilder.AddAttribute(childSeq++, "Value", item.Id);
                        childBuilder.AddAttribute(childSeq++, "ChildContent", (RenderFragment)(descBuilder =>
                        {
                            descBuilder.AddContent(0, item.Name);
                        }));
                        childBuilder.CloseComponent(); // </MudSelectItem>
                    }
                }
            }));

            // Close MudSelect component
            builder.CloseComponent();

            // Optionally, render the summary text below the select component
            if (ShowSelectedSummary && SelectedValues.Any())
            {
                string summary = string.Join(", ", SelectedValues.Select(id => GetItemName(id)));

                builder.OpenElement(seq++, "div");
                builder.AddAttribute(seq++, "class", "mt-1 text-secondary small");
                builder.AddContent(seq++, $"Selected: {summary}");
                builder.CloseElement();
            }
        }
    }
}