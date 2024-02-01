using Simp.Blog.Service.Abstraction.Blobs;

namespace Simp.Blog.Services;

internal class BlobService(IWebHostEnvironment webHostEnvironment) : IBlobService
{
    public async Task<string> BlobUrlToBase64(string blobUrl)
    {
        string webRootPath = webHostEnvironment.WebRootPath;
        string filePath = Path.Combine(webRootPath, blobUrl);

        if (File.Exists(filePath))
        {
            byte[] imageBytes = await File.ReadAllBytesAsync(filePath);

            var base64 = Convert.ToBase64String(imageBytes);

            return $"data:image/png;base64,{base64}";
        }

        return string.Empty;
    }
}
