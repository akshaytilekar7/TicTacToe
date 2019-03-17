using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class TicTac
    {
        public TicTac()
        {
            BoardLocations = new string[BoardSize, BoardSize];
            LstAllLocations = new List<string>();
            LstAvailableLocations = new List<string>();
            LstWinnerLocations = new List<string>();
        }

        public int BoardSize = 3;

        public string[,] BoardLocations { get; set; }

        public List<string> LstWinnerLocations { get; set; }

        public List<string> LstAllLocations { get; set; }

        public List<string> LstAvailableLocations { get; set; }
    }

    public enum User
    {
        X = 0,  // player 1 
        O = 1,  // player 2 
        XO = 3  // no one is win
    }
}
