using System.ComponentModel.DataAnnotations;

namespace BlazorTicTacToe.Client.Dtos;

public sealed class CreateRoomDto
{
    [Required]
    public string PlayerName { get; set; } = string.Empty;
    [Required]
    public string RoomName { get; set; } = string.Empty;
}
