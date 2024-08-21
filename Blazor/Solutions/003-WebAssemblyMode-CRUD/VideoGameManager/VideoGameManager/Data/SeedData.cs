namespace VideoGameManager.Data;

public sealed class SeedData
{
    public static List<VideoGame> VideoGames()
    {
        return [
                new VideoGame
                {
                    Id = 1,
                    Title = "Grand Theft Auto 5",
                    Publisher = "Rockstar Games",
                    ReleaseYear = 2013
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Red Dead Redemption 2",
                    Publisher = "Rockstar Games",
                    ReleaseYear = 2018
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Grand Theft Auto 6",
                    Publisher = "Rockstar Games",
                    ReleaseYear = 2025
                },
                new VideoGame
                {
                    Id = 4,
                    Title = "Minecraft",
                    Publisher = "Mojang",
                    ReleaseYear = 2011
                },
                new VideoGame
                {
                    Id = 5,
                    Title = "Cyberpunk 2077",
                    Publisher = "CD Project",
                    ReleaseYear = 2020
                },
                new VideoGame
                {
                    Id = 6,
                    Title = "Detroit: Become Human",
                    Publisher = "Quantic Dream",
                    ReleaseYear = 2018
                },
                new VideoGame
                {
                    Id = 7,
                    Title = "God of War Ragnarök",
                    Publisher = "Santa Monica Studio",
                    ReleaseYear = 2022
                },
                new VideoGame
                {
                    Id = 8,
                    Title = "The Witcher 3",
                    Publisher = "CD Project",
                    ReleaseYear = 2015
                }
            ];
    }
}
