using GameEngine;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ludo!");
            Console.WriteLine("How many players:");

            var game = new LudoEngine(int.Parse(Console.ReadLine()));
         
            if (!game.OkToStart)
            {
                Console.WriteLine("Wrong numbers of Players, only 2-4 can play");
            }
            else
            {
                //GameBoard();
                while (true)
                {
                    string[] result = game.NextTurn();

                    

                    Console.WriteLine($"It is {result[0]}'s turn to move\nDice showed {result[1]}");


                    PrintOutPieces(game, result[0]);

              
                    Console.WriteLine("What do u want to do?");
                    int choice = ReadInt("1: Move piece? \n2: Pass the turn?");
                    
                    if (choice == 1)
                    {
                        int pieceChoice = ReadInt("What piece number: ");
                        game.MovePiece(pieceChoice);

                    }
                    else
                    {
                        game.SkipTurn();
                    }
                    
                    
                    
                    //var test = listOfFunc[choice - 1].DynamicInvoke();

                }
            }

            Console.ReadKey();

        }


        static void PrintOutPieces(LudoEngine game, string playerColor)
        {
            foreach (var player in game.PlayersList)
            {
                if (player.Color == playerColor)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (player.Pieces[i].InNest == true)
                        {
                            Console.WriteLine($"Piece nr {i + 1} is in the nest");
                        }
                        else
                        {
                            Console.WriteLine($"Piece nr {i + 1} have moved {player.Pieces[i].Movement}");
                        }
                    }
                }
            }
            foreach (var item in game.TileList)
            {
                if (item.PieceList.Count > 0)
                {
                    Console.Write("On tile position " + item.TilePosition  + " ");

                    for (int i = 0; i < item.PieceList.Count; i++)
                    {
                        Console.Write(item.PieceList[i].PlayerColor + " ");
                        Console.Write(item.PieceList[i].PieceName + ", ");
                    }
                    Console.WriteLine();
                }
            }
            foreach (var item in game.FinalStretch)
            {
                if (item.PieceList.Count > 0)
                {
                    Console.Write("On final tile position " + item.TilePosition + " ");

                    for (int i = 0; i < item.PieceList.Count; i++)
                    {
                        Console.Write(item.PieceList[i].PlayerColor + " ");
                        Console.Write(item.PieceList[i].PieceName + ", ");
                    }
                    Console.WriteLine();
                }

            }
        }


        static int ReadInt(string promt)
        {
            Console.WriteLine(promt);
            return int.Parse(Console.ReadLine());
        }
        static void GameBoard()
        {
            /*
     * Standard Ludo Board:
     * --------------------
     * Length: 40
     * Size: 11x11
     * EndZoneLength: 5 (4 + Goal)
     * Positions:

▶▶▶▶                        08 ▶ 09 ▶ 10  ⇠ (P1)
                            ▲    ↓    ▼
▶▶▶▶                        07   45   11
                            ▲    ↓    ▼
▶▶▶▶                        06   46   12
                            ▲    ↓    ▼
▶▶▶▶    (P0)                05   47   13
        ⇣                   ▲    ↓    ▼
        00 ▶ 01 ▶ 02 ▶ 03 ▶ 04   48   14 ▶ 15 ▶ 16 ▶ 17 ▶ 18
        ▲                        ↓                        ▼
        39 → 40 → 41 → 42 → 43 → G ← 53 ← 52 ← 51 ← 50 ← 19
        ▲                        ↑                        ▼
        38 ◀ 37 ◀ 36 ◀ 35 ◀ 34   58   24 ◀ 23 ◀ 22 ◀ 21 ◀ 20
                            ▲    ↑    ▼                   ⇡
▶▶▶▶                        33   57   25                (P2)
                            ▲    ↑    ▼
▶▶▶▶                        32   56   26
                            ▲    ↑    ▼
▶▶▶▶                        31   55   27
                            ▲    ↑    ▼
▶▶▶▶                (P3) ⇢  30 ◀ 29 ◀ 28
 */
        }
    }
}
