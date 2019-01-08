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
            int numberOfPlayers = int.Parse(Console.ReadLine());
            var game = new LudoEngine();
            game.StartGame(numberOfPlayers);

        }
    }
}
