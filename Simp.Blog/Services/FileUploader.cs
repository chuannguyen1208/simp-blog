using Microsoft.AspNetCore.Components.Forms;
using Simp.Blog.Service.Abstraction.Files;

namespace Simp.Blog.Services;

internal class FileUploader(IWebHostEnvironment env) : IFileUploader
{
    public async Task<string> UploadFile(IBrowserFile file, long maxFileSize = 15360)
    {
        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
        var returnFilePath = Path.Combine("img", "temp", fileName);
        var filePath = Path.Combine(env.ContentRootPath, "wwwroot", returnFilePath);
        var dir = Path.GetDirectoryName(filePath);
        Directory.CreateDirectory(dir!);

        await using FileStream fs = new(filePath, FileMode.Create);
        await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

        return returnFilePath;
    }
}
