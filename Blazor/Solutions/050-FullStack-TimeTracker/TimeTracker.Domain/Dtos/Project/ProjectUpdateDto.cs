namespace TimeTracker.Domain.Dtos.Project
{
    public record struct ProjectUpdateDto(
        string Name,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate
    );
}
