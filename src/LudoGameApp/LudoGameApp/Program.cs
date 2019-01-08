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
           
            var game = new LudoEngine();
            game.StartGame(int.Parse(Console.ReadLine()));
            GameBoard();
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
