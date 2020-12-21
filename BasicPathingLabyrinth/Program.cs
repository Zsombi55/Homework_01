/*
 * User: Zsombor
 * Date: 2020-12-21
 * Time: 12:12
 * 12th.
 */

using System;
using System.IO;

namespace BasicPathingLabyrinth
{
// Goal: square map data from txt file into matrix (incl. start point), print the path coordinates to the exit.
	class Program
	{
		static void Main(string[] args)
		{
			foreach(var line in MatrixHelper.ReadMap()) Console.WriteLine(string.Join(" ", line));

			Console.WriteLine("\n--------------------\nEnd.\n");
		}


	}
}
