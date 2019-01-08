using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    class Player
    {
        public string Color { get; set; }

        public Player (int PlayerNumber)
        {
            if (PlayerNumber == 1)
            {
                Color = "Blue";
            }
            else if (PlayerNumber == 2)
            {
                Color = "Red";
            }
            else if (PlayerNumber == 3)
            {
                Color = "Yellow";
            }
            else
            {
                Color = "Green";
            }
        }
    }
}
