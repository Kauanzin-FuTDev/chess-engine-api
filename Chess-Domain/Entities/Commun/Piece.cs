using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Entities.Commun;

public abstract class Piece
{
    public int QuantityMove { get; protected set; }
    public  Color _color { get; private set; }
    public Position Position { get; protected set; }
    public Board Board { get; protected set; }
    
    public Piece(Color color, Position position, Board board)
    {
        _color = color;
        Position = position;
        Board = board;
        QuantityMove = 0;
    }


    public abstract bool IsValid(Position from, Position to, Board board);
}