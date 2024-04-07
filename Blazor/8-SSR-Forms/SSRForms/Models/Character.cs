namespace SSRForms.Models;

public sealed class Character
{
    [Required, Range(1, int.MaxValue, ErrorMessage = "The Id can't be smaller than 1.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Please give this character a name.")]
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; } = DateTime.Now;
    public string ImageUrl { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public int DifficultyId { get; set; }
    public bool IsReadyToFight { get; set; }
}
