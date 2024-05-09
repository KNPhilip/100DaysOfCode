using CleanBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Infrastructure.Repositories;

public sealed class ArticleRepository(
    ApplicationDbContext dbContext) : IArticleRepository
{
    public async Task<Article> CreateArticleAsync(Article article)
    {
        dbContext.Articles.Add(article);
        await dbContext.SaveChangesAsync();
        return article;
    }

    public async Task<bool> DeleteArticleAsync(int id)
    {
        Article? articleToDelete = await GetArticleByIdAsync(id);
        if (articleToDelete is null)
        {
            return false;
        }

        dbContext.Articles.Remove(articleToDelete);
        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        return await dbContext.Articles.ToListAsync();
    }

    public async Task<Article?> GetArticleByIdAsync(int id)
    {
        return await dbContext.Articles.FindAsync(id);
    }

    public async Task<Article?> UpdateArticleAsync(Article article)
    {
        Article? articleToUpdate = await GetArticleByIdAsync(article.Id);
        if (articleToUpdate is null)
        {
            return null;
        }

        articleToUpdate.Title = article.Title;
        articleToUpdate.Content = article.Content;
        articleToUpdate.DatePublished = article.DatePublished;
        articleToUpdate.IsPublished = article.IsPublished;
        articleToUpdate.DateLastUpdated = DateTime.Now;

        await dbContext.SaveChangesAsync();

        return article;
    }
}
