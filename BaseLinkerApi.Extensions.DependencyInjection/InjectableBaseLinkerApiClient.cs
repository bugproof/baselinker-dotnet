using System.Runtime.CompilerServices;
using System.Threading.RateLimiting;
using BaseLinkerApi.Common;
using Microsoft.Extensions.Options;

[assembly:InternalsVisibleTo("BaseLinkerApi.Tests")]

namespace BaseLinkerApi.Extensions.DependencyInjection;

internal class InjectableBaseLinkerApiClient : IBaseLinkerApiClient
{
    private readonly BaseLinkerApiClient _client;
    private static FixedWindowRateLimiter? _rateLimiter;

    public InjectableBaseLinkerApiClient(HttpClient httpClient, IOptions<BaseLinkerOptions> options)
    {
        if (options.Value.Token == null) throw new ArgumentNullException(nameof(options.Value.Token));
        
        _rateLimiter ??= new FixedWindowRateLimiter(new FixedWindowRateLimiterOptions
        {
            Window = TimeSpan.FromMinutes(1),
            PermitLimit = options.Value.MaxRequestsPerMinute
        });
        
        _client = new BaseLinkerApiClient(httpClient, options.Value.Token)
        {
            ThrowExceptions = options.Value.ThrowExceptions,
            UseRequestLimit = options.Value.UseRequestLimit,
            TimeLimiter = _rateLimiter
        };
    }

    public Task<TOutput> SendAsync<TOutput>(IRequest<TOutput> request, CancellationToken cancellationToken = default) where TOutput : ResponseBase
        => _client.SendAsync(request, cancellationToken);
}
