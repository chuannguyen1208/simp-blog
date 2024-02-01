using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Simp.Blog.Service.Abstraction.Editors;

namespace Simp.Blog.Service.Editors;
internal class EditorInterop(IJSRuntime js) : IEditor
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => js.InvokeAsync<IJSObjectReference>("import", "./js/editor.js").AsTask());

    public async Task LoadEditorAsync(ElementReference textareaElement, ElementReference inputFileElement, string toolbar = "miniToolbar")
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("loadEditor", textareaElement, inputFileElement, toolbar);
    }
}
