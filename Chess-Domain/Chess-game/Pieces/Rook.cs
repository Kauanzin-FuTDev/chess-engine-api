using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Rook : Piece
{
    public override string ToString() => "R";
    public Rook(Color color) : base(color)
    {
    }
    
    public override bool Move(Position from, Position to)
    {
        if (from.Column == to.Column || from.Row == to.Row)
        {
            return true;
        }
        return false;
    }
}