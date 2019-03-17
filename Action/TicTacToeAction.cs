using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.Action
{
    public class TicTacToeAction
    {
        private TicTac _ticTac = new TicTac();
        private BoardAction _boardSerivce = new BoardAction();

        public void Start()
        {
            _CreateBoard();
            _DrawBoard();
            int _isEven = 0;
            while (!_isWinnerFound() && _ticTac.LstAvailableLocations.Any())
            {
                if (_isEven % 2 == 0)
                {
                    var loc = _GetLocation(User.X);
                    _SetLocation(loc, User.X);
                }
                else
                {
                    var loc = _GetLocation(User.O);
                    _SetLocation(loc, User.O);
                }
                _DrawBoard();
                _isEven++;
            }
            if (_isWinnerFound())
                _printWinner();
            else if (!_ticTac.LstAvailableLocations.Any())
                Console.WriteLine("No one is Win");
        }

        public void _CreateBoard()
        {
            for (int i = 0; i < _ticTac.BoardLocations.GetLength(0); i++)
            {
                for (int j = 0; j < _ticTac.BoardLocations.GetLength(1); j++)
                {
                    var loc = i.ToString() + j.ToString();
                    _ticTac.BoardLocations[i, j] = loc;
                    _ticTac.LstAllLocations.Add(loc);
                    _ticTac.LstAvailableLocations.Add(loc);
                }
            }
        }

        public void _DrawBoard()
        {
            for (int i = 0; i < _ticTac.BoardLocations.GetLength(0); i++)
            {
                for (int j = 0; j < _ticTac.BoardLocations.GetLength(1); j++)
                {
                    Console.Write(Convert.ToString(_ticTac.BoardLocations[i, j]) + '\t');
                }
                Console.WriteLine("\n");
            }
        }

        private bool _isWinnerFound()
        {
            _ticTac.LstWinnerLocations = _boardSerivce.GetWinerLocations(_ticTac.BoardLocations);
            return _ticTac.LstWinnerLocations == null ? false : true;
        }

        private void _printWinner()
        {
            Console.WriteLine("[ " + _ticTac.LstWinnerLocations[0] + " ] is winner");
        }

        private string _GetLocation(User user)
        {
            Console.WriteLine("Player : [ " + user.ToString() + " ]");
            string data = Console.ReadLine();
            while (!_ticTac.LstAllLocations.Contains(data) || !_ticTac.LstAvailableLocations.Contains(data))
            {
                Console.WriteLine("Location not found or already used, please try again");
                Console.WriteLine("Please enter the valid location : [ " + user.ToString() + " ]");
                data = Console.ReadLine();
            }
            Console.Clear();
            return data;
        }

        private void _SetLocation(string location, User user)
        {
            var temp = location.ToCharArray();
            var i = Convert.ToInt32(temp[0].ToString());
            var j = Convert.ToInt32(temp[1].ToString());
            _ticTac.BoardLocations[i, j] = "[" + user.ToString() + "]";
            if (_ticTac.LstAvailableLocations.Contains(location))
                _ticTac.LstAvailableLocations.Remove(location);
        }
    }
}
