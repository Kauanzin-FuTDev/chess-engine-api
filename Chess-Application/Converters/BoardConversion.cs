using Chess_Domain.Entities;

namespace Chess_Application.Converters;

public static class BoardConversion
{
    public static Position ToPosition(char column, int row)
    {
        if (column < 'a' || column > 'h' || row < 1 || row > 8)
            throw new ApplicationException("Position not valid(ex: (a1, b2) are positiions valids!!!");
        
        return new Position(column - 'a', row - 1);
    }
}