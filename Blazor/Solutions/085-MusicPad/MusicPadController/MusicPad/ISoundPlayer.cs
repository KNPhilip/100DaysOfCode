namespace MusicPadController.MusicPad;

public interface ISoundPlayer
{
    Task Play(string sound, string pressedPadId);
}
