namespace Simp.Blog.Components.User;

public static class UserRoutes
{
    public const string Base = "/";
    public const string Blogs = "/blogs";
    public const string BlogsDetail = "/blogs/{id:guid}";

    public static string ToBlogsDetail(Guid id) => $"/blogs/{id}";
}
