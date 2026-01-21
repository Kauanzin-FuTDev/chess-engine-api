using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Pawn : Piece
{
    public Pawn(Color color) : base(color) { }
    
    public override string ToString()
    {
        return "P";
    }
    public override bool Move(Position from, Position to)
    {
        if (from.Row == 1 || from.Row == 6)
        {
            if (to.Row == from.Row + 2 || to.Row == from.Row - 2 || to.Row == from.Row + 1 || to.Row == from.Row - 1)
            {
                if (to.Column == from.Column)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            if (to.Row == from.Row + 1)
            {
                if (to.Column == from.Column)
                {
                    return true;
                }
            }
            return false;
        }
    }
}