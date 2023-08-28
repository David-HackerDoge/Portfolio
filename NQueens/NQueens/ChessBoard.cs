using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    internal class ChessBoard
    {
        List<List<int>> board = new List<List<int>>();
        List<List<List<int>>> boards = new List<List<List<int>>>();

        public ChessBoard(int size)
        {
            for (int i = 0; i < size; i++)
            {
                board.Add(new List<int>());
                for (int j = 0; j < size; j++)
                {
                    board[i].Add(0);
                }
            }
        }

        /// <summary>
        /// is the position given safe from all queens on the board?
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool PosSafe(int x, int y)
        {
            bool safe = true;
            //checking for vertical threats

            for (int roww = 0; roww < board.Count; roww++)
            {
                if (board[x][roww] == 1)
                {
                    safe = false;
                }
            }

            //checking for horizontal threats
            for (int coll = 0; coll < board.Count; coll++)
            {
                if (board[coll][y] == 1)
                {
                    safe = false;
                }
            }

            //checking for top-left to bottom-right diagonal threats
            int col = x;
            int row = y;
            //backtracking to top left
            while (col > 0 && row > 0)
            {
                col -= 1;
                row -= 1;
            }
            //checking for threats
            while (col < board.Count && row < board[0].Count)
            {
                if (board[col][row] == 1)
                {
                    safe = false;
                }
                col += 1;
                row += 1;
            }

            //checking for top-right to bottom-left diagonal threats
            col = x;
            row = y;
            //backtracking to top right
            while (col > 0 && row < board[0].Count-1)
            {
                col -= 1;
                row += 1;
            }
            //checking for threats
            while (col < board.Count && row > 0)
            {
                if (board[col][row] == 1)
                {
                    safe = false;
                }
                col += 1;
                row -= 1;
            }
            return safe;
        }

        /// <summary>
        /// does the real work of the QueensSingle function, hiding the col parmater from the end user
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        bool QueensSingleHelper(int col)
        {
            //loop through each row of the current column
            for (int row = 0; row < board[0].Count; row++)
            {
                //if (col, row) is safe from other queens
                if (PosSafe(col, row) == true)
                {
                    //place queen on board
                    board[col][row] = 1;
                    //if we have more columns to place queens on,
                    if (col < board.Count - 1)
                        //try to place a queen in the next column
                        //if it returns true, the recursion is unwinding and we already have our solution
                        if (QueensSingleHelper(col + 1) == true)
                        {
                            return true;
                        }
                        //if it returns false, we couldn't find a solution here
                        //so we remove the queen and let the for loop push us to the next row to try
                        else
                        {
                            board[col][row] = 0;
                        }
                    //here's the base case for the recursion.
                    //if the space is safe and we're in the final column,
                    //we have our solution and we can return true all the way back to the start
                    else
                    {
                        return true;
                    }
                }
            }
            //if we couldn't find a safe space in any of the rows,
            //backtrack and try changing a previous column's row
            return false;
        }

        /// <summary>
        /// returns a List of List's of integers representing a chess board
        /// The 1's are queens
        /// the board returned has queens equal in number to the size of the board
        /// queens are placed such that no queens threaten each other
        /// </summary>
        /// <returns></returns>
        public List<List<int>> QueensSingle()
        {
            int col = 0;
            QueensSingleHelper(col);
            return board;
        }

        /// <summary>
        /// does the real work of the QueensAll function, hiding the col parmater from the end user
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        bool QueensAllHelper(int col)
        {
            //all exactly the same as the find single version except a few changes i'll comment on
            for (int row = 0; row < board[0].Count; row++)
            {
                if (PosSafe(col, row) == true)
                {
                    board[col][row] = 1;
                    if (col < board.Count - 1)
                        if (QueensAllHelper(col + 1) == true)
                        {
                            return true;
                        }
                        else
                        {
                            board[col][row] = 0;
                        }
                    else
                    {
                        //here's the only difference.
                        //instead of returning true all the way back to the start,
                        //we add a deep copy of the current board to a list of boards
                        //then we remove the queen from the last column
                        //and continue as if we haven't found a solution yet
                        //this allows us to return a list of all possible solution boards
                        List<List<int>> tempBoard = new List<List<int>>();
                        for (int i = 0; i < board.Count; i++)
                        {
                            tempBoard.Add(new List<int>());
                            for (int j = 0; j < board[0].Count; j++)
                            {
                                tempBoard[i].Add(board[i][j]);
                            }
                        }
                        boards.Add(tempBoard);
                        board[col][row] = 0;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// returns a List of all possible solutions to the n queens problem
        /// The 1's are queens
        /// the board returned has queens equal in number to the size of the board
        /// queens are placed such that no queens threaten each other
        /// </summary>
        /// <returns></returns>
        public List<List<List<int>>> QueensAll()
        {
            int col = 0;
            QueensAllHelper(col);
            return boards;
        }

        /// <summary>
        /// resets the boards
        /// </summary>
        void clear()
        {
            board.Clear();
            boards.Clear();
        }
    }
}
