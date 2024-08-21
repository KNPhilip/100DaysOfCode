using System.ComponentModel.DataAnnotations;

namespace ShakespearTranslator.Models;

public sealed class TranslateModel
{
    [Required, MinLength(4)]
    public string Text { get; set; } = string.Empty;
}
