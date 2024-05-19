namespace TimeTracker.Domain.Dtos.Project
{
    public record struct ProjectResponseDto(
        int Id,
        string Name,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate
    );
}
