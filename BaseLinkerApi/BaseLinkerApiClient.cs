using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BaseLinkerApi.Common;
using BaseLinkerApi.Common.JsonConverters;
using RateLimiter;

[assembly:InternalsVisibleTo("BaseLinkerApi.Tests")]

namespace BaseLinkerApi;

// ReSharper disable once UnusedTypeParameter
public interface IRequest<TOutput> where TOutput : ResponseBase {}
public interface IRequest : IRequest<ResponseBase> {}

public class BaseLinkerException : Exception
{
    public BaseLinkerException(string errorCode, string errorMessage, Exception? innerException = null) : base($"{errorCode} - {errorMessage}", innerException)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public string ErrorCode { get; }
    public string ErrorMessage { get; }
}

public interface IBaseLinkerApiClient
{
    Task<TOutput> SendAsync<TOutput>(IRequest<TOutput> request, CancellationToken cancellationToken = default) where TOutput : ResponseBase;
}

public class BaseLinkerApiClient : IBaseLinkerApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _token;
        
    public BaseLinkerApiClient(HttpClient httpClient, string token)
    {
        _httpClient = httpClient;
        _token = token;
    }
        
    // The API doesn't return TooManyRequests but instead blocks your account so rate limit must be implemented client-side
    public TimeLimiter TimeLimiter { get; set; } = TimeLimiter.GetFromMaxCountByInterval(100, TimeSpan.FromMinutes(1));
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public bool UseRequestLimit { get; set; } = true;
    public bool ThrowExceptions { get; set; } = true;

    private async Task<TOutput> SendImpl<TOutput>(IRequest<TOutput> request,
        CancellationToken cancellationToken = default) where TOutput : ResponseBase
    {
        var jsonSerializerOptions = new JsonSerializerOptions { IgnoreNullValues = true };
        jsonSerializerOptions.Converters.Add(new BoolConverter());
        jsonSerializerOptions.Converters.Add(new StringToNullableDecimalConverter());
        var data = new Dictionary<string, string>
        {
            { "method", JsonNamingPolicy.CamelCase.ConvertName(request.GetType().Name) },
            // https://stackoverflow.com/questions/58570189/is-there-a-built-in-way-of-using-snake-case-as-the-naming-policy-for-json-in-asp
            { "parameters", JsonSerializer.Serialize((object)request, jsonSerializerOptions) }
        };

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.baselinker.com/connector.php")
        {
            Content = new FormUrlEncodedContent(data),
        };
            
        requestMessage.Headers.Add("X-BLToken", _token);

        var responseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
        var output = await responseMessage.Content.ReadFromJsonAsync<TOutput>(jsonSerializerOptions, cancellationToken);
        if (output!.IsSuccessStatus == false && ThrowExceptions)
        {
            throw new BaseLinkerException(output.ErrorCode!, output.ErrorMessage!);
        }
        return output;
    }
        
    public Task<TOutput> SendAsync<TOutput>(IRequest<TOutput> request, CancellationToken cancellationToken = default) where TOutput : ResponseBase
    {
        return UseRequestLimit ? TimeLimiter.Enqueue(() => SendImpl(request, cancellationToken), cancellationToken) : SendImpl(request, cancellationToken);
    }
}