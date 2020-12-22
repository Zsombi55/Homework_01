using System;
using System.IO;

namespace BasicPathingLabyrinth
{
	class MatrixHelper
	{
		public static int[,] ReadMap()
		{
			//string path = @"D:\SULI\C# .NET\Homework_01\BasicPathingLabyrinth\MapData.txt";
			string path = @"..\..\..\MapData.txt"; // 3 levels
			//string path = @"MapData.txt"; // MapData -> Properties -> copy always.

			/* First check size (1st line Value) to width (2nd line Length) egality else there's no reason to read the rest;
			 * We need a SQUARE (N x N), not a rectangle (N x M).*/
			string[] lines = File.ReadAllLines(path);
			if(lines.Length < 1) // No matrix size.
			{
				throw new Exception("ERROR.. Missing matrix size definition! Verify \"MapData.txt\".");
			}
			
			if(!int.TryParse(lines[0], out int size)) // Incorrect size value.
			{
				throw new Exception("ERROR.. Incorrect data! Cannot parse matrix size. Verify \"MapData.txt\".");
			}
			
			if(lines.Length - 1 < size) // Column length does not match given matrix size.
			{
				throw new Exception("ERROR.. Row length does not match matrix size! Verify \"MapData.txt\".");
			}
			
			int[,] matrix = new int[size, size];
			for(int rowi = 0 ; rowi < size; rowi++)
			{
				string line = lines[rowi + 1];
				string[] cells = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

				if(cells.Length != size) // Column length does not match given matrix size.
				{
					throw new Exception("ERROR.. Column length does not match matrix size! Verify \"MapData.txt\".");
				}

				for(int coli = 0; coli < size; coli++)
				{
					if(!int.TryParse(cells[coli], out int cellValue)) // Incorrect or missing map initialization values in "MapData".
					{
						throw new Exception("ERROR.. The cell has no initializer value! Verify \"MapData.txt\".");
					}

					if(cellValue == 0 || cellValue == -1 || cellValue == int.MaxValue || cellValue == int.MinValue)
					{
						matrix[rowi, coli] = cellValue;
					}
					else // Incorrect or missing map initialization values in "MapData".
					{
						throw new Exception("ERROR.. Unsupported map initialization values found! Verify \"MapData.txt\".");
					}
				}
			}

			return matrix;
		}
	}
}
