using System;
using System.Collections.Generic;

namespace BasicPathingLabyrinth
{
	class Surveyor
	{
		/// <summary>
		/// Get the start position coordinates.
		/// </summary>
		/// <param name="mapData">The matrix previously extracted from the input file.</param>
		/// <returns>An integer array.</returns>
		public static int[] GetStartPosition(int[,] mapData)
		{
			int[] start = new int[2];
			int rowi; int coli;
			for (rowi = 0; rowi < mapData.GetLength(0); rowi++)
            {
				for (coli = 0; coli < mapData.GetLength(1); coli++)
                {
					if(mapData[rowi, coli] == 2) // See "MapData.txt".
					{
						start[0] = rowi;
						start[1] = coli;
						goto End;
					}
				}
            }
			End:
			return start;
		}

		/// <summary>
		/// Get the end goal position coordinates.
		/// </summary>
		/// <param name="mapData">The matrix previously extracted from the input file.</param>
		/// <returns>An integer array.</returns>
		public static int[] GetEndPosition(int[,] mapData)
		{
			int[] ending = new int[2];
			int rowi; int coli;
			for (rowi = 0; rowi < mapData.GetLength(0); rowi++)
            {
				for (coli = 0; coli < mapData.GetLength(1); coli++)
                {
					if(mapData[rowi, coli] == 1) // See "MapData.txt".
					{
						ending[0] = rowi;
						ending[1] = coli;
						goto End;
					}
				}
            }
			End:
			return ending;
		}

		/// <summary>
		/// Look around the current cell clockwise, using the 4 primary directions: up (x, y+1), right (x+1, y), down (x, y-1) and left (x-1, y).
		/// </summary>
		/// <param name="mapData">The matrix previously extracted from the input file.</param>
		/// <returns>The surveyed copy of the map where instead of 0-s the passable cell values are the cell-step distance from the starting cell.</returns>
		
		
		public static void Surveying(int[,] mapData)
		{
			int[,] surveyData = new int[mapData.GetLength(0), mapData.GetLength(0)];
			
			int[] startPos = new int[2];  int[] endPos = new int[2];
			startPos = GetStartPosition(mapData);
			endPos = GetEndPosition(mapData);

			List<int[]> onHold = new List<int[]>();

	// For the standard  X, Y  coordinate system: row index /rowi = X and column index /coli = Y	|	x = coli | y = rowi
			int rowi = startPos[0];  int coli = startPos[1];
			surveyData[rowi, coli] = 0;
			Console.WriteLine($"The End.\nStart coordinates (x, y): [{coli}, {rowi}] ;\n");
			do
			{	// check if it's a free cell.
				if(mapData[rowi - 1, coli] == 0)
				{
					surveyData[rowi - 1, coli] = mapData[rowi - 1, coli] + 1;
				}
				else if(mapData[rowi, coli + 1] == 0)
				{
					surveyData[rowi, coli + 1] = mapData[rowi, coli + 1] + 1;
				}
				else if(mapData[rowi + 1, coli] == 0)
				{
					surveyData[rowi + 1, coli] = mapData[rowi + 1, coli] + 1;
				}
				else if(mapData[rowi, coli - 1] == 0)
				{
					surveyData[rowi, coli - 1] = mapData[rowi, coli - 1] + 1;
				} else // now check if it's the exit.
				if(mapData[rowi - 1, coli] == 2)
				{
					surveyData[rowi - 1, coli] = mapData[rowi - 1, coli] + 1;  break;
				}
				else if(mapData[rowi, coli + 1] == 2)
				{
					surveyData[rowi, coli + 1] = mapData[rowi, coli + 1] + 1;  break;
				}
				else if(mapData[rowi + 1, coli] == 2)
				{
					surveyData[rowi + 1, coli] = mapData[rowi + 1, coli] + 1;  break;
				}
				else if(mapData[rowi, coli - 1] == 2)
				{
					surveyData[rowi, coli - 1] = mapData[rowi, coli - 1] + 1;  break;
				}
			} while ((rowi > 0 && rowi < mapData.Length) && (coli > 0 && coli < mapData.Length));
			Console.WriteLine($"End coordinates (x, y): [{coli}, {rowi}] .");
		}

		private static List<int[]> PeekAround(List<int[]> toPeek, int[,] _mapData)
		{
			foreach(int[] elem in toPeek)
			{
				//
			}
			toPeek.Clear();
			
			return toPeek;
		}
	}
}
