using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class LudoEngine
    {
        private static int Counter = 0;
        private int LastDiceThrow { get; set; }
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

        public bool MovePiece(int PieceNr)
        {
            if (PlayersList[Counter].Pieces[PieceNr - 1].InNest)
            {                
                PieceFromNest(PieceNr);
                return true;
            }
            else
            {
                int location = PlayersList[Counter].Pieces[PieceNr - 1].StartLocation + (PlayersList[Counter].Pieces[PieceNr - 1].Movement - 1);
                int nextLocation = location + LastDiceThrow;

                if (!TileList[nextLocation].Full)
                {
                    for (int i = location + 1; i <= nextLocation; i++)
                    {
                        if (TileList[i].Blocked)
                        {
                            if (LastDiceThrow != 6)
                            {
                                Counter++;
                            }
                            TileStatus();
                            return false;
                        }
                    }
                    for (int i = 0; i < TileList[location].PieceList.Count; i++)
                    {
                        if (PlayersList[Counter].Pieces[PieceNr - 1].PlayerColor == TileList[location].PieceList[i].PlayerColor && PlayersList[Counter].Pieces[PieceNr - 1].PieceName == TileList[location].PieceList[i].PieceName)
                        {
                            TileList[location].PieceList.RemoveAt(i);
                        }
                    }

                    TileList[nextLocation].AddPieceToTile(PlayersList[Counter].Pieces[PieceNr - 1]);

                    PlayersList[Counter].Pieces[PieceNr - 1].Movement += LastDiceThrow;

                }
                if (LastDiceThrow != 6)
                {
                    Counter++;
                }
                TileStatus();
                return true;
            }

        }


        public string[] NextTurn()
        {
            string[] playerAndDice = new string[2];

            if (Counter == NrOfPlayer)
            {
                Counter = 0;
            }

            LastDiceThrow = 6;

            playerAndDice[0] = PlayersList[Counter].Color;
            playerAndDice[1] = "" + LastDiceThrow;

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
                return PieceFromNest(LastDiceThrow);
            }

            if (piecesInNest < 4 && piecesInNest != 0 && LastDiceThrow == 6)
            {
                return playerAndDice;
            }
            else if (piecesInNest == 3)
            {

            }

            if (LastDiceThrow != 6)
            {
                Counter++;
            }

            return playerAndDice;
        }

        private string[] PieceFromNest(int pieceNr)
        {
            string[] playerAndDice = new string[2];

            if (LastDiceThrow != 6)
            {
                playerAndDice[0] = PlayersList[Counter].Color;
                playerAndDice[1] = LastDiceThrow + " Piece can not move. Next Player";
                Counter++;
                TileStatus();
                return playerAndDice;
            }
            else if (LastDiceThrow == 6 && PlayersList[Counter].Pieces[pieceNr-1].InNest)
            {
                PlayersList[Counter].Pieces[pieceNr-1].Movement = 1;
                TileList[PlayersList[Counter].Pieces[pieceNr - 1].StartLocation].AddPieceToTile(PlayersList[Counter].Pieces[pieceNr -1]);
            }

            playerAndDice[0] = PlayersList[Counter].Color;
            playerAndDice[1] = "" + LastDiceThrow;


            return playerAndDice;
        }

        public void SkipTurn()
        {
            Counter++;
        }

        public void TileStatus()
        {
            foreach (var item in TileList)
            {

                if (item.PieceList.Count < 2)
                {
                    item.Blocked = false;
                    item.Full = false;
                }
            }
        }
    }
}
