/*
 * User: Zsombor
 * Date: 2021-01-12
 * Time: 19:40
 * 13th.
 */
using System;

namespace RecursiveVectoring
{
// Goal 1: have a number array (a vector), without predefined loops such as FOR, FOREACH, WHILE, etc.: find the smallest and the largest values using Recursion.
// Goal 2: given an ordered number array (more than 3 elements), ask what number to look for, use recursion to find it then print its index;
// By instructor request: "Binary search" is to be used.
	class Program
	{
		static void Main(string[] args)
		{
		// ----- G.1:
			int[] numbers = new int[10];  int elementIndex = 0;

			MakeVector(numbers);
			Console.WriteLine($"The vector: {string.Join(" ", numbers)}\nLength: {numbers.Length}.");

		// Find and print the minimum and maximum elements:
			Console.WriteLine($"-----\nThe smallest element is: {GetMin(numbers, elementIndex)}\n");
			elementIndex = 0;
			Console.WriteLine($"The largest element is: {GetMax(numbers, elementIndex)}");

		// ----- G.2:
			//int[] numbers = new int[10] {10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
			Array.Sort(numbers);
			//Array.Reverse(numbers); // Can be used with the 1-st try but not the 2-nd.
			
			Console.Write($"---------------\n\n" +
							$"These are the numbers: {string.Join(", ", numbers)}.\n" +
							$"Choose one to get its index (stops at first find):\n");
			
			int theNumber = GetNumber(numbers);  Console.WriteLine("\nThe chosen number is: " + theNumber);

		// Find the chosen number and print its index:
			// First try, not sure would be approved, BUT it works on any ordering.
			//Console.WriteLine($"\nThe index is: {GetNrIndexA(numbers, index: 0, endIndex: numbers.Length - 1, theNumber)}");
			
			// Second try, "textbook" binary search, BUT only works on ascending ordering.
			Console.WriteLine($"\nThe index is: {GetNrIndexB(numbers, index: 0, endIndex: numbers.Length - 1, theNumber)}");

			Console.WriteLine("\nEnd.\n");
		}

		/// <summary>
		/// Read user input to make vector.
		/// </summary>
		/// <param name="theVector">Primary integer array to store user input.</param>
		/// <returns>The filled array.</returns>
		private static int[] MakeVector(int[] theVector)
		{
			Console.WriteLine("Enter 10 integer numbers to create the vector: ");
			
			for(int i = 0; i < theVector.Length; i++)
			{
				try { if(int.TryParse(Console.ReadLine(), out int tv)) theVector[i] = tv; }
				
				catch(Exception e) { Console.WriteLine($"ERROR.. {e}"); }
			}
			Console.WriteLine("-----");
			
			return theVector;
		}

		/// <summary>
		/// Find and print the minimum element.
		/// </summary>
		/// <param name="theVector">The vector to work with.</param>
		private static int GetMin(int[] theVector, int index)
		{
			if (index < theVector.Length)
				return Math.Min(theVector[index], GetMin(theVector, index + 1));
			
			return theVector[0];
		}
		
		/// <summary>
		/// Find and print the maximum element.
		/// </summary>
		/// <param name="theVector">The vector to work with.</param>
		private static int GetMax(int[] theVector, int index)
		{
			if (index < theVector.Length)
				return Math.Max(theVector[index], GetMax(theVector, index + 1));
			
			return theVector[0];
		}

		// -------------------
		private static int GetNumber(int[] numbers)
		{
			string s = Console.ReadLine();
			if(! int.TryParse(s, out int r))
			{ throw new Exception("\nERROR.. Invalid value.\n"); }
			else if(r < numbers[0] || r > numbers[numbers.Length - 1])
			{ throw new Exception("\nERROR.. The number is too small or too large.\n"); }
			
			return r;
		}

		// 1-st attempt - OK but not binary - BUT works on any ordering.
		private static int GetNrIndexA(int[] numbers, int index, int endIndex, int number)
		{
			if(number == numbers[index]) // If first element.
				return index;

			else if (number == numbers[endIndex]) // If last element.
				return (endIndex);

			return GetNrIndexA(numbers, number, index + 1, endIndex - 1);
		}

		// 2-nd attempt - OK binary - BUT only works on ascending ordering.
		private static int GetNrIndexB(int[] numbers, int index, int endIndex, int number)
		{
			int middleIndex = (index + endIndex) / 2;

            if (numbers[middleIndex] == number)
				return middleIndex;

			else if (index >= endIndex)
				return -1;

			else if (number < numbers[middleIndex])
				return GetNrIndexB(numbers, index, middleIndex - 1, number);
            
			return GetNrIndexB(numbers, middleIndex + 1, endIndex, number);
		}
	}
}
