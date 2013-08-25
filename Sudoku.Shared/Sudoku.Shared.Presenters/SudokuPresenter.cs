using System;

namespace Sudoku.Shared.Presenters
{
	public class SudokuPresenter
	{
		private static SudokuPresenter _presenter;

		private SudokuPresenter () {}

		public static SudokuPresenter Current
		{
			get { return _presenter ?? (_presenter = new SudokuPresenter()); }
		}

		public string Title { get { return "Sudoku"; } }
		public string Solved { get { return "Solved!!"; } }
		public string Failed { get { return "Failed!!"; } }
	}
}

