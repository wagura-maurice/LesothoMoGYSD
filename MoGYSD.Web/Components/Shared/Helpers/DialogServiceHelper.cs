using MudBlazor;

namespace MoGYSD.Web.Components.Shared.Helpers;
public static class DialogServiceHelper
{
    public static async Task<bool> ShowConfirmationDialogAsync(IDialogService dialogService, string message = null)
    {
        var parameters = new DialogParameters
        {
            { "ContentText", message ?? "Are you sure you want to confirm this item?" }
        };

        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

        var dialog = await dialogService.ShowAsync<ConfirmDialog>("Confirm Action", parameters, options);
        var result = await dialog.Result;

        return !result.Canceled && result.Data is true;
    }
    public static async Task<string?> ShowRejectDialogAsync(IDialogService dialogService, string message = null)
    {
        var parameters = new DialogParameters
        {
            { "ItemName", message ?? "Are you sure you want to proceed?" }
        };

        var options = new DialogOptions
        {
            CloseButton = true,
            MaxWidth = MaxWidth.Small,
            FullWidth = true
        };

        var dialog = await dialogService.ShowAsync<RejectDialog>("Reject Action", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return null;

        return result.Data?.ToString(); // reason
    }
}
public static class FilePathHelper
{
    public static string ToWebUrl(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return string.Empty;

        // Normalize backslashes to forward slashes
        var normalized = filePath.Replace("\\", "/");

        // Ensure it starts with a slash
        if (!normalized.StartsWith("/"))
            normalized = "/" + normalized;

        return normalized;
    }
}