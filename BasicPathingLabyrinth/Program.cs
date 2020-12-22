/*
 * User: Zsombor
 * Date: 2020-12-21
 * Time: 12:12
 * 12th.
 */

using System;

namespace BasicPathingLabyrinth
{
// Goal: "basic labyrinth path finder"; "0" for clear cell, "-1" for wall, "int.MaxValue" for occupied, and "int.MinValue" for exit. Square map data from user-input /txt file into matrix, mark clear cells with values in mirror matrix, using these values find shortest path out, print the path as a list of coordinates.
	class Program
	{
		static void Main(string[] args)
		{
			int[,] matrix = MatrixHelper.ReadMap();
			for (int rowi = 0; rowi < matrix.GetLength(0); rowi++)
            {
				for (int coli = 0; coli < matrix.GetLength(1); coli++)
                {
					Console.Write($"{matrix[rowi, coli], 2}");
				}
				
				Console.WriteLine();
            }

			Console.WriteLine("\n--------------------\nEnd.\n");
		}


	}
}
