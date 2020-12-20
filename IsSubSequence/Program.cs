/*
 * User: Zsombor
 * Date: 2020-12-20
 * Time: 21:08
 * 8th.
 */

using System;

namespace IsSubSequence
{
// Goal: get 2 int arrays "a" & "b", check if "b"'s elements are part of "a" (in the same order??), true/false.
	class Program
	{
		static void Main(string[] args)
		{
			string askLengths ="Specify how many numbers to use (between 2 and 10):\n";
			string askNumbers = "List the numbers, one per line:";
		
			Console.WriteLine("Initialize the 2 arrays.\n--------------------\n");

			int le = GetLength(askLengths);  Console.WriteLine($"\nLength: {le} .");
			int[] arrayA = new int[le];
			GetNumbers(askNumbers, arrayA);  Console.Write($"\nThe numbers: {string.Join(", ", arrayA)} .");

			Console.WriteLine("\n--------------------\n");

			le = GetLength(askLengths);  Console.WriteLine($"\nLength: {le} .");
			int[] arrayB = new int[le];
			GetNumbers(askNumbers, arrayB);  Console.Write($"\nThe numbers: {string.Join(", ", arrayB)} .");

			Console.WriteLine("\n--------------------\n");
			ValidateAB(arrayA, arrayB);

			Console.WriteLine("\nEnd.\n");
		}

		private static int GetLength(string askLe)
		{
			Console.WriteLine($"{askLe}");
			
			string s = Console.ReadLine();
			if(! int.TryParse(s, out int r))
			{ throw new Exception("\nERROR.. Invalid value.\n"); }
			else if(r < 2 || r > 10)
			{ throw new Exception("\nERROR.. The number is too small or too large.\n"); }
			
			return r;
		}

		private static int[] GetNumbers(string askNr, int[] arrayX)
		{
			Console.WriteLine($"{askNr}");

			for(int i = 0; i < arrayX.Length; i++)
			{
				string n = Console.ReadLine();
				if(! int.TryParse(n, out int nr))
				{ throw new Exception("\nERROR.. Invalid value.\n"); }

				arrayX[i] = nr;
			}

			return arrayX;
		}

		private static void ValidateAB(int[] arrayOne, int[] arrayTwo)
		{
			bool b = false;  int c = 0; // Count how often it's true. If this will be less than the second's length, then return False.

			for(int bi = 0; bi < arrayTwo.Length; bi++)
			{
				for(int ai = 0; ai < arrayOne.Length; ai++)
				{
					if(arrayTwo[bi] = arrayOne[ai])
					{
						c++;
					}
				}
			}

			if(c == arrayTwo.Length) b = true;

			Console.WriteLine($"Does array  A  contain all elements of array  B ?  {b} .");
		}
	}
}
