using Chess_Domain.Chess_game;

namespace Chess_Domain.Repository;

public interface IChessGameRepository
{
    Task<ChessGame> GameStart();
    Task<ChessGame> GetById(Guid id);
    Task<Guid> SaveAsync(ChessGame game);
}