using System;
using System.IO;

namespace BasicPathingLabyrinth
{
	class MatrixHelper
	{
		public static int[,] ReadMap()
		{
			//string path = @"D:\SULI\C# .NET\Homework_01\BasicPathingLabyrinth\MapData.txt"; // Full path.
			string path = @"..\..\..\MapData.txt"; // 3 levels:  "\ obj \ Debug \ net5.0 \ "  inside the project folder, for runtime.
			//string path = @"MapData.txt"; // MapData.txt -> drop down menu -> Properties -> Copy to Output Directory : Copy Always.


			// First check size else there's no reason to continue. We need a SQUARE (N x N), not a rectangle (N x M).
			string[] lines = File.ReadAllLines(path);
			if(lines.Length < 1) // No matrix size.
			{ throw new Exception("ERROR.. Missing matrix size definition! Verify \"MapData.txt\"."); }
			
			if(!int.TryParse(lines[0], out int size)) // Incorrect size value. ELSE get matrix size.
			{ throw new Exception("ERROR.. Incorrect data! Cannot parse matrix size. Verify \"MapData.txt\"."); }
			
			if(lines.Length - 1 < size) // Column length does not match given matrix size.
			{ throw new Exception("ERROR.. Row length does not match matrix size! Verify \"MapData.txt\"."); }
			
			int[,] matrix = new int[size, size]; // Square matrix so one size fits all sides.
			for(int rowi = 0 ; rowi < size; rowi++)
			{
				string line = lines[rowi + 1];
				string[] cells = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

				if(cells.Length != size) // Column length does not match given matrix size.
				{ throw new Exception("ERROR.. Column length does not match matrix size! Verify \"MapData.txt\"."); }

				for(int coli = 0; coli < size; coli++)
				{
					if(!int.TryParse(cells[coli], out int cellValue)) // Incorrect or missing cell defining values in "MapData". ELSE get initializing cell values.
					{ throw new Exception("ERROR.. The cell has no initializer value! Verify \"MapData.txt\"."); }

					if(cellValue == 0 || cellValue == -1 || cellValue == 1 || cellValue == 2) //cellValue == int.MaxValue || cellValue == int.MinValue)
					{
						matrix[rowi, coli] = cellValue;
					}
					else // Incorrect or missing map initialization values in "MapData".
					{ throw new Exception("ERROR.. Unsupported map initialization values found! Verify \"MapData.txt\"."); }
				}
			}

			return matrix;
		}

		/// <summary>
		/// Switch looking directions relative to the current cell coordinates.
		/// </summary>
		/// <param name="currentRowi">Current cell row index.</param>
		/// <param name="currentColi">Current cell column index.</param>
		/// <param name="lookAtCor">Coordinate pair of the cell we are to look at after the switch.</param>
		/// <param name="turnCycle">The number of the current direction; we always look around.</param>
		/// <returns>An integer array with the coordinates of the new cell to inspect.</returns>
		internal static int[] SwitchView(int currentRowi, int currentColi, int[] lookAtCor, int turnCycle)
		{
			//Console.WriteLine($"Current coordinates to look around (x, y), PRE--SWITCH-CHECK: [{currentColi}, {currentRowi}] .");
			switch (turnCycle)
			{
				// Up.
				case 1:
				{
					lookAtCor[0] = currentRowi - 1; lookAtCor[1] = currentColi;
					break;
				};
				// Right.
				case 2:
				{
					lookAtCor[0] = currentRowi; lookAtCor[1] = currentColi + 1;
					break;
				};
				// Down.
				case 3:
				{
					lookAtCor[0] = currentRowi + 1; lookAtCor[1] = currentColi;
					break;
				};
				// Left.
				case 4:
				{
					lookAtCor[0] = currentRowi; lookAtCor[1] = currentColi - 1;
					break;
				};

				//default:  break;
			}
			//Console.WriteLine($"The  lookingAtCor  coordinates POST--SWITCH: {string.Join(", ", lookAtCor)} .");
			return lookAtCor;
		}
	}
}
