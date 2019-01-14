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
            List<Action> listOfFunc = new List<Action>();
            listOfFunc.Add(() => game.NextTurn());
            listOfFunc.Add(game.SkipTurn);
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

                    //if (result[2] == "1")
                    //{

                    //}

                    Console.WriteLine($"It is {result[0]}'s turn to move\nDice showed {result[1]}");

                    int choice = int.Parse(Console.ReadLine());

                    foreach (var player in game.PlayersList)
                    {
                        if (player.Color == result[0])
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
                    Console.WriteLine("What do u want to do?");
                    Console.WriteLine("1: Move piece number: ?\nPass the turn?");

                    var test = listOfFunc[choice - 1].DynamicInvoke();

                }
            }

            Console.ReadKey();

        }

        static void GameBoard()
        {
            Console.WriteLine("             + - - - +            ");
            Console.WriteLine(" + - - +     |       |     + - - +");
            Console.WriteLine(" |     |     |       |     |     |");
            Console.WriteLine(" |     |     |       |     |     |");
            Console.WriteLine(" + - - +     |       |     + - - +");
            Console.WriteLine("             |       |");
            Console.WriteLine(" + - - - - - +   #   + - - - - - +");
            Console.WriteLine(" |               #               |");
            Console.WriteLine(" |           # # # # #           |");
            Console.WriteLine(" |               #               |");
            Console.WriteLine(" + - - - - - +   #   + - - - - - +");
            Console.WriteLine("             |       |");
            Console.WriteLine(" + - - +     |       |     + - - +");
            Console.WriteLine(" |     |     |       |     |     |");
            Console.WriteLine(" |     |     |       |     |     |");
            Console.WriteLine(" + - - +     |       |     + - - +");
            Console.WriteLine("             + - - - +            ");
        }
    }
}
