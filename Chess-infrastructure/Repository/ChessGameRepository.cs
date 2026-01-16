using Chess_Domain.Chess_game;
using Chess_Domain.Repository;

namespace Chess_infrastructure.Repository;

public class ChessGameRepository : IChessGameRepository
{
    private static readonly Dictionary<Guid, ChessGame> _games = new();
    
    public Task<ChessGame> GetById(Guid id)
    {
        _games.TryGetValue(id, out var game);
        return Task.FromResult(game);
    }

    public Task SaveAsync(ChessGame game)
    {
        _games[game.Id] = game;
        return Task.CompletedTask;
    }
}