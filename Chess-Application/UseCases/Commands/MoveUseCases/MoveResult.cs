using Chess_Application.Dtos;

namespace Chess_Application.UseCases.Commands.MoveUseCases;

public class MoveResult
{
    public bool Success { get; init; }
    public string Message { get; init; }
    
    public PieceView PieceMoved { get; init; }
    
    public bool IsCheck { get; init; }
    public bool IsCheckMate { get; init; }
    
    public Guid GameId { get; init; }
}