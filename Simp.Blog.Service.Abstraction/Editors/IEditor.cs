using Microsoft.AspNetCore.Components;

namespace Simp.Blog.Service.Abstraction.Editors;
public interface IEditor
{
    Task LoadEditorAsync(ElementReference textareaElement, ElementReference inputFileElement, string toolbar = "miniToolbar");
}
