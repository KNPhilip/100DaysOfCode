﻿namespace SSR_CRUD.Models;

public sealed class VideoGame
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public int? ReleaseYear { get; set; }
}
