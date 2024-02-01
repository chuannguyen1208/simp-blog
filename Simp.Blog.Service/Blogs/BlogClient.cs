using Simp.Blog.Service.Abstraction.Blogs;
using Simp.Modules.Blogs.Contracts.Blogs;
using System.Net.Http.Json;

namespace Simp.Blog.Service.Blogs;

internal class BlogClient(HttpClient httpClient) : IBlogClient
{
    private const string Prefix = "api/blogs";

    public async Task CreateAsync(BlogRequest request)
    {
        await httpClient.PostAsJsonAsync(Prefix, request);
    }

    public async Task DeleteAsync(Guid id)
    {
        await httpClient.DeleteAsync($"{Prefix}/{id}");
    }

    public async Task<IEnumerable<BlogResponse>> GetManyAsync()
    {
        var response = await httpClient.GetFromJsonAsync<IEnumerable<BlogResponse>>(Prefix);
        return response ?? [];
    }

    public async Task<BlogResponse> GetOneAsync(Guid id)
    {
        var response = await httpClient.GetFromJsonAsync<BlogResponse>($"{Prefix}/{id}");
        return response!;
    }

    public async Task UpdateAsync(Guid id, BlogRequest request)
    {
        await httpClient.PutAsJsonAsync($"{Prefix}/{id}", request);
    }
}
