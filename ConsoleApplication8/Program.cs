using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApplication8.Scenes;
using Otter;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Game", 320, 240); //creates a game with internal resolution 1920 x 1080
            game.SetWindow(320, 240); //outputs the game to a window scaled down to 1600 x 900

            var scene = new Scene1();
            
            game.Start(scene);
        }
    }
}
