using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Tower : Piece
{
    public Tower(Color color) : base(color)
    {
    }

    public override bool IsValid(Position from, Position to, Board board)
    {
        if(from.Column == to.Column || from.Row == to.Row) return true;
        
        return false;
    }
}