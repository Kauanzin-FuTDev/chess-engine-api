using Chess_Domain.Chess_game;
using Chess_Domain.Repository;

namespace Chess_Application.UseCases.StartGame;

public class StartGameHandler
{
    private readonly IChessGameRepository _repository;

    public StartGameHandler(IChessGameRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(StartGameCommand command)
    {
        ChessGame game = new ChessGame();
        await _repository.SaveAsync(game);
    }
    
    
}