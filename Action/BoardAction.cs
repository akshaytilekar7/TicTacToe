using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.Action
{
    public class BoardAction
    {
        private TicTac _ticTac = new TicTac();

        public List<string> GetWinerLocations(string[,] boardLocations)
        {
            var lstRow = GetRowElementsIfSame(boardLocations);
            var lstColumns = GetColumnElementsIfSame(boardLocations);
            var lstDiagonal = GetDiagonalElementsIfSame(boardLocations);

            if (lstRow == null && lstColumns == null && lstDiagonal == null)
                return null;

            return lstRow == null ? (lstColumns == null ? lstDiagonal : lstColumns) : lstRow;
        }

        public List<string> GetRowElementsIfSame(string[,] boardLocations)
        {
            if (boardLocations == null || boardLocations.Length == 0)
                return null;
            for (int i = 0; i < boardLocations.GetLength(0); i++)
            {
                var lstElements = new List<string>();
                for (int j = 0; j < boardLocations.GetLength(1); j++)
                {
                    lstElements.Add(boardLocations[i, j]);
                }
                if (_isListContainsSameElements(lstElements))
                    return lstElements;
            }
            return null;
        }

        public List<string> GetColumnElementsIfSame(string[,] boardLocations)
        {
            if (boardLocations == null || boardLocations.Length == 0)
                return null;
            for (int i = 0; i < boardLocations.GetLength(0); i++)
            {
                var lstElements = new List<string>();
                for (int j = 0; j < boardLocations.GetLength(1); j++)
                {
                    lstElements.Add(boardLocations[j, i]);
                }
                if (_isListContainsSameElements(lstElements))
                    return lstElements;
            }
            return null;
        }

        public List<string> GetDiagonalElementsIfSame(string[,] boardLocations)
        {
            if (boardLocations == null || boardLocations.Length == 0)
                return null;
            int columnSize = boardLocations.GetLength(1);
            //For left to right 
            var lstElements = new List<string>();
            for (int i = 0; i < boardLocations.GetLength(0); i++)
            {
                for (int j = 0; j < boardLocations.GetLength(1); j++)
                {
                    if (i == j)
                        lstElements.Add(boardLocations[i, j]);
                }
            }

            if (_isListContainsSameElements(lstElements))
                return lstElements;

            //for right to left
            var low = 0;
            var upper = columnSize - 1;
            var lstDElements = new List<string>();
            while (upper >= 0)
            {
                lstDElements.Add(boardLocations[low, upper]);
                upper--;
                low++;
            }
            if (_isListContainsSameElements(lstDElements))
                return lstElements;
            return null;
        }

        private bool _isListContainsSameElements(List<string> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == null) return false;
                if (lst[0] != lst[i]) return false;
            }
            return true;
        }
    }
}
