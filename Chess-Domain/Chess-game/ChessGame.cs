using System.ComponentModel.Design;
using Chess_Domain.Chess_game.Pieces;
using Chess_Domain.Entities;
using Chess_Domain.Entities.Commun;
using Chess_Domain.Entities.Enums;

namespace Chess_Domain.Chess_game;

public class ChessGame
{
    private Board Board { get; set; }
    private int Turn { get; set; }
    private Color Color { get; set; }

    public ChessGame()
    {
        Board = new Board();
        Turn = 1;
        Color = Color.White;
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
    {   
        Board.AddPiece(new Pawn(Color.White, Board), new BoardConversion('a' , 2).ToPosition());
    }
    
    
    
}