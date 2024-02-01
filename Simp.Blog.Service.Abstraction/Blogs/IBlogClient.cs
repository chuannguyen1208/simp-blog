using Simp.Modules.Blogs.Contracts.Blogs;

namespace Simp.Blog.Service.Abstraction.Blogs;

public interface IBlogClient
{
    Task<IEnumerable<BlogResponse>> GetManyAsync();
    Task<BlogResponse> GetOneAsync(Guid id);
    Task CreateAsync(BlogRequest request);
    Task UpdateAsync(Guid id, BlogRequest request);
    Task DeleteAsync(Guid id);
}
