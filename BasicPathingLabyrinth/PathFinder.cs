using System;
using System.Collections.Generic;

namespace BasicPathingLabyrinth
{
	class PathFinder
	{
		/// <summary>
		/// Counts and collects the cells of the shortest path, then prints them out.
		/// </summary>
		/// <param name="weightedMatrix">The weighted mirror of the primary map data matrix. Each cell has a "step" cost from the End (0) to Start.</param>
		/// /// <param name="beginHere">The designated starting osition, in the input file it is marked with  " 2 ".</param>
		/// /// <param name="endHere">The designated goal osition, in the input file it is marked with  " 1 ".</param>
		public static List<int[]> PathCounter(int[,] weightedMatrix, int[] beginHere, int[] endHere)
		{
			int[] currentPosition = new int[2];
			currentPosition = beginHere;
			
			int rowi = currentPosition[0];
			int coli = currentPosition[1];
			
			int[] peekAt = new int[2];
			int xi = peekAt[0];
			int yi = peekAt[1];

			List<int[]> path = new List<int[]>();  path.Add(beginHere);

			Console.WriteLine($"\nStart coordinates (x, y):    {beginHere[1]}, {beginHere[0]} ;\n" +
								$"End coordinates (x, y):     {endHere[1]}, {endHere[0]} .");
			
			bool isThisTheEnd;
			
			//int c = 1; // Used for "TracePath_Test".

			do
			{
				for(int i = 1; i <= 4; i++)
				{
					peekAt = MatrixHelper.SwitchView(rowi, coli, i);
					xi = peekAt[0];
					yi = peekAt[1];
					
					if((xi < weightedMatrix.GetLength(0) && yi < weightedMatrix.GetLength(1) && xi >= 0 && yi >= 0)
						&& (weightedMatrix[xi, yi] != -1))
					{
						if(weightedMatrix[xi, yi] == weightedMatrix[rowi, coli] - 1)
						{
							int[] t = new int[2];
							Array.Copy(peekAt, t, 2);
							
							rowi = t[0];
							coli = t[1];
							
							path.Add(t);

							//TracePath_Test(path, currentCycle: c); // Prints out the traced path every step cycle.
						}
					}
					
					isThisTheEnd = (xi == endHere[0] && yi == endHere[1]);
					if(isThisTheEnd)
					{
						EndPrint(path);
						return path;
					}

				}
				isThisTheEnd = (xi == endHere[0] && yi == endHere[1]);
			}
			while(!isThisTheEnd); // DO - WHILE

			Console.WriteLine($"\n\nTracing ended.");

			return path;
		}

		private static void EndPrint(List<int[]> thePath)
		{
			Console.WriteLine("\n--------------------\n");
			Console.WriteLine($"Number of steps found: {thePath.Count - 1} .");
		}


		/// <summary>
		/// TEST.. Prints out all cells each cycle along the traced path.
		/// </summary>
		/// <param name="thePath">The current path traced; may not be complete.</param>
		/// <param name="currentCycle">The tracing cycle: look around checking weights, if viable found then step there.. repeat.</param>
		private static void TracePath_Test(List<int[]> thePath, int currentCycle)
		{
			Console.WriteLine($"\n\t{currentCycle}:", 2);
			currentCycle++;
			for(int j = 0; j < thePath.Count; j++)
				Console.Write($"[{string.Join(", ", thePath[j])}]; ");
		}
	}
}
