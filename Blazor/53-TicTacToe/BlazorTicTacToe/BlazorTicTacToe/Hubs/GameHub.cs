namespace BlazorTicTacToe.Hubs;

public sealed class GameHub : Hub
{
    private static readonly List<GameRoom> _rooms = [];

    public async sealed override Task OnConnectedAsync()
    {
        Console.WriteLine($"Player with Id '{Context.ConnectionId}' connected.");

        await Clients.Caller.SendAsync("Rooms",
            _rooms.OrderBy(r => r.RoomName));
    }

    public async Task<GameRoom> CreateRoom(string name, string playerName)
    {
        string roomId = Guid.NewGuid().ToString();
        GameRoom room = new(roomId, name);
        _rooms.Add(room);

        Player newPlayer = new(Context.ConnectionId, playerName);
        room.TryAddPlayer(newPlayer);

        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        await Clients.All.SendAsync("Rooms", _rooms.OrderBy(r => r.RoomName));

        return room;
    }

    public async Task<GameRoom?> JoinRoom(string roomId, string playerName)
    {
        GameRoom? room = _rooms.FirstOrDefault(r => r.RoomId == roomId);
        if (room is not null)
        {
            Player newPlayer = new(Context.ConnectionId, playerName);
            if (room.TryAddPlayer(newPlayer))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
                await Clients.Group(roomId).SendAsync("PlayerJoined", newPlayer);
                return room;
            }
        }
        return null;
    }

    public async Task StartGame(string roomId)
    {
        GameRoom? room = _rooms
            .FirstOrDefault(r => r.RoomId == roomId);
        if (room is not null)
        {
            room.Game.StartGame();
            await Clients.Group(roomId).SendAsync("UpdateGame", room);
        }
    }
    
    public async Task MakeMove(string roomId, int row, int col, string playerId)
    {
        GameRoom? room = _rooms.FirstOrDefault(r => r.RoomId == roomId);
        if (room is not null && room.Game.MakeMove(row, col, playerId))
        {
            room.Game.Winner = room.Game.CheckWinner();
            room.Game.IsDraw = room.Game.CheckDraw()
                && string.IsNullOrEmpty(room.Game.Winner);
            if (!string.IsNullOrEmpty(room.Game.Winner) || room.Game.IsDraw)
            {
                room.Game.GameOver = true;
            }

            await Clients.Group(roomId).SendAsync("UpdateGame", room);
        }
    }
}
