namespace EnhancedNavigation.Providers;

public interface IDataStateProvider
{
    List<Character> Characters { get; set; }

    void CreateGameCharacter(Character newCharacter);
    List<Character> GetCharacters();
    Character? GetGameCharacterByName(string name);
}
