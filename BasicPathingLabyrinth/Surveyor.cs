using System;
using System.Collections.Generic;

namespace BasicPathingLabyrinth
{
// TODO: add an exception for the event that the desired start and end positions cannot be connected without jumping over "impassable" cells.
	class Surveyor
	{
	// For the standard  X, Y  coordinate system: row index /rowi = Y and column index /coli = X	|	x = coli | y = rowi .

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
						return start;
					}
				}
            }
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
		public static int[,] Surveying(int[,] mapData)
		{
			int[,] surveyData = new int[mapData.GetLength(0), mapData.GetLength(0)];
			addDefaultSurveyData(surveyData);
			
			// Start, End, and Current cell coordinates.
			int[] startPos = GetStartPosition(mapData);
			int[] endPos = GetEndPosition(mapData);
			
			// Buffer, put here the just checked clear cells (did not already have a cost, no walls) to peek around next cycle.
			Queue<int[]> waiting = new Queue<int[]>();

			// Start cell row & column indexes.
			int srowi = startPos[0];
			int scoli = startPos[1];
			
			// Set current position to the coordinates where the Survey will start -- from the End Goal ("endPos").
			int[] curPos = endPos;
			int rowi = curPos[0];
			int coli = curPos[1];
			
			// Declared & initialized here because it is used 2x in this code bracket.
			int[] lookingAt = new int[2];
			int xi = lookingAt[0];
			int yi = lookingAt[1];

			bool lookAtIsStart, lessThanIntMaxSize, isInsideBounds, isPassableCell;

			surveyData[rowi, coli] = 0; // Surveyor start coordinate's cell cost ; also the first discovered cell.
			
			waiting.Enqueue(curPos);

			while(waiting.Count != 0)
			{
				Array.Copy(waiting.Dequeue(), curPos, 2); // Take the next one from the queue as the current position to look around.
				rowi = curPos[0];
				coli = curPos[1];

				for(int cy = 1; cy <= 4; cy++) // Looking cycle: up, right, down, left.
				{
					lookingAt = MatrixHelper.SwitchView(rowi, coli, cy);
					xi = lookingAt[0];
					yi = lookingAt[1];
					
					isInsideBounds = isInside(mapData, xi, yi);
					
					if(isInsideBounds == false)  isPassableCell = false;
					else  isPassableCell = isPassable(mapData, surveyData, xi, yi);
					
					if(isInsideBounds == true && isPassableCell == true)
					{
						lessThanIntMaxSize = (surveyData[rowi, coli] + 1 <= int.MaxValue);
						lookAtIsStart = (xi == srowi && yi == scoli);
						if(lookAtIsStart)
						{
							// Check against too large matrix size.
							// Since each cell is given an "integer" type weight, if the area is too big the value could reach past the type's maximum value.
							if(lessThanIntMaxSize)
							{
								surveyData[xi, yi] = surveyData[rowi, coli] + 1;
								
								return surveyData;
							}
							else throw new OverflowException("ERROR.. There are too many cells to map with BFS.");
						}
						if(surveyData[rowi, coli] + 1 <= int.MaxValue)
						{
							surveyData[xi, yi] = surveyData[rowi, coli] + 1;
							
							int[] t = new int[2];
							Array.Copy(lookingAt, t, lookingAt.Length);

							waiting.Enqueue(t); // Place what was just marked in the queue to be looked around later.
						}
						else throw new OverflowException("ERROR.. There are too many cells to map with BFS.");
					}
				}
			}
			
			lookAtIsStart = (xi == srowi && yi == scoli);
			if(lookAtIsStart)
			{
				Console.WriteLine($"FINALLY.. Print out weighted matrix; {yi}, {xi} .");
				return surveyData;
			}
			else
			{
				Console.WriteLine("ERROR.. Target coordinates cannot be reached!\n" +
					"Check \"MapData.txt\" making sure there is NO obstruction between the desired Start and End positions.");
				return new int[0,0];
			}
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
		/// <param name="surveyData">A mirror map matrix where temporary background data will be stored.</param>
		/// <param name="rowi">Index of rows, vertical traversal.</param>
		/// <param name="coli">Index of columns, horizontal traversal.</param>
		/// <returns>A boolean for passable or not.</returns>
		private static bool isPassable(int[,] mapData, int[,] surveyData, int rowi, int coli)
		{
			if(mapData[rowi, coli] != -1 && surveyData[rowi, coli] == -1)
			{
				return true; // if NOT a "wall" OR if IS marked unvisited (cell value IS NOT int.MinValue) THEN passable: True.
			}
			
		    return false;
		}

		/// <summary>
		/// Fill the mirror map data with values to mark unvisited cells.
		/// </summary>
		/// <param name="surveyThis">A mirror map matrix where temporary background data will be stored.</param>
		private static void addDefaultSurveyData(int[,] surveyThis)
		{
			for(int i = 0; i < surveyThis.GetLength(0); i++)
			{
				for(int j = 0; j < surveyThis.GetLength(1); j++)
				{
					surveyThis[i, j] = -1;
				}
			}
		}
	}
}
