namespace CleanBlog.Application.Authentication;

public sealed class RegisterUserResponse
{
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; } = new();
}
