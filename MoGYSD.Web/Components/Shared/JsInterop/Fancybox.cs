using Microsoft.JSInterop;

namespace MoGYSD.Web.Components.Shared.JsInterop;
public sealed class Fancybox
{
    private readonly IJSRuntime _jsRuntime;

    public Fancybox(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<ValueTask> Preview(string defaultUrl, IEnumerable<string> images)
    {
        var jsmodule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/assets/js/fancybox.js").ConfigureAwait(false);
        return jsmodule.InvokeVoidAsync(JSInteropConstants.PreviewImage, defaultUrl,
            images);
    }
}

public static class JSInteropConstants
{
    public const string ShowOpenSeadragon = "showOpenSeadragon";
    public const string ClearInput = "clearInput";
    public const string PreviewImage = "previewImage";
}