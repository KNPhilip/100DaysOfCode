using OpenAI;

namespace BlazorGPTClient.Models;

public sealed class MessageSave
{
    public string? Prompt { get; set; }
    public Role Role { get; set; }
    public int Tokens { get; set; }
}
