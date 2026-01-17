using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game.Pieces;

public class King : Piece
{
    public King(Color color) : base(color)
    {
    }
    
    public override string ToString()
    {
        return "K";
    }
    public override bool Move(Position from, Position to)
    {
        int columnDiff = Math.Abs(from.Column - to.Column);
        int rowDiff = Math.Abs(from.Row - to.Row);

        return columnDiff <= 1 || rowDiff <= 1 && (columnDiff > 0 || rowDiff > 0);
    }
}