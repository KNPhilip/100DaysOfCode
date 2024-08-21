namespace TimeTracker.Domain.Dtos.Project
{
    public record struct ProjectCreateDto(
        string Name,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate
    );
}
