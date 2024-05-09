namespace CleanBlog.Application.ArticleService.Dtos
{
    public record struct ArticleResponseDto(
            int Id,
            string Title,
            string? Content,
            DateTime DatePublished,
            bool IsPublished
        )
    {
    }
}
