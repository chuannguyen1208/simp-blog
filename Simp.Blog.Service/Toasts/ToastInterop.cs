using Microsoft.JSInterop;
using Simp.Blog.Service.Abstraction.Toasts;

namespace Simp.Blog.Service.Toasts;
internal class ToastInterop(IJSRuntime js) : IToast
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => js.InvokeAsync<IJSObjectReference>("import", "./js/common.js").AsTask());

    public async Task ToastInfo(string message)
    {
        await Toast(message, "text-primary");
    }

    public async Task ToastSuccess(string message)
    {
        await Toast(message, "text-success");
    }

    public async Task ToastError(string message)
    {
        await Toast(message, "text-danger");
    }

    private async Task Toast(string text, string type = "", int closeAfterMs = 3000)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("toast", text, type, closeAfterMs);
    }
}
