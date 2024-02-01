using Microsoft.AspNetCore.Components.Forms;

namespace Simp.Blog.Service.Abstraction.Files;
public interface IFileUploader
{
    Task<string> UploadFile(IBrowserFile file, long maxFileSize = 1024 * 15);
}
