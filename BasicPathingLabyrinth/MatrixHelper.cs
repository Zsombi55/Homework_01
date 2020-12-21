﻿using System;
using System.IO;

namespace BasicPathingLabyrinth
{
	class MatrixHelper
	{
		public static int[,] ReadMap()
		{
			/* First check size (1st line Value) to width (2nd line Length) egality else there's no reason to read the rest;
			 * We need a SQUARE (N x N), not a rectangle (N x M).*/
			StreamReader readFile = new StreamReader(@"D:\SULI\C# .NET\Homework_01\BasicPathingLabyrinth\MapData.txt");
			string sizeStr = readFile.ReadLine(); // Reads the first line.
			if (!int.TryParse(sizeStr, out int size)) throw new Exception($"ERROR..  invalid or no value.");
			string[] lengthCheck = readFile.ReadLine().Split(" "); // Reads the second line.
			if (lengthCheck.Length != size) throw new Exception($"ERROR..  the specified size does not match the map length.");

			//string input = File.ReadAllText(Directory.GetCurrentDirectory()+@"\MapData.txt"); // I didn't want to specify an exact path outside project folder !
			string input = File.ReadAllText(@"D:\SULI\C# .NET\Homework_01\BasicPathingLabyrinth\MapData.txt");
			
			int[,] result = new int[size, size];
			
			// TODO: get number matrix from txt into integer matrix for use.

/*			while (input != null)
			{
				for (int rowi = 1; rowi < size; rowi++)
				{
					var v = input.Split(" ");
					int.TryParse(v, out int[] o);
					for (int coli = 0; coli < size; coli++)
					{
						result[rowi, coli] = o[coli];
					}
				}
			}
*/


/*			int rowi = 1; int coli;
			int[,] result = new int[size, size];
			foreach (var row in input.Split("\n"))
			{
				coli = 0;
				foreach (var col in row.Trim().Split(" "))
				{
					result[rowi, coli] = int.Parse(col.Trim());
					coli++;
				}
				rowi++;
			}
*/
			return result;
		}
	}
}