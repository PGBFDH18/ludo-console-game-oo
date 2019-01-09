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

        public Piece()
        {
            Movement = 0;
            InNest = true;
        }

        public void MovePiece(int diceValue)
        {
            Movement += diceValue;
        }

    }
}
