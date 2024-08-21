namespace Lookup.Models;


public sealed class ApiResponse
{
    public Meta? meta { get; set; }
    public List<Person> data { get; set; } = [];
}

public sealed class Meta
{
    public Pagination? pagination { get; set; }
}

public sealed class Pagination
{
    public int total { get; set; }
    public int pages { get; set; }
    public int page { get; set; }
    public int limit { get; set; }
    public Links? links { get; set; }
}

public sealed class Links
{
    public object? previous { get; set; }
    public string? current { get; set; }
    public string? next { get; set; }
}
