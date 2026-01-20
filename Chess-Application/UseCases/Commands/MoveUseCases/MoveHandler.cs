using Chess_Application.Converters;
using Chess_Domain.Chess_game;
using Chess_Domain.Repository;


namespace Chess_Application.UseCases.Commands.MoveUseCases;

public class MoveHandler
{
    private readonly IChessGameRepository _repository;
    
    public MoveHandler(IChessGameRepository repository)
    {
        _repository = repository;
    }


    public async Task<MoveResult> Handle(MoveCommand command)
    {
        ChessGame game = await _repository.GetById(command.GameId);
        if (game == null)
            throw new ApplicationException("Game not found!");

        var from = BoardConversion.ToPosition(command.From[0], int.Parse(command.From[1].ToString()));
        var to = BoardConversion.ToPosition(command.To[0], int.Parse(command.To[1].ToString()));

        game.Movement(from, to);
        
        await _repository.SaveAsync(game);

         return new MoveResult
        {
            GameId = game.Id,
            Success = true,
            IsCheck = false,
            IsCheckMate = false,
            Message = $"Moved from : {from} to: {to}",
            PieceMoved = new Dtos.PieceView
            {
                Type = game.Board.PiecePosition(to).GetType().Name,
                Color = game.Board.PiecePosition(to)._color.ToString(),
                Position = command.To
            }
        };




    }
}