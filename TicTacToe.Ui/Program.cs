using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (true)
            {
                
                Console.Write(game.Prompt());
                DrawBoard(game);
                Console.Write(Environment.NewLine);

                game.ReadUserInput(Console.ReadLine());
            }
            
        }

        public static void DrawBoard(Game board)
        {
            var linesToDisplay = board.GameQueries.GetLines().GetRange(0, 3);
            foreach (var line in linesToDisplay)
            {
                Console.Write(Environment.NewLine);
                foreach (var position in line.Positions)
                {
                    Console.Write(position.Symbol);
                    Console.Write("|");
                }
            }
        }
    }
}
