using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Queen : Piece
{
    public Queen(Color color) : base(color)
    {
    }
    
    public override string ToString()
    {
        return "Q";
    }
    public override bool IsValid(Position from, Position to, Board board)
    {
        return true;
    }
}