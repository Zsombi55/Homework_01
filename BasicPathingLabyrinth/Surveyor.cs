using System;
using System.Collections.Generic;

namespace BasicPathingLabyrinth
{
	class Surveyor
	{
	// For the standard  X, Y  coordinate system: row index /rowi = X and column index /coli = Y	|	x = coli | y = rowi .

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
			Console.WriteLine($"ROWI {rowi} | MapData X Length {mapData.GetLength(0)} |\n" +
								$"COLI {coli} | MapData Y Length {mapData.GetLength(1)} |\n");
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
			if(mapData[rowi, coli] != -1 && surveyData[rowi, coli] == 0) // An empty "int[]" element gets a value of "0" by default instead of "null".
			{
				Console.WriteLine($"ROWI {rowi} | COLI {coli} | MapData {mapData[rowi, coli]} | SurveyData {surveyData[rowi, coli]} .\n");
				return true; // if NOT a "wall" OR if IS marked unvisited THEN passable: True.
			}
			Console.WriteLine($"ROWI {rowi} | COLI {coli} | MapData {mapData[rowi, coli]} | SurveyData {surveyData[rowi, coli]} .\n");
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
			Console.WriteLine($"Current coordinates (x, y): [{coli}, {rowi}] .\n");
			int[] lookingAt = new int[2];
			int xi = lookingAt[0];  int yi = lookingAt[1];

			surveyData[rowi, coli] = 0; // Surveyor start coordinate's cell cost ; also the first discovered cell.
			waiting.Enqueue(curPos);
			while(waiting.Count != 0)
			{
				curPos = waiting.Dequeue(); // Take the next one from the queue as the current position to look around.
				
				for(int cy = 1; cy <= 4; cy++) // Looking cycle: up, right, down, left.
				{
					Console.WriteLine($"Current coordinates to look around (x, y): [{coli}, {rowi}] .");
					lookingAt = looking(rowi, coli, lookingAt, cy);					
					//Console.WriteLine($"The  lookingAtCor  coordinates POST--AFTER--SWITCH TWO: {string.Join(", ", lookingAt)} .");
					xi = lookingAt[0];  yi = lookingAt[1];
					Console.WriteLine($"Now looking at direction {cy} starting clockwise, its coordinates (x, y) are: [{yi}, {xi}] .");
					//while(xi != srowi && yi != scoli)
					//{
						bool ii = isInside(mapData, xi, yi);  bool ip;
						if(ii == false) ip = false;  else ip = isPassable(mapData, surveyData, xi, yi);
					
						Console.WriteLine($"\nVALIDATE ONE: Inside the map? {ii} | Is the cell clear AND unvisited? {ip} .\n"); // Test.
						//if(isInside(mapData, xi, yi) == true && isPassable(mapData, surveyData, xi, yi) == true)
						if(ii == true && ip == true)
						{
							Console.WriteLine($"\nVALIDATE TWO: Inside the map? {ii} | Is the cell clear AND unvisited? {ip} .\n"); // Test.
							
							//if(lookingAt == startPos)
							if(xi != srowi && yi != scoli)
							{
								surveyData[xi, yi] = surveyData[rowi, coli] + 1;
								goto End;
							}
							surveyData[xi, yi] = surveyData[rowi, coli] + 1;
							waiting.Enqueue(lookingAt); // Place what was just marked in the queue to be looked around later.
						}
					//}
				}
			}
			End:  Console.WriteLine("print out weighted matrix");
					
			//> go through weighted matrix looking for shortest path
			//> print original matrix highlighting shortest path
			//> End App.
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

	// if matrix has no embedded _root value ask from User, otherwise (like in this app.) the parameter is not required.
*/
/*
		x = coli	y = rowi					N ( x , y - 1 )( coli , rowi - 1 )
																|
																|
		W ( x - 1 , y )( coli - 1 , rowi )	----	O ( x , y )( coli , rowi )	----	E ( x + 1 , y )( coli + 1 , rowi )
																|
																|
												S ( x , y + 1 )( coli , rowi + 1 )
*/
		/// <summary>
		/// Switch looking directions relative to the current cell coordinates.
		/// </summary>
		/// <param name="currentRowi">Current cell row index.</param>
		/// <param name="currentColi">Current cell column index.</param>
		/// <param name="lookAtCor">Coordinate pair of the cell we are to look at after the switch.</param>
		/// <param name="turnCycle">The number of the current direction; we always look around.</param>
		/// <returns></returns>
		private static int[] looking(int currentRowi, int currentColi, int[] lookAtCor, int turnCycle)
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
