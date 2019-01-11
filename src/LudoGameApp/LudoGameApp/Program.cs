using GameEngine;
using System;

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

                    //if (result[2] == "1")
                    //{

                    //}
                   
                    Console.WriteLine($"It is {result[0]}'s turn to move\nDice showed {result[1]}");

                    Console.WriteLine("What do u want to do?");
                    Console.WriteLine("1: Move piece");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        
                    }
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
