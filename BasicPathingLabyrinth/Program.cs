/*
 * User: Zsombor
 * Date: 2020-12-21
 * Time: 12:12
 * 12th.
 * -----------------------------
 * Refactoring Date: 2021-02-05
 * RefactoringTime: 10:04
 */

using System;
using System.Text;
using System.Collections.Generic;

namespace BasicPathingLabyrinth
{
// Goal: "basic labyrinth path finder"; "0" for clear cell, "-1" for wall, "int.MaxValue" for occupied, and "int.MinValue" for exit. Square map data from user-input /txt file into matrix, mark clear cells with values in mirror matrix, using these values find shortest path out, print the path as a list of coordinates. -- BUT for easier testing, in the MapData.txt I have marked the start position with  " 2 "  and the end goal as  " 1 ".
	class Program
	{
		static void Main(string[] args)
		{
			int[,] matrix = MatrixHelper.ReadMap();
			int size = matrix.GetLength(0);
			int[] startPosition = Surveyor.GetStartEndPositions(matrix, startEndValue: 2);
			int[] endPosition = Surveyor.GetStartEndPositions(matrix, startEndValue: 1);
			List<int[]> shortestPath;
			int[,] listToArray; // couldn't find another way to convert only once but use in 2 places, needed for easier List<int[]> to int[,] comparison.

			PrintHeader(width: size);

			PrintContent(matrix, pathList: listToArray = null); // Basic map representation; with color coded walls, start & end positions.

			PrintFooter(width: size);
			
			Console.Write($"\nThe designated starting position coordinates (x, y) are:  [ {startPosition[1]} , {startPosition[0]} ].\n" +
						  $"The designated ending position coordinates (x, y) are:  [ {endPosition[1]} , {endPosition[0]} ].\n" +
						  "--------------------\n");

			int[,] weightedMatrix = Surveyor.Surveying(matrix);

			Console.WriteLine("Survey complete. Looking for optimal path..\n" +
							  "--------------------\n" +
							  $"Survey data integrity (OK if > 1): {weightedMatrix.Length} .");

			shortestPath = PathFinder.PathCounter(weightedMatrix, startPosition, endPosition);

			PrintResult(weightedMatrix, startPosition, endPosition, pathList: shortestPath);
			
			Console.WriteLine("\n--------------------\n");

			listToArray = ListToArray(shortestPath);

			PrintContent(matrix, pathList: listToArray);  // Basic map representation; with color coded walls, start & end positions, plus the shortest path.

			Console.WriteLine("\n--------------------\nEnd.\n");
		}


		private static void PrintHeader(int width)
		{
			Console.Write("    |");
			for(int i = 0; i < width; i++) Console.Write($"{i, 5}");
			Console.WriteLine(" |");
			Console.Write(new String('-', width * 6) + "\n");
		}

		private static void PrintFooter(int width)
		{
			Console.Write(new String('-', width * 6) + "\n");
			Console.Write("    |");
			for(int i = 0; i < width; i++) Console.Write($"{i, 5}");
			Console.WriteLine(" |");
		}

		/// <summary>
		/// Prints the matrix color-coded based on specific values in an arranged table format.
		/// </summary>
		/// <param name="matrix">A filled integer matrix.</param>
		private static void PrintContent(int[,] matrix, int[,] pathList)
		{
			bool b = false;
			int x = 0;

			for (int rowi = 0; rowi < matrix.GetLength(0); rowi++)
            {
				Console.Write($"{rowi, 4}|");
				for (int coli = 0; coli < matrix.GetLength(1); coli++)
                {
					if(matrix[rowi, coli] == -1) // TODO: change  " if - else "  into  "switch " ??
					{
						Console.ForegroundColor = ConsoleColor.DarkBlue; // TODO: Put these into separate functions, eg.: "PrintWall(int cellContent)".
						Console.Write($"{matrix[rowi, coli], 5}");
						Console.ResetColor();
					}
					else if(matrix[rowi, coli] == 0)
					{
						if(pathList == null)
						{
							Console.Write($"{matrix[rowi, coli], 5}"); // If we don't yet have the shortest path traced, then just use default color.
						}
						else // TODO: Remake to not use conversion from  List<int[]>  to  int[,] .
						{
							if(pathList.Length == 0) throw new ArgumentOutOfRangeException(nameof(pathList), "Too few shortest path list content.");
							
							for(; x < pathList.GetLength(0) - 1; x++)
							{
								b = (rowi == pathList[x, 0] && coli == pathList[x, 1]);
								if(b)
								{
									Console.ForegroundColor = ConsoleColor.Yellow;
									Console.Write($"{matrix[rowi, coli], 5}");
									Console.ResetColor();
									x = 0;
									break;
								}
							}

							if(b == false)
							{
								Console.Write($"{matrix[rowi, coli], 5}");
								x = 0;
							}
						}
					}
					else if (matrix[rowi, coli] == 2)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write($"{matrix[rowi, coli], 5}");
						Console.ResetColor();
					}
					else //if (matrix[rowi, coli] == 1)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write($"{matrix[rowi, coli], 5}");
						Console.ResetColor();
					}
					
				}
				Console.Write($" |");
				Console.Write($"{rowi, 3}" + "\n");

				// TODO: find a way to print the matrix with lines separated by a blank line, But without any at the end.
				PrintBorder(matrix.GetLength(0));
            }
		}

		// Used in "PrintContent".
		private static void PrintBorder(int width)
		{
			Console.Write("    |" + new String(' ', width * 5) + " |\n");
		}

		/// <summary>
		/// Prints the shortestpath coordinates of a prepared & weighted map-matrix, in a line.
		/// </summary>
		/// <param name="weightedMatrix">A weighted mirror of the original matrix.</param>
		/// <param name="startPosition">Extracted start coordinates.</param>
		/// <param name="endPosition">Extracted end coordinates.</param>
		/// <param name="pathList">Coordinate List of the shortest path.</param>
		private static void PrintResult(int[,] weightedMatrix, int[] startPosition, int[] endPosition, List<int[]> pathList)
		{
			if(weightedMatrix.Length > 1) // The surveying was successful and did not return a [0,0] (single cell) matrix.
			{	
				if(pathList != null)
				{
					StringBuilder s = new StringBuilder();
			
					for(int i = 0; i < pathList.Count; i++)
					{
						s.Append($"[{string.Join(' ', pathList[i])}]").Append(',');
					}
			
					Console.WriteLine($"\n{s.ToString().TrimEnd(new char[] {','})}");
				}
				else throw new IndexOutOfRangeException("ERROR.. Something went wrong during result List<int[]> creation or retrieval.");

			}
			else throw new ArgumentOutOfRangeException("ERROR.. Insufficient cells.\nThe Start and End points could not be connected.\n" +
					"Verify that \"MapData.txt\" contains correct values.");
		}


		private static int[,] ListToArray(List<int[]> pathList)
		{
			int[,] newArray = new int[pathList.Count, pathList[0].Length];

			for(int i = 0; i < pathList.Count; i++)
			{
				for(int j = 0; j < pathList[i].Length; j++)
				{
					newArray[i, j] = pathList[i][j];
				}
			}

			return newArray;
		}
	}
}
