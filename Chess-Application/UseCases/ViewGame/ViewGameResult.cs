using Chess_Application.Dtos;

namespace Chess_Application.UseCases.ViewGame;

public class ViewGameResult
{
    public Guid GameId { get; init; }
    public string PlayerWhiteId { get; init; }
    public string PlayerBlackId { get; init; }
    public string CurrentBoardState { get; init; }
    public string CurrentTurn { get; init; }
    public int PieceCount { get; init; }
    
    public bool IsGameOver { get; init; }
    
    public List<PieceView> Pieces { get; init; }
    
    
    
    
}