namespace Domain.Models;

public sealed class Person
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName { get => FirstName + " " + LastName; }
    public DateTime BirthDate { get; set; }
}
