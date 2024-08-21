using MusicPadController.MusicPad;
using Microsoft.JSInterop;

namespace MusicPadController.MusicPad;

public sealed class SoundPlayer(IJSRuntime jSRuntime) : ISoundPlayer
{
    private readonly IJSRuntime _jSRuntime = jSRuntime;
    private const string JSFUNCTION = "playaudio";

    public async Task Play(string sound, string pressedPadId)
    {
        if (string.IsNullOrEmpty(sound))
        {
            return;
        } 
        await _jSRuntime.InvokeVoidAsync(JSFUNCTION, sound, pressedPadId);
    }
}
