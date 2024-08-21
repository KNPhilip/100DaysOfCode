namespace XClone.Data.Domain;

public class Tweet
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? PictureLocation { get; set; }
    public ApplicationUser? Author { get; set; }
    public List<ApplicationUser>? LikedBy { get; set; }
    public List<ApplicationUser>? RetweetedBy { get; set; }
    public List<ApplicationUser>? QuotedBy { get; set; }
    public List<ApplicationUser>? BookmarkedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int Likes { get; set; }
    public Tweet? AnsweredTweet { get; set; }
    public List<Tweet>? Replies { get; set; }
    public bool IsRootTweet { get => AnsweredTweet is null; }
}
