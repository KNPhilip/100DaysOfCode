namespace TimeTracker.Domain.Dtos.Account
{
    public record struct AccountRegistrationResponseDto(
        bool IsSuccessful, 
        IEnumerable<string>? Errors = null
    );
}
