namespace ShakespearTranslator.Models;

public sealed class ShakespearRoot
{
    public Success? success { get; set; }
    public Contents? contents { get; set; }
    public Error? error { get; set; }
}

public sealed class Contents
{
    public string? translation { get; set; }
    public string? translated { get; set; }
    public string? text { get; set; }
}

public sealed class Success
{
    public int total { get; set; }
}

public sealed class Error
{
    public int code { get; set; }
    public string? message { get; set; }
}