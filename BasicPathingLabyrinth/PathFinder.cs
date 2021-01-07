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
		//public static List<int[]> PathCounter(int[,] weightedMatrix, int[] beginHere, int[] endHere)
		public static void PathCounter(int[,] weightedMatrix, int[] beginHere, int[] endHere)
		{
			int[] currentPosition = new int[2];  currentPosition = beginHere;
			int rowi = currentPosition[0]; int coli = currentPosition[1];
			//int rowi = beginHere[0]; int coli = beginHere[1];

			int[] peekAt = new int[2];  int xi = peekAt[0]; int yi = peekAt[1];

			List<int[]> path = new List<int[]>();  path.Add(beginHere);

			Console.WriteLine($"\nStart coordinates (x, y):    {beginHere[1]}, {beginHere[0]}\n" +
								$"End coordinates (x, y):     {endHere[1]}, {endHere[0]}\n"); // +
								//$"Begin counting here (x, y):  {currentPosition[1]}, {currentPosition[0]} .\n");
			Console.WriteLine("-----");

			int c = 1;
			do
			{
				for(int i = 1; i <= 4; i++)
				{
					peekAt = MatrixHelper.SwitchView(rowi, coli, peekAt, i);
					xi = peekAt[0]; yi = peekAt[1];

					if((xi < weightedMatrix.GetLength(0) && yi < weightedMatrix.GetLength(1) && xi >= 0 && yi >= 0) && (weightedMatrix[xi, yi] != -1))
					{
						if(weightedMatrix[xi, yi] == weightedMatrix[rowi, coli] - 1)
						{
							int[] t = new int[2];  Array.Copy(peekAt, t, 2);
							//rowi = currentPosition[0];  coli = currentPosition[1];
							rowi = t[0];  coli = t[1];
							path.Add(t);

							Console.WriteLine($"\t{c}:", 2);
							c++;
							for(int j = 0; j < path.Count; j++) Console.Write($"[{string.Join(", ", path[j])}]; ");
						}	
					}

					if(xi == endHere[0] && yi == endHere[1]) // TODO: Find out why this is ignored without negation !
					{
						//Console.WriteLine($"Number of steps found: {path.Count - 1} .\n");
						Console.WriteLine($"{c}:: {coli}, {rowi} | {string.Join(", ", currentPosition)} | {yi}, {xi} .");
						goto End;
						//return path;
					}
				}
			}
			while(xi != endHere[0] && yi != endHere[1]); // DO - WHILE

			End:
				Console.WriteLine("---");
				Console.WriteLine($"Number of steps found: {path.Count - 1} .\n");
				//Console.WriteLine($"{c}:: {coli}, {rowi} | {string.Join(", ", currentPosition)} | {yi}, {xi} .");
			//return path;
		}

	/*	
	 	// Print map marking The Path.
	 	public static void printCountedPath(int[,] matrix, int[] thePath)
		{
		//
		}
	*/
	}
}
