namespace FullStack.Data;

public static class SeedData
{
    public static List<VideoGame> VideoGames()
    {
        return [
                new VideoGame
                {
                    Id = 1,
                    Title = "Grand Theft Auto 5",
                    ReleaseYear = 2013,
                    PublisherId = 1,
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Red Dead Redemption 2",
                    ReleaseYear = 2018,
                    PublisherId = 1,
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Grand Theft Auto 6",
                    ReleaseYear = 2025,
                    PublisherId = 1,
                },
                new VideoGame
                {
                    Id = 4,
                    Title = "Minecraft",
                    ReleaseYear = 2011,
                    PublisherId = 2,
                },
                new VideoGame
                {
                    Id = 5,
                    Title = "Cyberpunk 2077",
                    ReleaseYear = 2020,
                    PublisherId = 3,
                },
                new VideoGame
                {
                    Id = 6,
                    Title = "Detroit: Become Human",
                    ReleaseYear = 2018,
                    PublisherId = 4,
                },
                new VideoGame
                {
                    Id = 7,
                    Title = "God of War Ragnarök",
                    ReleaseYear = 2022,
                    PublisherId = 5
                },
                new VideoGame
                {
                    Id = 8,
                    Title = "The Witcher 3",
                    ReleaseYear = 2015,
                    PublisherId = 3,
                }
            ];
    }

    public static List<Publisher> Publishers()
    {
        return [
                new Publisher
                {
                    Id = 1,
                    Name = "Rockstar Games",
                    Bio = "Rockstar Games is a video game publisher that is a wholly owned subsidiary of Take-Two Interactive. The publisher is known for the Grand Theft Auto, Max Payne, and Red Dead series."
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Mojang",
                    Bio = "Mojang Studios is a Swedish video game developer and a studio of Xbox Game Studios based in Stockholm. It was founded by Markus Persson in 2009 as Mojang Specifications, inheriting the name from a previous video game venture he left two years prior."
                },
                new Publisher
                {
                    Id = 3,
                    Name = "CD Projekt",
                    Bio = "CD Projekt S.A. is a Polish video game developer, publisher and distributor based in Warsaw, founded in May 1994 by Marcin Iwiński and Michał Kiciński. They are mostly known for their The Witcher series."
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Quantic Dream",
                    Bio = "Quantic Dream S.A. is a French video game developer and publisher based in Paris. Founded in May 1997, Quantic Dream is known for its interactive drama story driven games such as Heavy Rain, Beyond: Two Souls, and Detroit: Become Human."
                },
                new Publisher
                {
                    Id = 5,
                    Name = "Santa Monica Studio",
                    Bio = "Santa Monica Studio is an American video game developer and part of SIE Worldwide Studios, which is owned by Sony Interactive Entertainment. They are known for their God of War series."
                }
            ];
    }
}
