/*
 * User: Zsombor
 * Date: 2020-12-21
 * Time: 12:12
 * 12th.
 */

using System;
using System.Text;

namespace BasicPathingLabyrinth
{
// Goal: "basic labyrinth path finder"; "0" for clear cell, "-1" for wall, "int.MaxValue" for occupied, and "int.MinValue" for exit. Square map data from user-input /txt file into matrix, mark clear cells with values in mirror matrix, using these values find shortest path out, print the path as a list of coordinates. -- BUT for easier testing, in the MapData.txt I have marked the start position with  " 2 "  and the end goal as  " 1 ".
	class Program
	{
		static void Main(string[] args)
		{
			int[,] matrix = MatrixHelper.ReadMap();
			int size = matrix.GetLength(0);
			int[] startPosition = Surveyor.GetStartPosition(matrix);
			int[] endPosition = Surveyor.GetEndPosition(matrix);

			// TODO: transfer all output printer functions into a separate new class, so there's less here.

			PrintHeader(size);

			for (int rowi = 0; rowi < matrix.GetLength(0); rowi++)
            {
				Console.Write($"{rowi, 4}|");
				for (int coli = 0; coli < matrix.GetLength(1); coli++)
                {
					if(matrix[rowi, coli] == -1) // TODO: change  " if - else "  into  "switch " ?
					{
						Console.ForegroundColor = ConsoleColor.DarkBlue;
						Console.Write($"{matrix[rowi, coli], 5}");
						Console.ResetColor();
					}
					else if (matrix[rowi, coli] == 2)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write($"{matrix[rowi, coli], 5}");
						Console.ResetColor();
					}
					else if (matrix[rowi, coli] == 1)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write($"{matrix[rowi, coli], 5}");
						Console.ResetColor();
					}
					else {
						Console.Write($"{matrix[rowi, coli], 5}");
					}
				}
				Console.Write($" |");
				Console.Write($"{rowi, 3}" + "\n");
				PrintFiller(size);

				// TODO: find a way to print the matrix with lines separated by a blank line, But without any at the end.
            }
			PrintFooter(size);

			Console.Write($"\nThe designated starting position coordinates (x, y) are:  [ {startPosition[1]} , {startPosition[0]} ].\n" +
						  $"The designated ending position coordinates (x, y) are:  [ {endPosition[1]} , {endPosition[0]} ].");

			Console.WriteLine("\n--------------------\n");

			int[,] weightedMatrix = new int[size, size];
			weightedMatrix = Surveyor.Surveying(matrix);
			Console.WriteLine("Survey complete. Looking for optimal path..");

			Console.WriteLine("\n--------------------\n");

			Console.WriteLine($"Survey data integrity (OK if > 1): {weightedMatrix.Length} .");

			if(weightedMatrix.Length > 1) // The surveying was successful and did not return a [0,0] (single cell) matrix.
			{
				PathFinder.PathCounter(weightedMatrix, startPosition, endPosition);
/*				
				var v = PathFinder.PathCounter(weightedMatrix, startPosition, endPosition);
				
				if(v != null)
				{
					StringBuilder s = new StringBuilder();
			
					for(int i = 0; i < v.Count; i++) s.Append($"[{string.Join(" ", v[i])}]").Append(",");
			
					Console.WriteLine($"\n\n{s.ToString().TrimEnd(new char[] {','})}");
				}
				else throw new IndexOutOfRangeException("ERROR.. Something went wrong during result List<int[]> creation or retrieval.");
*/
			}
			else throw new ArgumentOutOfRangeException("ERROR.. Insufficient cells.\nThe Start and End points could not be connected.\n" +
					"Verify that \"MapData.txt\" contains correct values.");

			Console.WriteLine("\n--------------------\nEnd.\n");
		}

		private static void PrintHeader(int length)
		{
			Console.Write("    |");
			for(int i = 0; i < length; i++) Console.Write($"{i, 5}");
			Console.WriteLine(" |");
			Console.Write(new String('-', length * 6) + "\n");
		}

		private static void PrintFooter(int length)
		{
			Console.Write(new String('-', length * 6) + "\n");
			Console.Write("    |");
			for(int i = 0; i < length; i++) Console.Write($"{i, 5}");
			Console.WriteLine(" |");
		}

		private static void PrintFiller(int length)
		{
			Console.Write("    |" + new String(' ', length * 5) + " |\n");
		}
	}
}
