namespace EnhancedNavigation.Models;

public sealed class Character
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Class is required")]
    public string Class { get; set; } = string.Empty;

    [Range(0, 100, ErrorMessage = "Health points must be between 0 and 100")]
    public int HealthPoints { get; set; }

    [Range(0, 100, ErrorMessage = "Mana points must be between 0 and 100")]
    public int ManaPoints { get; set; }

    [MaxLength(500, ErrorMessage = "Backstory cannot exceed 500 characters.")]
    public string Backstory { get; set; } = string.Empty;
}
