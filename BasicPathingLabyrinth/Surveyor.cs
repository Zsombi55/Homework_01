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
		/// Check wether where we are looking is inside or out of bounds of the matrix.
		/// </summary>
		/// <param name="rowi">Index of rows, vertical traversal.</param>
		/// <param name="coli">Index of columns, horizontal traversal.</param>
		/// <returns>If out of bounds (from the matrix), return false.</returns>
		private static bool isInside(int[,] mapData, int rowi, int coli)
		{
			if(rowi < mapData.GetLength(0) && coli < mapData.GetLength(1) && rowi >= 0 && coli >= 0)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Check wether we are looknig at a "wall" (-1) or a "path" (0) cell.
		/// </summary>
		/// <param name="mapData">The matrix previously extracted from the input file.</param>
		/// <param name="surveyData"></param>
		/// <param name="rowi">Index of rows, vertical traversal.</param>
		/// <param name="coli">Index of columns, horizontal traversal.</param>
		/// <returns>A boolean for passable or not.</returns>
		private static bool isPassable(int[,] mapData, int[,] surveyData, int rowi, int coli)
		{
			if(mapData[rowi, coli] != -1 | surveyData[rowi, coli] == 0) // An empty "int[]" element gets a value of "0" by default instead of "null".
			{
				return true; // if NOT a "wall" OR if IS marked unvisited THEN passable: True.
			}
		    return false;
		}

		// Temp, may not keep this.
		private static int findMinDist(int dist, int minDist, int srowi, int scoli, int rowi, int coli)
		{
			if (rowi == srowi && coli == scoli)
			{
			    minDist = Math.Min(dist, minDist);
			    return minDist;
			}
			return 0;
		}

		/// <summary>
		/// Look around the current cell clockwise, using the 4 primary directions: up (x, y+1), right (x+1, y), down (x, y-1) and left (x-1, y).
		/// </summary>
		/// <param name="mapData">The matrix previously extracted from the input file.</param>
		/// <returns>The surveyed copy of the map where instead of 0-s the passable cell values are the cell-step distance from the starting cell.</returns>
		public static void Surveying(int[,] mapData)
		{
			int[,] surveyData = new int[mapData.GetLength(0), mapData.GetLength(0)];
			int minDist = 0;  int dist = 0;
			
			int[] startPos = new int[2];  int[] endPos = new int[2];  int[] curPos = new int[2]; // Start, End, and Current cell coordinates.
			startPos = GetStartPosition(mapData);
			endPos = GetEndPosition(mapData);

			Queue<int[]> waiting = new Queue<int[]>(); // Buffer, put here just checked clear cells (did not already have a cost, no walls) to peek around next cycle.

			int srowi = startPos[0];  int scoli = startPos[1];
			Console.WriteLine($"Start coordinates (x, y): [{scoli}, {srowi}] ;");

			int erowi = endPos[0];  int ecoli = endPos[1];
			Console.WriteLine($"End coordinates (x, y): [{ecoli}, {erowi}] ;\n");
			
			// Set current position to the coordinates where the Survey will start -- by Instructor request from the End Goal ("endPos").
			curPos = endPos;  int rowi = curPos[0];  int coli = curPos[1];
			Console.WriteLine($"Current coordinates (x, y): [{coli}, {rowi}] .");
			int[] lookAround = new int[2];  int[] lookingAt = new int[2];

			surveyData[rowi, coli] = 0; // Surveyor start coordinate's cell cost ; also the first discovered cell.
			waiting.Enqueue(curPos);
			while(waiting.Count != 0)
			{
				lookAround = waiting.Dequeue();
				if(lookAround == startPos)
				{
					//return lookAround;
					Console.WriteLine($"Found Start coordinates (x, y): [{lookAround[1]} , {lookAround[0]}] .");
					break;
				}
				//	for all cells from "lookAround" to "lookingAt" in matrix.adjacentCells("lookAround") do
				//		if "lookingAt" is not labeled as discovered then
				//			label "lookingAt" as discovered
				//			Q.enqueue("lookingAt")

				for(int i = 1; i <= 4; i++)
				{
					
				}
			}
/*			
			if(isInside(mapData, rowi, coli) && isPassable(mapData, surveyData, rowi, coli))
			{
				bool ii = isInside(mapData, rowi, coli);
				bool ip = isPassable(mapData, surveyData, rowi, coli);
				Console.WriteLine($"\nInside the map? {ii} | Is the cell clear? {ip} .\n"); // Test.
			}
*/
		}
/*
	function Surveyor(matrix, _root)
		let Q be a queue
		label root as discovered
		Q.enqueue(root)
		while Q is not empty do
			Q.dequeue(v)
			if v is the goal then
				return v
			for all cells from v to w in G.adjacentCells(v) do
				if w is not labeled as discovered then
					label w as discovered
					Q.enqueue(w)

	// if matrix has no embedded _root value ask from User, otherwise the parameter is not required.
*/
/*
		x = coli	y = rowi ::					N ( x , y - 1 )( coli , rowi - 1 )
																|
																|
		W ( x - 1 , y )( coli - 1 , rowi )	----	O ( x , y )( coli , rowi )	----	E ( x + 1 , y )( coli + 1 , rowi )
																|
																|
												S ( x , y + 1 )( coli , rowi + 1 )
*/

/*
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
*/
	}
}
