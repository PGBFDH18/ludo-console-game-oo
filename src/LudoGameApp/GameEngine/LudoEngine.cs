using System;

namespace GameEngine
{
    public class LudoEngine
    {
        private int nrOfPlayer;
        private bool OkToStart;
        public int NrOfPlayer {
            get
            {
                return nrOfPlayer;
            }
            set
            {
                if (value <2 || value > 4)
                {
                    OkToStart = false;
                    Console.WriteLine("Wrong number of players");
                }
                else
                {
                    OkToStart = true;
                    nrOfPlayer = value;
                }
            }
        }

        public void StartGame(int numberOfPlayers)
        {
            NrOfPlayer = numberOfPlayers;
            Console.WriteLine($"Game started with {nrOfPlayer} players");
        }
    }
}
