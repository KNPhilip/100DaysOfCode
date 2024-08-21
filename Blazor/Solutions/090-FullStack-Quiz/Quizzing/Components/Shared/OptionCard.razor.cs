using Microsoft.AspNetCore.Components;

namespace Quizzing.Components.Shared;

public sealed partial class OptionCard
{
    [Parameter]
    public string Option { get; set; } = string.Empty;
    [Parameter]
    public EventCallback<string> OnOptionSelected { get; set; }

    private async Task SelectOptionAsync()
    {
        await OnOptionSelected.InvokeAsync(Option);
    }
}
