using System;
using System.IO;

namespace BasicPathingLabyrinth
{
	class MatrixHelper
	{
		public static int[,] ReadMap()
        {
			String input = File.ReadAllText(@"../MapData.txt");

			StreamReader readFile = new StreamReader(@"../MapData.txt");
			if(int.TryParse(readFile.ReadLine(), out int size)) throw new Exception($"ERROR..  invalid or no value.");
			string[] lengthCheck = readFile.ReadLine().Split(" ");
			if(lengthCheck.Length != size) throw new Exception($"ERROR..  the specified size does not match the map length.");
			
			int rowi = 1, coli = 0;
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

			return result;
		}
	}
}
