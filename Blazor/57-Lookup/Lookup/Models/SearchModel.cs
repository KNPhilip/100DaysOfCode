using System.ComponentModel.DataAnnotations;

namespace Lookup.Models;

public sealed class SearchModel
{
    [Required, MinLength(2)]
    public string? SearchText { get; set; }
}
