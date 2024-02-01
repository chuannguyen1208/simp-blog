
namespace Simp.Blog.Service;

internal class HttpClientInterceptor : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response is { IsSuccessStatusCode: false })
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }

            return response;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP request failed: {ex.Message}");
            throw;
        }
    }
}