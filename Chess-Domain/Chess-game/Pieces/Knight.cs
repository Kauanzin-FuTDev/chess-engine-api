using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Knight : Piece
{
    public Knight(Color color) : base(color)
    {
    }
    
    
    public override string ToString()
    {
        return "K";
    }
    public override bool Move(Position from, Position to)
    {
        return true;
    }
}