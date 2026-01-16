using Chess_Application.Converters;
using Chess_Application.Dtos;
using Chess_Domain.Repository;

namespace Chess_Application.UseCases.ViewGame;

public class ViewGameHandler
{
    private readonly IChessGameRepository _repository;
    
    public ViewGameHandler(IChessGameRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ViewGameResult> Handle(ViewGameCommand command)
    {
        var game = await _repository.GetById(command.GameId);
        
        if (game == null)
            throw new ApplicationException("Game not found");
        
        var píeces = game.Board.GetPieces().Select(p => new PieceView
        {
            Type = p.GetType().Name,
            Color = p._color.ToString(),
            Position = $"{(char)('a' + p.Position.Column)}{p.Position.Row + 1}"
        }).ToList();
        
        if(píeces == null ) throw new ApplicationException("CANT GET PIECES");
        
        
        return new ViewGameResult
        {
            GameId = game.Id,
            CurrentTurn = null,
            PieceCount = game.Board.CountPieces(),
            IsGameOver = game.IsGameOver(),
            Pieces = píeces,
        };
    }
    
    

}