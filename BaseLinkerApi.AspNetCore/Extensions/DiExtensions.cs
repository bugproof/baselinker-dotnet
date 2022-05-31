using BaseLinkerApi.AspNetCore.Options;
using Microsoft.Extensions.DependencyInjection;

namespace BaseLinkerApi.AspNetCore.Extensions;

public static class DiExtensions
{
    /// <summary>
    /// Registers IBaseLinkerApiClient
    /// Example usage: services.AddBaseLinker(o => configuration.GetSection("BaseLinker").Bind(o));
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    public static void AddBaseLinker(this IServiceCollection services,Action<BaseLinkerOptions> configure)
    {
        services.AddOptions<BaseLinkerOptions>().Configure(configure);
        services.AddHttpClient<IBaseLinkerApiClient, BaseLinkerApiClientAspNet>(); }

    /// <summary>
    /// Registers IBaseLinkerApiClient
    /// </summary>
    /// <param name="services"></param>
    /// <param name="token"></param>
    public static void AddBaseLinker(this IServiceCollection services,string token)
    {
        ArgumentNullException.ThrowIfNull(token);
        services.AddOptions<BaseLinkerOptions>().Configure(c => c.Token = token);
        services.AddHttpClient<IBaseLinkerApiClient, BaseLinkerApiClientAspNet>();
    }
    
}