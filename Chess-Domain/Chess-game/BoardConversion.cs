using Chess_Domain.Entities;

namespace Chess_Domain.Chess_game;

public class BoardConversion
{
    private char Column { get; set; }
    private int Row { get; set; }

    public BoardConversion(char column, int row)
    {
        Column = column;
        Row = row;
    }
    
    public Position ToPosition()
    {
        return new Position(Column - 'a', Row - 1);
    }
}