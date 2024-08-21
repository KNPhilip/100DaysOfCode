namespace ShakespearTranslator.Models;

public sealed class PokemonRoot
{
    public int base_happiness { get; set; }
    public int capture_rate { get; set; }
    public Color? color { get; set; }
    public List<EggGroup>? egg_groups { get; set; }
    public EvolutionChain? evolution_chain { get; set; }
    public object? evolves_from_species { get; set; }
    public List<FlavorTextEntry>? flavor_text_entries { get; set; }
    public List<object>? form_descriptions { get; set; }
    public bool forms_switchable { get; set; }
    public int gender_rate { get; set; }
    public List<Genera>? genera { get; set; }
    public Generation? generation { get; set; }
    public GrowthRate? growth_rate { get; set; }
    public Habitat? habitat { get; set; }
    public bool has_gender_differences { get; set; }
    public int hatch_counter { get; set; }
    public int id { get; set; }
    public bool is_baby { get; set; }
    public bool is_legendary { get; set; }
    public bool is_mythical { get; set; }
    public string? name { get; set; }
    public List<Name>? names { get; set; }
    public int order { get; set; }
    public List<PalParkEncounter>? pal_park_encounters { get; set; }
    public List<PokedexNumber>? pokedex_numbers { get; set; }
    public Shape? shape { get; set; }
    public List<Variety>? varieties { get; set; }
}

public sealed class Area
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class Color
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class EggGroup
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class EvolutionChain
{
    public string? url { get; set; }
}

public sealed class FlavorTextEntry
{
    public string? flavor_text { get; set; }
    public Language? language { get; set; }
    public Version? version { get; set; }
}

public sealed class Genera
{
    public string? genus { get; set; }
    public Language? language { get; set; }
}

public sealed class Generation
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class GrowthRate
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class Habitat
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class Language
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class Name
{
    public Language? language { get; set; }
    public string? name { get; set; }
}

public sealed class PalParkEncounter
{
    public Area? area { get; set; }
    public int base_score { get; set; }
    public int rate { get; set; }
}

public sealed class Pokedex
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class PokedexNumber
{
    public int entry_number { get; set; }
    public Pokedex? pokedex { get; set; }
}

public sealed class Pokemon
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class Shape
{
    public string? name { get; set; }
    public string? url { get; set; }
}

public sealed class Variety
{
    public bool is_default { get; set; }
    public Pokemon? pokemon { get; set; }
}

public sealed class Version
{
    public string? name { get; set; }
    public string? url { get; set; }
}
