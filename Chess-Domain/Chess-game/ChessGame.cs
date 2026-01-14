using System.ComponentModel.Design;
using Chess_Domain.Chess_game.Pieces;
using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game;

public class ChessGame
{
    private Board Board { get;  set; }
    private int Turn { get; set; }
    private Color GamerColor { get; set; }

    public ChessGame()
    {
        Board = new Board();
        Turn = 1;
        GamerColor = Color.White;
        SetUpPieces();
    }

    public void Movement(Position from, Position to)
    {
        Piece p = Board.RemovePiece(from);
        p.IncreaseQuantityMove();
        Piece pieceCapture = Board.RemovePiece(to);
        Board.AddPiece(p, to);
    }
    
    private void SetUpPieces()
    {   //branco
        for (int column = 0; column < 8; column++)
        {
            Board.AddPiece(new Pawn(Color.White), new Position(column, 1));
        }
        for(int column = 0; column < 8; column +=7)
        {
            Board.AddPiece(new Tower(Color.White), new Position(column, 0));
        }
        
        
        //preto
        for (int column = 0; column < 8; column++)
        {
            Board.AddPiece(new Pawn(Color.Black), new Position(column, 6));
        }
        
        for (int column = 0; column < 8; column += 7)
        {
            Board.AddPiece(new Tower(Color.Black), new Position(column, 7));
        }
        
        
    }
    
    
    
}