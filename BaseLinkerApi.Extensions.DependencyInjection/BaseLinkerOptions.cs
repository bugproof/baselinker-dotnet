namespace BaseLinkerApi.Extensions.DependencyInjection;

/// <summary>
/// Configuration class, that implements OptionsPattern
/// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0
/// </summary>
public class BaseLinkerOptions
{
    public string? Token { get; set; }
    
    public bool UseRequestLimit { get; set; } = true;
    
    public bool ThrowExceptions { get; set; } = true;
}