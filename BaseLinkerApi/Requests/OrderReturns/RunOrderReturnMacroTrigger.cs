using System.Text.Json.Serialization;

namespace BaseLinkerApi.Requests.OrderReturns;

/// <summary>
/// The method allows you to run personal trigger for order returns automatic actions.
/// </summary>
public class RunOrderReturnMacroTrigger : IRequest
{
    /// <summary>
    /// Order return identifier from BaseLinker order manager.
    /// </summary>
    [JsonPropertyName("return_id")]
    public int ReturnId { get; set; }

    /// <summary>
    /// Identifier of personal trigger from orders automatic actions.
    /// </summary>
    [JsonPropertyName("trigger_id")]
    public int TriggerId { get; set; }
}
