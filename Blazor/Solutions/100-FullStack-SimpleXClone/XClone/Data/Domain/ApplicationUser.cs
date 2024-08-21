using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace XClone.Data.Domain;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [JsonIgnore]
    public string? FullName { get => FirstName + " " + LastName; }
    public string? ProfilePictureLocation { get; set; }
    public string? Handle { get; set; }
    public bool? IsVerified { get; set; }
    public List<ApplicationUser>? Followers { get; set; }
    public List<ApplicationUser>? Following { get; set; }
    public List<Tweet>? Tweets { get; set; }
    public List<Tweet>? LikedTweets { get; set; }
    public List<Tweet>? Retweets { get; set; }
    public List<Tweet>? QuotedTweets { get; set; }
    public List<Tweet>? BookmarkedTweet { get; set; }
}
