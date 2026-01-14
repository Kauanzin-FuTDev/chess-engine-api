using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Entities.Commun;

public abstract class Piece
{
    public int QuantityMove { get; protected set; }
    public  Color _color { get; private set; }
    public Position Position { get; set; }
    public Board Board { get; set; }

    protected Piece(Color color ,Board board)
    {
        Position = null;
        _color = color;
        Board = board;
        QuantityMove = 0;
    }
    public void IncreaseQuantityMove()
    {
        QuantityMove++;
    }


    public abstract bool IsValid(Position from, Position to, Board board);
}