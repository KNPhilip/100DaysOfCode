using BlazorGPTClient.Models;
using Microsoft.JSInterop;
using OpenAI.Chat;
using OpenAI;

namespace BlazorGPTClient.Components.Pages;

public partial class Home
{
    private string Organization = string.Empty;
    private string ApiKey = string.Empty;
    private List<MessageSave> messages = [];

    private string prompt = "Write a 10 word description of OpenAI ChatGPT";
    private string ErrorMessage = "";
    private bool Processing = false;
    private int TotalTokens = 0;

    protected sealed override void OnInitialized()
    {
        Organization = Configuration["OpenApi:Organization"]!;
        ApiKey = Configuration["OpenApi:ApiKey"]!;
    }

    protected sealed override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            await JSRuntime.InvokeAsync<string>("ScrollToBottom", "chatcontainer");
        }
        catch
        {
        }
    }

    private void RestartChatGpt()
    {
        prompt = "Write a 10 word description of OpenAI ChatGPT";
        messages = [];
        TotalTokens = 0;
        ErrorMessage = "";
        StateHasChanged();
    }

    private async Task CallChatGptAsync()
    {
        try
        {
            Processing = true;
            StateHasChanged();
            ErrorMessage = string.Empty;

            OpenAIClient api = new(new OpenAIAuthentication(ApiKey, Organization));
            List<Message> chatMessages = [];
            chatMessages.Add(new Message(Role.System, "You are helpful Assistant"));

            foreach (MessageSave item in messages)
            {
                chatMessages.Add(new Message(item.Role, item.Prompt));
            }

            chatMessages.Add(new Message(Role.User, prompt));
            ChatRequest chatRequest = new ChatRequest(chatMessages);
            ChatResponse result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

            messages.Add(new MessageSave
            {
                Prompt = prompt,
                Role = Role.User,
                Tokens = (int)result.Usage.PromptTokens!
            });
            messages.Add(new MessageSave
            {
                Prompt = result.FirstChoice.Message,
                Role = Role.Assistant,
                Tokens = (int)result.Usage.CompletionTokens!
            });
            TotalTokens = TotalTokens + (int)result.Usage.TotalTokens!;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            prompt = string.Empty;
            Processing = false;
            StateHasChanged();
        }
    }
}
