using Simp.Blog.Components;
using Simp.Blog.Service;
using Simp.Blog.Service.Abstraction.Blobs;
using Simp.Blog.Service.Abstraction.Files;
using Simp.Blog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
builder.Services.AddSingleton<IFileUploader, FileUploader>();
builder.Services.AddSingleton<IBlobService, BlobService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
