namespace BaseLinkerApi.Extensions.DependencyInjection;

public class BaseLinkerOptions
{
    public string? Token { get; set; }
    public bool UseRequestLimit { get; set; } = true;
    public bool ThrowExceptions { get; set; } = true;
    public int MaxRequestsPerMinute { get; set; } = 100;
}