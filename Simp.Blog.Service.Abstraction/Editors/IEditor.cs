using Microsoft.AspNetCore.Components;

namespace Simp.Blog.Service.Abstraction.Editors;
public interface IEditor
{
    Task LoadEditorAsync(ElementReference textareaElement, ElementReference inputFileElement, string toolbar = "miniToolbar");
    Task WriteFrontFileAsync(ElementReference? imageUpload);
    Task WriteFrontFileTempAsync(string filename, string url);
    Task SetEditorValueAsync(string content);
    Task<string> GetEditorValueAsync();
}
