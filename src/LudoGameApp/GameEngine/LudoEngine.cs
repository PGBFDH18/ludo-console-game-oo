using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class LudoEngine
    {
        private static int Counter = 0;
        private int nrOfPlayer;
        public bool OkToStart { get; set; }
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

        }

        public void Movement(int playerNr, int diceValue, int pieceNr)
        {
            Players[playerNr - 1].Pieces[pieceNr].MovePiece(diceValue);
        }


        public string nextTurn()
        {
            if (Counter == NrOfPlayer)
            {
                Counter = 0;
            }
            string x = Players[Counter].Color;
            Counter++;
            return x;
        }





    }
}
