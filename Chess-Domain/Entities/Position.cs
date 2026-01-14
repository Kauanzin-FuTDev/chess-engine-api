namespace Chess_Domain.Entities;

public class Position
{
    public int Collumn { get; set; }
    public int Row { get; set; }
    
    
    public Position(int collumn, int row)
    {
        Collumn = collumn;
        Row = row;
    }
}