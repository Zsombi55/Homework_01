using System;
using System.IO;

namespace BasicPathingLabyrinth
{
	class MatrixHelper
	{
		public static int[,] ReadMap()
		{
			string path = @"D:\SULI\C# .NET\Homework_01\BasicPathingLabyrinth\MapData.txt";

			/* First check size (1st line Value) to width (2nd line Length) egality else there's no reason to read the rest;
			 * We need a SQUARE (N x N), not a rectangle (N x M).*/
			StreamReader readFile = new StreamReader($"{path}");
			string sizeStr = readFile.ReadLine(); // Reads the first line.
			if (!int.TryParse(sizeStr, out int size)) throw new Exception($"ERROR..  invalid or no value.");
			string[] widthCheck = readFile.ReadLine().Split(" "); // Reads the second line.
			if (widthCheck.Length != size) throw new Exception($"ERROR..  the specified size does not match the map width.");
			// TODO: Can the length (row count) be checked without using LINQ ?
			
			//string input = File.ReadAllText(Directory.GetCurrentDirectory()+@"\MapData.txt"); // I didn't want to specify an exact path outside project folder !
			string input = File.ReadAllText($"{path}"); // Each line becomes a string element.
			
			int[,] result = new int[size, size];
			
			// TODO: get number matrix from txt into integer matrix for use; account for spaces and end of line "  \r\n "-s.

			
			for(int i = 0; i < input.Length-1; i++)
			{
				for(int j = 0; j < input.Length -1; j++)
					result[i, j] = input[i];
			}

/*			while (input != null)
			{
				for (int rowi = 1; rowi < size-1; rowi++)
				{
					string[] sVar = input.Split(" ");
					for (int coli = 0; coli < size; coli++)
					{
						int.TryParse(sVar[coli], out int o);
						result[rowi, coli] = o;
					}
				}
			}
*/

		/*	for (int rowi = 1; rowi < input.Length-1; ++rowi)
			{
				string line = input[rowi].ToString();
				for (int coli = 0; coli < result.GetLength(1); ++coli)
				{
					string[] split = line.Split(" ");
					result[rowi, coli] = Convert.ToInt32(split[coli]);
				}
			}
    */
			return result;
		}
	}
}
