using System.Runtime.CompilerServices;
using BaseLinkerApi.Common;
using Microsoft.Extensions.Options;
using RateLimiter;

[assembly:InternalsVisibleTo("BaseLinkerApi.Tests")]

namespace BaseLinkerApi.Extensions.DependencyInjection;

internal class InjectableBaseLinkerApiClient : IBaseLinkerApiClient
{
    private readonly BaseLinkerApiClient _client;

    public InjectableBaseLinkerApiClient(HttpClient httpClient, IOptions<BaseLinkerOptions> options)
    {
        if (options.Value.Token == null) throw new ArgumentNullException(nameof(options.Value.Token));
        _client = new BaseLinkerApiClient(httpClient, options.Value.Token)
        {
            ThrowExceptions = options.Value.ThrowExceptions,
            UseRequestLimit = options.Value.UseRequestLimit,
            TimeLimiter = TimeLimiter.GetFromMaxCountByInterval(options.Value.MaxRequestsPerMinute, TimeSpan.FromMinutes(1))
        };
    }

    public Task<TOutput> SendAsync<TOutput>(IRequest<TOutput> request, CancellationToken cancellationToken = default) where TOutput : ResponseBase
        => _client.SendAsync(request, cancellationToken);
}