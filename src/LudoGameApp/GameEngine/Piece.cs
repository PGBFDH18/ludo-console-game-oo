using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Piece
    {

        public int StartLocation  { get; set; }
        public int Movement { get; set; }
        public bool InNest { get; set; }
        public int PieceName { get; set; }

        public Piece(int pieceNr)
        {
            Movement = 0;
            InNest = true;
            PieceName = pieceNr;
        }

        public void MovePiece(int diceValue)
        {
            Movement += diceValue;
        }

    }
}
