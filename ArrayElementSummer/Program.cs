/*
 * User: Zsombor
 * Date: 2020-12-20
 * Time: 19:30
 * 9th.
 */

using System;

namespace ArrayElementSummer
{
// Goal: get numbers from the user into an array, add the 1st element to 0, add thenext one to it etc., make new array, put results in it, then print it.
	class Program
	{
		static void Main(string[] args)
		{
			string askLength = "Specify how many numbers to use (between 2 and 10): ";
			string askNumber = "List the numbers, one per line:";
			
			int le = GetLength(askLength);  Console.WriteLine($"\nLength: {le} .");
			
			int[] inNumber = new int[le];
			int[] ouNumber = new int[le];

			GetNumbers(askNumber, inNumber);  Console.Write($"The numbers: {string.Join(", ", inNumber)} .");

			Summer(inNumber, ouNumber);  Console.Write($"{string.Join(", ", ouNumber)}");

			Console.WriteLine("\n-----\nEnd.\n");
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

		private static int[] GetNumbers(string askNr, int[] inNr)
		{
			Console.WriteLine($"{askNr}");

			for(int i = 0; i < inNr.Length; i++)
			{
				string n = Console.ReadLine();
				if(! int.TryParse(n, out int nr))
				{ throw new Exception("\nERROR.. Invalid value.\n"); }

				inNr[i] = nr;
			}

			return inNr;
		}

		private static int[] Summer(int[] inNr, int[] ouNr)
		{
			Console.Write("\n\nResult: ");

			for(int i = 0, r = 0; i < inNr.Length; i++)
			{
				r += inNr[i];	

				ouNr[i] = r;
			}

			return ouNr;
		}
	}
}
