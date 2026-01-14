using Chess_Domain.Entities.Commun;

namespace Chess_Domain.Entities;

public class Board
{
    public int Collumns { get;}
    public int Rows { get; }       
    
    private readonly Piece[,] _pieces;

    public Board(int collumns = 8, int rows = 8)
    {
        Collumns = collumns;
        Rows = rows;
        _pieces = new Piece[collumns, rows];
    }
    
    
    public void AddPiece(Piece piece)
    {
        _pieces[piece.Position.Collumn, piece.Position.Row] = piece;
    }
}