using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simp.Blog.Service.Abstraction.Blogs;
using Simp.Blog.Service.Abstraction.Editors;
using Simp.Blog.Service.Blogs;
using Simp.Blog.Service.Editors;

namespace Simp.Blog.Service;
public static class Extensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpClient()
            .AddHttpClient<IBlogClient, BlogClient>(client => client.BaseAddress = new Uri(configuration["ApiUrl"]!))
            .AddHttpMessageHandler<HttpClientInterceptor>();

        services.AddScoped<HttpClientInterceptor>();
        services.AddScoped<IEditor, EditorInterop>();
    }
}
