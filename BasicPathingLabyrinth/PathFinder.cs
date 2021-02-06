﻿using System;
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
		//public static void PathCounter(int[,] weightedMatrix, int[] beginHere, int[] endHere)
		{
			int[] currentPosition = new int[2];
			currentPosition = beginHere;
			
			int rowi = currentPosition[0];
			int coli = currentPosition[1];
			
			int[] peekAt = new int[2];
			int xi = peekAt[0];
			int yi = peekAt[1];

			List<int[]> path = new List<int[]>();  path.Add(beginHere);

			Console.WriteLine($"\nStart coordinates (x, y):    {beginHere[1]}, {beginHere[0]}\n" +
								$"End coordinates (x, y):     {endHere[1]}, {endHere[0]}\n");
			Console.WriteLine("-----");

			bool isThisTheEnd;
			int c = 1;
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

							Console.WriteLine($"\n\t{c}:", 2);
							c++;
							for(int j = 0; j < path.Count; j++) Console.Write($"[{string.Join(", ", path[j])}]; ");
						}
					}
					
					isThisTheEnd = (xi == endHere[0] && yi == endHere[1]);
					if(isThisTheEnd) // TODO: Why is this ignored without negation !?
					{
						//Console.WriteLine($"Number of steps found: {path.Count - 1} .\n");
						Console.WriteLine($"\n{c}:: {coli}, {rowi} | {string.Join(", ", currentPosition)} | {yi}, {xi} .");
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
			Console.WriteLine("---");
			Console.WriteLine($"Number of steps found: {thePath.Count - 1} .\n");
			//Console.WriteLine($"{c}:: {coli}, {rowi} | {string.Join(", ", currentPosition)} | {yi}, {xi} .");
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
