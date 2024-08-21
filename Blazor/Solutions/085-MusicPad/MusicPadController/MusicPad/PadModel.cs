namespace MusicPadController.MusicPad;

public sealed class PadModel(string soundName, string soundLocation, string key)
{
    public string Id => $"pad-{Key}";
    public string SoundName { get; set; } = soundName;
    public string SoundLocation { get; set; } = soundLocation;
    public string Key { get; set; } = key;
}
