using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Pawn : Piece
{
    public Pawn(Color color, Board board) : base(color,board) { }
    public override bool IsValid(Position from, Position to, Board board)
    {
        if (from.Row == 2 || from.Row == 6)
        {
            if (to.Row == from.Row + 2 || to.Row == from.Row - 2)
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