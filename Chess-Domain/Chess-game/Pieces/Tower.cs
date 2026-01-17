using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class Tower : Piece
{
    public Tower(Color color) : base(color)
    {
    }

    public override bool Move(Position from, Position to)
    {
        return true;
    }
}