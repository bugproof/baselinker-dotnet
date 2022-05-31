using Microsoft.Extensions.DependencyInjection;

namespace BaseLinkerApi.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
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
        services.AddHttpClient<IBaseLinkerApiClient, InjectableBaseLinkerApiClient>(); }

    /// <summary>
    /// Registers IBaseLinkerApiClient
    /// </summary>
    /// <param name="services"></param>
    /// <param name="token"></param>
    public static void AddBaseLinker(this IServiceCollection services,string token)
    {
        ArgumentNullException.ThrowIfNull(token);
        services.AddOptions<BaseLinkerOptions>().Configure(c => c.Token = token);
        services.AddHttpClient<IBaseLinkerApiClient, InjectableBaseLinkerApiClient>();
    }
    
}