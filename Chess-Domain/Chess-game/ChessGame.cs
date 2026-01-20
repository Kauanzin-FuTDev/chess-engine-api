using System.ComponentModel.Design;
using Chess_Domain.Chess_game.Pieces;
using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;
using Chess_Domain.Exception;

namespace Chess_Domain.Chess_game;

public class ChessGame
{
    public Guid Id { get; set; }
    public Board Board { get;  set; }
    private int Turn { get; set; }
    private Color GamerColor { get; set; }
    private int PieceQuantity => Board.CountPieces();
   

    private ChessGame()
    {
        Id = Guid.NewGuid();
        Board = new Board();
        Turn = 1;
        GamerColor = Color.White;
        SetUpPieces();
    }
   

    public static ChessGame Start()
    {
        ChessGame game = new ChessGame();
        return game;    
    }
    
    public void Movement(Position from, Position to)
    {
        Piece p = Board.PiecePosition(from);

        if (!this.Board.ValidMove(p, from, to))
            throw new DomainException("Move not valid");
        Board.RemovePiece(from);
        Piece capPiece = Board.PiecePosition(to);
        if (capPiece != null)
            Board.RemovePiece(to);
        p.IncreaseQuantityMove();
        Board.AddPiece(p, to);
    }
    
    private void SetUpPieces()
    {   //brancas
        for (int column = 0; column < 8; column++)
        {
            Board.AddPiece(new Pawn(Color.White), new Position(column, 1));
        }
        for(int column = 0; column < 8; column +=7)
        {
            Board.AddPiece(new Tower(Color.White), new Position(column, 0));
        }

        for (int column = 1; column < 8; column+=5)
        {
            Board.AddPiece(new Knight(Color.White), new Position(column, 0));
        }

        for (int column = 2; column < 8; column+=3)
        {
            Board.AddPiece(new Bishop(Color.White), new Position(column, 0));
        }
        //Rinha
        Board.AddPiece(new Queen(Color.White), new Position(3, 0));
        //Rei
        Board.AddPiece(new King(Color.White), new Position(4, 0));
        
        
        //pretas
        for (int column = 0; column < 8; column++)
        {
            Board.AddPiece(new Pawn(Color.Black), new Position(column, 6));
        }
        
        for (int column = 0; column < 8; column += 7)
        {
            Board.AddPiece(new Tower(Color.Black), new Position(column, 7));
        }

        for (int column = 1; column < 8; column += 5)
        {
            Board.AddPiece(new Knight(Color.Black), new Position(column, 7));
        }
        for(int column = 2; column < 8; column +=3)
        {
            Board.AddPiece(new Bishop(Color.Black), new Position(column, 7));
        }
        Board.AddPiece(new Queen(Color.Black), new Position(3, 7));
        Board.AddPiece(new King(Color.Black), new Position(4, 7));
    }


    public bool IsGameOver()
    {
        if(PieceQuantity == 0) return true;
        return false;
    }
    
}