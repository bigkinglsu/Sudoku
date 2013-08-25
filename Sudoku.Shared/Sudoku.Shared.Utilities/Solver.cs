using System;
using System.Globalization;

namespace Sudoku.Shared.Utilities
{
	public class Solver
	{
		private readonly int[, ,] _board;

		public Solver()
		{
			_board = new[, ,]
			{       		   /*1*/   /*2*/   /*3*/   /*4*/   /*5*/   /*6*/   /*7*/   /*8*/   /*9*/
				{
					/*1*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*2*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*3*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*4*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*5*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*6*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*7*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*8*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}, 
				{
					/*9*/     {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}
				}
			};
		}

		public Solver(int[, ,] gameBoard)
		{
			if (gameBoard == null) throw new ArgumentNullException("gameBoard");
			_board = gameBoard;
		}

		public void set_cell(int intRow, int intCol, int intValue)
		{
			_board[intRow, intCol, 0] = intValue;
			_board[intRow, intCol, 1] = 1;
		}

		public void clear_cell(int intRow, int intCol)
		{
			_board[intRow, intCol, 0] = 0;
			_board[intRow, intCol, 1] = 0;
		}

		public string get_cell(int intRow, int intCol)
		{
			return _board[intRow, intCol, 0].ToString(CultureInfo.InvariantCulture);
		}

		private bool check_row(int intRow, int intCol)
		{
			int i;

			for (i = 0; i < 9; i++)
			{
				if (_board[intRow, i, 0] == _board[intRow, intCol, 0] && i != intCol)
					return false;
			}

			return true;
		}

		private bool check_col(int intRow, int intCol)
		{
			int i;

			for (i = 0; i < 9; i++)
			{
				if (_board[i, intCol, 0] == _board[intRow, intCol, 0] && i != intRow)
					return false;
			}

			return true;
		}

		private bool check_box(int intRow, int intCol)
		{
			int i;
			int sRow;
			int sCol;

			if (intRow >= 0 && intRow <= 2)
				sRow = 0;
			else if (intRow >= 3 && intRow <= 5)
				sRow = 3;
			else
				sRow = 6;

			if (intCol >= 0 && intCol <= 2)
				sCol = 0;
			else if (intCol >= 3 && intCol <= 5)
				sCol = 3;
			else
				sCol = 6;

			for (i = sRow; i < sRow + 3; i++)
			{
				int j;
				for (j = sCol; j < sCol + 3; j++)
				{
					if (_board[i, j, 0] == _board[intRow, intCol, 0] && i != intRow && j != intCol)
						return false;
				}
			}

			return true;
		}

		public bool check_cell(int intRow, int intCol)
		{
			if (!check_row(intRow, intCol) || !check_col(intRow, intCol) || !check_box(intRow, intCol))
				return false;

			return true;
		}

		public bool solve_board()
		{
			int i;
			int col = 0;
			bool backedUp = false;

			for (i = 0; i < 9; i++)
			{
				int j;
				for (j = col; j < 9; j++)
				{
					col = 0;

					if (_board[i, j, 1] == 1)
					{
						if (backedUp)
						{
							j--;
							if (j < 0)
							{
								i--;

								if (i < 0)
									return false;
								col = 8;
								i--;

								break;
							}
							j--;
						}

						continue;
					}

					bool status = false;
					backedUp = false;

					_board[i, j, 0]++;
					while (_board[i, j, 0] <= 9)
					{
						status = check_cell(i, j);

						if (status)
							break;

						_board[i, j, 0]++;
					}

					if (status)
						continue;

					_board[i, j, 0] = 0;

					j--;
					backedUp = true;
					if (j < 0)
					{
						i--;

						if (i < 0)
							return false;
						col = 8;
						i--;

						break;
					}
					j--;
				}
			}

			return true;
		}
	}
}