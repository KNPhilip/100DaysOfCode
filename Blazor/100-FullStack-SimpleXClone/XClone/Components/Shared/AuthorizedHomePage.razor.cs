using Microsoft.EntityFrameworkCore;
using XClone.Data.Domain;

namespace XClone.Components.Shared;

public sealed partial class AuthorizedHomePage
{
    private ApplicationUser? user;
    public TweetModel FormModel { get; set; } = new();
    public List<Tweet> Tweets { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        if (HttpContextAccessor.HttpContext is not null && HttpContextAccessor.HttpContext.User.Identity!.IsAuthenticated)
        {
            string? userId = UserManager.GetUserId(HttpContextAccessor.HttpContext.User);
            user = await UserManager.FindByIdAsync(userId!);
        }
        Tweets = await DbContext.Tweets.Include(x => x.Author).ToListAsync();
    }

    private async Task OnValidSubmitAsync()
    {
        Tweet tweet = new()
        {
            Text = FormModel.Text,
            Author = user,
            CreatedAt = DateTime.UtcNow
        };

        await DbContext.Tweets.AddAsync(tweet);
        await DbContext.SaveChangesAsync();
        NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
    }

    private async Task DeleteTweetAsync(int id)
    {
        Tweet? tweet = await DbContext.Tweets.FindAsync(id);
        if (tweet is not null)
        {
            DbContext.Tweets.Remove(tweet);
            await DbContext.SaveChangesAsync();
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
    }

    private static string FormatTimeSpan(DateTime? nullableDateTime)
    {
        if (!nullableDateTime.HasValue)
        {
            return "DateTime is null";
        }

        DateTime utcNow = DateTime.UtcNow;
        DateTime dateTimeValue = nullableDateTime.Value;

        TimeSpan difference = utcNow - dateTimeValue;

        int years = difference.Days / 365;
        int months = (difference.Days % 365) / 30;
        int days = difference.Days % 30;
        int hours = difference.Hours;
        int minutes = difference.Minutes;
        int seconds = difference.Seconds;

        string formatted = "";
        if (years > 0)
        {
            formatted = $"{years}y";
        }
        else if (months > 0)
        {
            formatted = $"{months}mo";
        }
        else if (days > 0)
        {
            formatted = $"{days}d";
        }
        else if (hours > 0)
        {
            formatted = $"{hours}h";
        }
        else if (minutes > 0)
        {
            formatted = $"{minutes}m";
        }
        else
        {
            formatted = $"{seconds}s";
        }

        return formatted.Trim();
    }

    public sealed class TweetModel
    {
        public string Text { get; set; } = string.Empty;
    }
}
