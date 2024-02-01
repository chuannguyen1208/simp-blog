using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Simp.Blog.Service.Abstraction.Editors;

namespace Simp.Blog.Service.Editors;
internal class EditorInterop(IJSRuntime js) : IEditor
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => js.InvokeAsync<IJSObjectReference>("import", "./js/editor.js").AsTask());

    public async Task<string> GetEditorValueAsync()
    {
        var module = await moduleTask.Value;
        var content = await module.InvokeAsync<string>("getEditorValue");
        return content;
    }

    public async Task LoadEditorAsync(ElementReference textareaElement, ElementReference inputFileElement, string toolbar = "miniToolbar")
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("loadEditor", textareaElement, inputFileElement, toolbar);
    }

    public async Task SetEditorValueAsync(string content)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setEditorValue", content);
    }

    public async Task WriteFrontFileAsync(ElementReference? imageUpload)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("writeFrontFile", imageUpload);
    }

    public async Task WriteFrontFileTempAsync(string filename, string url)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("writeFrontFileTemp", filename, url);
    }
}
