using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Action;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TicTacToeAction ticTacToeService = new TicTacToeAction();
            ticTacToeService.Start();
            Console.ReadLine();
        }
    }
}
