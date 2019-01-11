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
        public List<Player> PlayersList { get; set; }

        public List<Tile> TileList { get; set; }

        public LudoEngine(int numberOfPlayers)
        {
            NrOfPlayer = numberOfPlayers;
            if (OkToStart)
            {
                PlayersList = new List<Player>();
                for (int i = 0; i < NrOfPlayer; i++)
                {
                    PlayersList.Add(new Player(i));

                }

                TileList = new List<Tile>();
                for (int i = 1; i <= 40; i++)
                {
                    TileList.Add(new Tile(i));
                }
            }

        }

        public void Movement(int playerNr, int diceValue, int pieceNr)
        {
            PlayersList[playerNr - 1].Pieces[pieceNr].MovePiece(diceValue);
        }


        public string[] NextTurn()
        {
            string[] x = new string[2];

            if (Counter == NrOfPlayer)
            {
                Counter = 0;
            }

            int diceThrow = Dice.ThrowDice();

            int piecesInNest = 0;
            foreach (var item in PlayersList[Counter].Pieces)
            {
                if (item.InNest)
                {
                    piecesInNest++;
                }
            }
            if (piecesInNest == 4 && diceThrow != 6)
            {
                x[0] = PlayersList[Counter].Color;
                x[1] = diceThrow + " Player cant move. Next Player";
                Counter++;
                return x;
            }
            else if(piecesInNest == 4 && diceThrow == 6)
            {
                PlayersList[Counter].Pieces[0].Movement = 1;
                TileList[PlayersList[Counter].Pieces[0].StartLocation].AddPieceToTile(PlayersList[Counter].Pieces[0]);
            }


            x[0] = PlayersList[Counter].Color;
            x[1] = "" + diceThrow;
            if (diceThrow != 6)
            {
                Counter++;
            }
            

            return x;
        }

    }
}
