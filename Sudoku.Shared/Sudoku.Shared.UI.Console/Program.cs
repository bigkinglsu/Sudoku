using System;
using Sudoku.Shared.Utilities;
using Sudoku.Shared.Presenters;

namespace Sudoku.Shared.UI.Console
{
	class MainClass
	{
		static private readonly Solver Solution = new Solver();
		const string ERROR = "ERROR!!";
		const char YES = 'y';
		const char NO = 'n';
		const string ROW = "Row: ";
		const string CONT = "Continue? ";
		const string COL = "Column: ";
		const string VAL = "Value: ";
		const string INVALID = "Invalid Move!!";

		static void Main()
		{
			System.Console.WriteLine(string.Empty);
			System.Console.Write(SudokuPresenter.Current.Title);

			enter_values();

			System.Console.Write(Solution.solve_board() ? SudokuPresenter.Current.Solved : SudokuPresenter.Current.Failed);

			print_grid();

			System.Console.ReadLine();
		}

		static void print_grid()
		{
			System.Console.WriteLine("");
			System.Console.WriteLine("     1 | 2 | 3 |  4 | 5 | 6  | 7 | 8 | 9");
			System.Console.WriteLine("  /=======================================\\");
			System.Console.WriteLine("1 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(0, 0), Solution.get_cell(0, 1), Solution.get_cell(0, 2), Solution.get_cell(0, 3), Solution.get_cell(0, 4), Solution.get_cell(0, 5), Solution.get_cell(0, 6), Solution.get_cell(0, 7), Solution.get_cell(0, 8));
			System.Console.WriteLine("--||---+---+--------+---+--------+---+---||");
			System.Console.WriteLine("2 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(1, 0), Solution.get_cell(1, 1), Solution.get_cell(1, 2), Solution.get_cell(1, 3), Solution.get_cell(1, 4), Solution.get_cell(1, 5), Solution.get_cell(1, 6), Solution.get_cell(1, 7), Solution.get_cell(1, 8));
			System.Console.WriteLine("--||---+---+--------+---+--------+---+---||");
			System.Console.WriteLine("3 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(2, 0), Solution.get_cell(2, 1), Solution.get_cell(2, 2), Solution.get_cell(2, 3), Solution.get_cell(2, 4), Solution.get_cell(2, 5), Solution.get_cell(2, 6), Solution.get_cell(2, 7), Solution.get_cell(2, 8));
			System.Console.WriteLine("--||=====================================||");
			System.Console.WriteLine("4 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(3, 0), Solution.get_cell(3, 1), Solution.get_cell(3, 2), Solution.get_cell(3, 3), Solution.get_cell(3, 4), Solution.get_cell(3, 5), Solution.get_cell(3, 6), Solution.get_cell(3, 7), Solution.get_cell(3, 8));
			System.Console.WriteLine("--||---+---+--------+---+--------+---+---||");
			System.Console.WriteLine("5 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(4, 0), Solution.get_cell(4, 1), Solution.get_cell(4, 2), Solution.get_cell(4, 3), Solution.get_cell(4, 4), Solution.get_cell(4, 5), Solution.get_cell(4, 6), Solution.get_cell(4, 7), Solution.get_cell(4, 8));
			System.Console.WriteLine("--||---+---+--------+---+--------+---+---||");
			System.Console.WriteLine("6 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(5, 0), Solution.get_cell(5, 1), Solution.get_cell(5, 2), Solution.get_cell(5, 3), Solution.get_cell(5, 4), Solution.get_cell(5, 5), Solution.get_cell(5, 6), Solution.get_cell(5, 7), Solution.get_cell(5, 8));
			System.Console.WriteLine("--||=====================================||");
			System.Console.WriteLine("7 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(6, 0), Solution.get_cell(6, 1), Solution.get_cell(6, 2), Solution.get_cell(6, 3), Solution.get_cell(6, 4), Solution.get_cell(6, 5), Solution.get_cell(6, 6), Solution.get_cell(6, 7), Solution.get_cell(6, 8));
			System.Console.WriteLine("--||---+---+--------+---+--------+---+---||");
			System.Console.WriteLine("8 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(7, 0), Solution.get_cell(7, 1), Solution.get_cell(7, 2), Solution.get_cell(7, 3), Solution.get_cell(7, 4), Solution.get_cell(7, 5), Solution.get_cell(7, 6), Solution.get_cell(7, 7), Solution.get_cell(7, 8));
			System.Console.WriteLine("--||---+---+--------+---+--------+---+---||");
			System.Console.WriteLine("9 || {0} | {1} | {2} || {3} | {4} | {5} || {6} | {7} | {8} ||", Solution.get_cell(8, 0), Solution.get_cell(8, 1), Solution.get_cell(8, 2), Solution.get_cell(8, 3), Solution.get_cell(8, 4), Solution.get_cell(8, 5), Solution.get_cell(8, 6), Solution.get_cell(8, 7), Solution.get_cell(8, 8));
			System.Console.WriteLine("  \\=======================================/");
			System.Console.WriteLine("");
		}

		static void enter_values()
		{
			while (true)
			{
				print_grid();

				System.Console.Write (CONT);
				// ReSharper disable AssignNullToNotNullAttribute
				var cont = Convert.ToChar(System.Console.ReadLine());
				// ReSharper restore AssignNullToNotNullAttribute
				if (cont == NO)
					break;
				if (cont != YES && cont != NO)
					continue;

				System.Console.Write(ROW);
				var row = Convert.ToInt32(System.Console.ReadLine());
				row--;
				if (row < 0 || row > 8)
				{
					System.Console.WriteLine(ERROR);
					break;
				}

				System.Console.Write(COL);
				var col = Convert.ToInt32(System.Console.ReadLine());
				col--;
				if (col < 0 || col > 8)
				{
					System.Console.WriteLine(ERROR);
					break;
				}

				System.Console.Write(VAL);
				var value = Convert.ToInt32(System.Console.ReadLine());
				if (value == 0)
					Solution.clear_cell(row, col);
				else
					Solution.set_cell(row, col, value);

				if (value < 1 || value > 9)
				{
					Solution.clear_cell(row, col);
					System.Console.WriteLine(ERROR);
					break;
				}

				System.Console.WriteLine(string.Empty);
				System.Console.WriteLine(string.Empty);
				if (!Solution.check_cell(row, col))
				{
					Solution.clear_cell(row, col);
					System.Console.WriteLine(INVALID);
				}
			}

			System.Console.WriteLine(string.Empty);
		}
	}
}
