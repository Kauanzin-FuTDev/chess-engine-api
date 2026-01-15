namespace Chess_Application.UseCases.StartGame;

public class StartGameResult
{
    public bool Success { get; init; }
    public Guid GameId { get; init; }
}