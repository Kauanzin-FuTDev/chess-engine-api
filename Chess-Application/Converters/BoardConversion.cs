using Chess_Domain.Entities;

namespace Chess_Application.Converters;

public static class BoardConversion
{
    public static Position ToPosition(char column, int row)
    {
        return new Position(column - 'a', row - 1);
    }
}