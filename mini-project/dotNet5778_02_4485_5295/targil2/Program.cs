using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace targil2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the name of the first player");
            string firstPlayerName = Console.ReadLine();
            Console.WriteLine("enter the name of the second player");
            string secondPlayerName = Console.ReadLine();
            Game game = new Game();
            game.BeginGame(firstPlayerName, secondPlayerName);
            int choice;
            string menu = @"menu
0: play the all game
1: make a move
2: exit";
            do
            {
                Console.WriteLine(menu);
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        while(!game.FinishGame())
                        {
                            Console.WriteLine(game.Move());
                            Console.WriteLine(game.ToString());
                            Console.WriteLine("*******" + '\n');
                        }
                        Console.WriteLine(game.Winer() + '\n');
                        break;
                    case 1:
                        Console.WriteLine(game.Move());
                        Console.WriteLine(game.ToString() + '\n');
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("ERROR!!");
                        break;
                }

            } while (choice != 2);

        }
    }
}
