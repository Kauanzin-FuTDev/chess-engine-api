using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Pawn : Piece
{
    public Pawn(Color color, Position pos, Board board) : base(color,pos,board)
    {
        
    }
    /*
    public override bool IsValid(Position from, Position to, Board board)
    {
        if (from.Row == 2 || from.Row == 6)
        {
            
        }
    }
    */
}