/*
 * User: Zsombor
 * Date: 2020-12-20
 * Time: 21:08
 * 8th.
 */

// TODO: change thrown exceptions to console writelines and set values to the next or maximum allowed, eg 10 for array length.

using System;

namespace IsSubSequence
{
// Goal: get 2 int arrays "a" & "b", check if "b"'s elements are part of "a" in the same order !! , true/false.
	class Program
	{
		static void Main(string[] args)
		{
			string askLengths ="Specify how many numbers to use (between 1 and 10):\n";
			string askNumbers = "List the numbers, one per line:";
			int maxLength = 10; // Initial maximum allowed length; changes to the array A's length, so we can't look for more than what we would have.
		
			Console.WriteLine("Initialize the 2 arrays.\n--------------------\n");

			maxLength = GetLength(askLengths, maxLength);  Console.WriteLine($"\nLength: {maxLength} .");
			int[] arrayA = new int[maxLength];
			GetNumbers(askNumbers, arrayA);  Console.Write($"\nThe numbers: {string.Join(", ", arrayA)} .");

			Console.WriteLine("\n--------------------\n");

			askLengths =$"Specify how many numbers to use (between 1 and {arrayA.Length}):\n";
			maxLength = GetLength(askLengths, maxLength);  Console.WriteLine($"\nLength: {maxLength} .");
			int[] arrayB = new int[maxLength];
			GetNumbers(askNumbers, arrayB);  Console.Write($"\nThe numbers: {string.Join(", ", arrayB)} .");

			Console.WriteLine("\n--------------------\n");
			ValidateAB(arrayA, arrayB);

			Console.WriteLine("\nEnd.\n");
		}

		private static int GetLength(string askLe, int maxLe)
		{
			Console.WriteLine($"{askLe}");
			
			string s = Console.ReadLine();
			if(! int.TryParse(s, out int r))
			{ throw new Exception("\nERROR.. Invalid value.\n"); }
			else if(r < 0 || r > maxLe)
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
			int lastPosition = -1; // When a match is found mark its index, so nothing gets counted before that: 1 3 5 1 2 3 -- 1 2 3 >> the first 3 is NOT a match.

			for(int bi = 0; bi < arrayTwo.Length; bi++)
			{
				for(int ai = 0; ai < arrayOne.Length; ai++)
				{
					if(ai > lastPosition && arrayOne[ai] == arrayTwo[bi])
					{
						lastPosition = ai;
						c++;
						Console.WriteLine($"Ai {ai} | An {arrayOne[ai]} | Bi {bi} | Bn {arrayTwo[bi]} | Count {c}");
						break;
					}
				}
			}

			if(c == arrayTwo.Length) b = true;

			Console.WriteLine($"\nDoes array  A  contain all elements of array  B ?  {b} .");
		}
	}
}
