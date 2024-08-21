namespace TimeTracker.Domain.Dtos.Login
{
    public record struct LoginResponseDto(
        bool IsSuccessful,
        string? Error = null,
        string? Token = null
    );
}
