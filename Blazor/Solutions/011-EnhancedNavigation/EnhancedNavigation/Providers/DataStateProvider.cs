namespace EnhancedNavigation.Providers;

public sealed class DataStateProvider : IDataStateProvider
{
    public List<Character> Characters { get; set; } = [
        new() 
        {
            Name = "Astrid",
            Class = "Warrior",
            HealthPoints = 100,
            ManaPoints = 0,
            Backstory = "Astrid is a fierce warrior who has been fighting for her kingdom for years."
        },
        new() 
        {
            Name = "Raistlin",
            Class = "Mage",
            HealthPoints = 50,
            ManaPoints = 100,
            Backstory = "Raistlin is a powerful mage who has been studying the arcane arts for decades."
        },
        new() 
        {
            Name = "Thokk",
            Class = "Barbarian",
            HealthPoints = 100,
            ManaPoints = 0,
            Backstory = "Thokk is a mighty barbarian who has been wandering the wilderness for years."
        },
        new() 
        {
            Name = "Gandalf",
            Class = "Wizard",
            HealthPoints = 75,
            ManaPoints = 100,
            Backstory = "Gandalf is a wise wizard who has been guiding the people of Middle Earth for centuries."
        },
        new() 
        {
            Name = "Merlin",
            Class = "Wizard",
            HealthPoints = 75,
            ManaPoints = 100,
            Backstory = "Merlin is a powerful wizard who has been advising the kings of Camelot for centuries."
        },
        new() 
        {
            Name = "Legolas",
            Class = "Archer",
            HealthPoints = 75,
            ManaPoints = 0,
            Backstory = "Legolas is a skilled archer who has been fighting for the elves for centuries."
        },
        new()
        {
            Name = "Conan",
            Class = "Barbarian",
            HealthPoints = 100,
            ManaPoints = 0,
            Backstory = "Conan is a mighty barbarian who has been wandering the wilderness for years."
        },
        new()
        {
            Name = "Xena",
            Class = "Warrior",
            HealthPoints = 100,
            ManaPoints = 0,
            Backstory = "Xena is a fierce warrior who has been fighting for her kingdom for years."
        }
    ];

    public void CreateGameCharacter(Character newCharacter)
    {
        Characters.Add(newCharacter);
    }

    public List<Character> GetCharacters()
    {
        return Characters;
    }

    public Character? GetGameCharacterByName(string name)
    {
        return Characters.Find(c => c.Name.Equals(name));
    }
}
