namespace SSRForms.Services;

public sealed class DataStateService : IDataStateService
{
    public List<Character> Characters { get; set; } = [
            new Character
            {
                Id = 1,
                Name = "Peter Parker",
                Bio = "Peter Parker is a high school student and a superhero with spider-like abilities, fighting crime!",
                BirthDate = new DateTime(2001, 1, 1),
                TeamId = 1,
                DifficultyId = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png"
            }
        ];

    public List<Difficulty> Difficulties { get; set; } = [
            new Difficulty { Id = 1, Title = "Easy" },
            new Difficulty { Id = 2, Title = "Medium" },
            new Difficulty { Id = 3, Title = "Hard" }
        ];

    public List<Team> Teams { get; set; } = [
            new Team { Id = 1, Name = "Avengers" },
            new Team { Id = 2, Name = "Guardians of the Galaxy" }
        ];
}
