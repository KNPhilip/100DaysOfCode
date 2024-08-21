namespace SSRForms.Services;

public interface IDataStateService
{
    List<Character> Characters { get; set; }
    List<Difficulty> Difficulties { get; set; }
    List<Team> Teams { get; set; }
}
