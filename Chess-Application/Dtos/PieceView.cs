
using Chess_Application.Converters;

namespace Chess_Application.Dtos;

public class PieceView
{
    public string Type { get; init; }
    public string Color { get; init; }
    public string Position { get; init; }
}