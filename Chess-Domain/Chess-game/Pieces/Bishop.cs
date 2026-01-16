using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Bishop : Piece
{
    public Bishop(Color color) : base(color)
    {
    }
    
    public override string ToString()
    {
        return "B";
    }
    public override bool IsValid(Position from, Position to, Board board)
    {
        return true;
    }
}