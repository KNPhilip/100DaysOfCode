namespace ComponentCommunication.States;

public sealed class SharedMessageState
{
    public event Action? OnMessageChanged;

    public string SharedMessage { get; set; } = "....";

    public void SetSharedMessage(string message)
    {
        SharedMessage = message;
        OnMessageChanged?.Invoke();
    }
}
