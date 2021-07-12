using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BaseLinkerApi.Common;
using RateLimiter;

namespace BaseLinkerApi
{
    // ReSharper disable once UnusedTypeParameter
    public interface IRequest<TOutput> where TOutput : ResponseBase {}
    public interface IRequest : IRequest<ResponseBase> {}

    public class BaseLinkerApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _token;
        
        // The API doesn't return TooManyRequests but instead blocks your account so rate limit must be implemented client-side
        private readonly TimeLimiter _timeLimiter = TimeLimiter.GetFromMaxCountByInterval(100, TimeSpan.FromMinutes(1));
        
        public BaseLinkerApiClient(HttpClient httpClient, string token)
        {
            _httpClient = httpClient;
            _token = token;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public bool UseRequestLimit { get; set; } = true;

        private async Task<TOutput> SendImpl<TOutput>(IRequest<TOutput> request,
            CancellationToken cancellationToken = default) where TOutput : ResponseBase
        {
            var data = new Dictionary<string, string>
            {
                { "token", _token },
                { "method", JsonNamingPolicy.CamelCase.ConvertName(request.GetType().Name) },
                // https://stackoverflow.com/questions/58570189/is-there-a-built-in-way-of-using-snake-case-as-the-naming-policy-for-json-in-asp
                { "parameters", JsonSerializer.Serialize((object)request, new JsonSerializerOptions { IgnoreNullValues = true }) }
            };

            var responseMessage = await _httpClient.PostAsync("https://api.baselinker.com/connector.php",
                new FormUrlEncodedContent(data), cancellationToken);
            return (await responseMessage.Content.ReadFromJsonAsync<TOutput>(cancellationToken: cancellationToken))!;
        }
        
        public Task<TOutput> Send<TOutput>(IRequest<TOutput> request, CancellationToken cancellationToken = default) where TOutput : ResponseBase
        {
            return UseRequestLimit ? _timeLimiter.Enqueue(() => SendImpl(request, cancellationToken), cancellationToken) : SendImpl(request, cancellationToken);
        }
    }
}