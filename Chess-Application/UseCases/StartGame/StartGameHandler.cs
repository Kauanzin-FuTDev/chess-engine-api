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

    public async Task<StartGameResult> Handle(StartGameCommand command)
    {
        var game = ChessGame.Start();
        
        await _repository.SaveAsync(game);

        if (game == null)
        {
            return new StartGameResult
            {
                Success = false,
                GameId = Guid.Empty
            };
        }
        return new StartGameResult
        {
            Success = true,
            GameId = game.Id
        };
    }
    
    
}