using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Dice
    {
        public int ThrowDice()
        {
            Random rnd = new Random();
            return rnd.Next(1, 7);
        }
    }
}
