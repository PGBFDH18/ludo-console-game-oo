using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class LudoEngine
    {
        private int nrOfPlayer;
        private bool OkToStart;
        public int NrOfPlayer
        {
            get
            {
                return nrOfPlayer;
            }
            set
            {
                if (value < 2 || value > 4)
                {
                    OkToStart = false;
                }
                else
                {
                    OkToStart = true;
                    nrOfPlayer = value;
                }
            }
        }
        public List<Player> Players { get; set; }

        public LudoEngine(int numberOfPlayers)
        {
            NrOfPlayer = numberOfPlayers;
            if (OkToStart)
            {
                Players = new List<Player>();
                for (int i = 0; i < NrOfPlayer; i++)
                {
                    Players.Add(new Player(i));

                }
            }
            else
            {
                Console.WriteLine("Game will not start");
            }

        }

    }
}
