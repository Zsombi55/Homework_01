/*
 * User: Zsombor
 * Date: 2020-12-21
 * Time: 09:27
 * 11th.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BasicFindPairs
{
// Goal: get an int array, double iterate: check [i] against [j] (start  i + 1), while  i < j  , print match count; eg. 1 2 3 1 1 3 = 4 [(0,3),(0,4),(2,5),(3,4)].
	class Program
	{
		static void Main(string[] args)
		{
			string askLength ="Specify how many numbers to use (between 1 and 10):\n";
			string askNumbers = "List the numbers, one per line:";

			Console.WriteLine("Set an array of integers to find repeating numbers in.\n--------------------\n");

			int le = GetLength(askLength);  Console.WriteLine($"\nLength: {le} .");
			int[] arr = new int[le];
			GetNumbers(askNumbers, arr);  Console.Write($"\nThe numbers: {string.Join(", ", arr)} .");

			Console.WriteLine("\n--------------------\n");

			var v = FindPairs(arr);
			StringBuilder s = new StringBuilder();
			
			for(int i = 0; i < v.Count; i++) s.Append($"[{string.Join(" ", v[i])}]").Append(",");
			
			Console.WriteLine($"\n\n{s.ToString().TrimEnd(new char[] {','})}");

			Console.WriteLine("\nEnd.\n");
		}

		private static int GetLength(string askLe)
		{
			Console.WriteLine($"{askLe}");
			
			string s = Console.ReadLine();
			if(! int.TryParse(s, out int r))
			{ throw new Exception("\nERROR.. Invalid value.\n"); }
			else if(r < 0 || r > 10)
			{ throw new Exception("\nERROR.. The number is too small or too large.\n"); }
			
			return r;
		}

		private static int[] GetNumbers(string askNr, int[] array)
		{
			Console.WriteLine($"{askNr}");

			for(int i = 0; i < array.Length; i++)
			{
				string n = Console.ReadLine();
				if(! int.TryParse(n, out int nr))
				{ throw new Exception("\nERROR.. Invalid value.\n"); }

				array[i] = nr;
			}

			return array;
		}

		private static List<int[]> FindPairs(int[] array)
		{
			List<int[]> pairs = new List<int[]>();
			int c = 0; // Number of found pairs.

			for(int ai = 0; ai < array.Length-1; ai++)
			{
				for(int aj = ai + 1; aj < array.Length; aj++)
				{
					if(array[ai] == array[aj])
					{
						c++;
						Console.WriteLine($"Ai {ai} | Ain {array[ai]} | Aj {aj} | Ajn {array[aj]} | Count {c}");
						pairs.Add(new int[2] {ai, aj});
					}
				}
			}
			
			return pairs;
		}
	}
}
