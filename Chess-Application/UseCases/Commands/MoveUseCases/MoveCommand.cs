
namespace Chess_Application.UseCases.Commands.MoveUseCases;

public class MoveCommand
{
    public Guid GameId { get; init; }
    public string From { get; init; }
    public string To { get; init; }
}