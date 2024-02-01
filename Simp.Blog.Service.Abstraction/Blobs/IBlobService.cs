namespace Simp.Blog.Service.Abstraction.Blobs;
public interface IBlobService
{
    Task<string> BlobUrlToBase64(string blobUrl);
}
