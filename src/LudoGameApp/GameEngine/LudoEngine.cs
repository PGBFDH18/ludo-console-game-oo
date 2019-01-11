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
            string[] playerAndDice = new string[2];

            if (Counter == NrOfPlayer)
            {
                Counter = 0;
            }

            int diceThrow = Dice.ThrowDice();

            playerAndDice[0] = PlayersList[Counter].Color;
            playerAndDice[1] = "" + diceThrow;

            return playerAndDice;

            int piecesInNest = 0;
            foreach (var item in PlayersList[Counter].Pieces)
            {
                if (item.InNest)
                {
                    piecesInNest++;
                }
            }

            if (piecesInNest == 4)
            {
                return FirstPieceFromNest(diceThrow);
            }

            if (piecesInNest < 4 && piecesInNest != 0 && diceThrow == 6)
            {
                return playerAndDice;
            }
            else if(piecesInNest == 3)
            {

            }

            if (diceThrow != 6)
            {
                Counter++;
            }

            return playerAndDice;
        }

        private string[] FirstPieceFromNest(int diceThrow)
        {
            string[] playerAndDice = new string[2];

            if (diceThrow != 6)
            {
                playerAndDice[0] = PlayersList[Counter].Color;
                playerAndDice[1] = diceThrow + " Player cant move. Next Player";
                Counter++;
                return playerAndDice;
            }
            else if (diceThrow == 6)
            {
                PlayersList[Counter].Pieces[0].Movement = 1;
                TileList[PlayersList[Counter].Pieces[0].StartLocation].AddPieceToTile(PlayersList[Counter].Pieces[0]);
            }

            playerAndDice[0] = PlayersList[Counter].Color;
            playerAndDice[1] = "" + diceThrow;
            if (diceThrow != 6)
            {
                Counter++;
            }

            return playerAndDice;
        }

    }
}
