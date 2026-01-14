using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Entities.Commun;

public abstract class Piece
{
    public int QuantityMove { get; protected set; }
    public  Color _color { get; private set; }
    public Position Position { get; set; }
   

    protected Piece(Color color )
    {
        Position = null;
        _color = color;
        QuantityMove = 0;
    }
    public void IncreaseQuantityMove()
    {
        QuantityMove++;
    }


    public abstract bool IsValid(Position from, Position to, Board board);
}