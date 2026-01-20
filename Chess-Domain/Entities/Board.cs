using Chess_Domain.Entities.Commun;
using Chess_Domain.Exception;

namespace Chess_Domain.Entities;

public class Board
{
    #region Attributes
    private int Columns { get;}
    private int Rows { get; }
    private readonly Piece[,] _pieces;
    
    #endregion
    
    #region Constructor
    public Board(int columns = 8, int rows = 8)
    {
        Columns = columns;
        Rows = rows;
        _pieces = new Piece[columns, rows];
        
    }
    #endregion
    
    #region Methods
    
    public bool ValidMove(Piece piece,Position from, Position to)
    {
       if(!piece.Move(from, to))
       {
           return false;
       }
       
       else if (ExistsPiece(to))
       {
           Piece aux = PiecePosition(to);
           if(aux._color == piece._color) 
               return false;
           return true;
       }

       else return true;
    }
    
    
    
    public void AddPiece(Piece piece, Position pos)
    {     
        if (ExistsPiece(pos))
            throw new DomainException("There is already a piece in this position");
        
        _pieces[pos.Column, pos.Row] = piece;
        piece.Position = pos;
    }
    
    public Piece RemovePiece(Position pos)
    {
        if (PiecePosition(pos) == null)
            return null;
        Piece aux = PiecePosition(pos);
        aux.Position = null;
        _pieces[pos.Column, pos.Row] = null;
        return aux;
    }

    private bool ExistsPiece(Position pos)
    {
        ValidePosition(pos);
        return PiecePosition(pos) != null;
    }
    
    public Piece PiecePosition(Position pos)
    {
        return _pieces[pos.Column, pos.Row];
    }

    private bool ValidePosition(Position pos)
    {
        if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
            throw new DomainException("Position not valid");
        
        return true;
    }
    
    
    public IEnumerable<Piece> GetPieces()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                var piece = _pieces[column, row];
                if (piece != null)
                    yield return piece;
            }
        }
    }
    
    public int CountPieces()
    {
        int count = 0;
        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                Position pos = new Position(column, row);
                if (PiecePosition(pos) != null)
                {
                    count++;
                }
            }
        }
        return count;
    }
    

    #endregion
    
}