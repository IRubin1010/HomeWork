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
1: check the winer
2: check if the game is finished
3: print the players and theier cards
4: make a move
5: exit";
            do
            {
                Console.WriteLine(menu);
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(game.Winer());
                        break;
                    case 2:
                        if (game.FinishGame())
                        {
                            Console.WriteLine("the game is over");
                        }
                        else
                        {
                            Console.WriteLine("the game is not over");
                        }
                        break;
                    case 3:
                        Console.WriteLine(game.ToString());
                        break;
                    case 4:
                        game.Move();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("ERROR!!");
                        break;
                }

            } while (choice != 5);

        }
    }
}
