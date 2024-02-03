namespace Simp.Blog.Components.Admin;

public static class AdminRoutes
{
    public const string Dashboard = "/admin";
    public const string Blogs = "/admin/blogs";
    public const string BlogsEdit = "/admin/blogs/{id:guid}";

    public static string ToBlogsCreate() => $"{Blogs}/{Guid.Empty}";
    public static string ToBlogsEdit(Guid Id) => $"{Blogs}/{Id}";

}
