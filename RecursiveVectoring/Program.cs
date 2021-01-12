/*
 * User: Zsombor
 * Date: 2021-01-12
 * Time: 19:40
 * 13th.
 */
using System;

namespace RecursiveVectoring
{
// Goal: have a number array (a vector), without predefined loops such as FOR, FOREACH, WHILE, etc.: find the smallest and the largest values - using Recursion.
	class Program
	{
		static void Main(string[] args)
		{
			int[] mainVectorData = new int[10];  int elementIndex = 0;
			
			MakeVector(mainVectorData);
			Console.WriteLine($"The vector: {string.Join(" ", mainVectorData)}\nLength: {mainVectorData.Length}.");

		// Find and print the minimum and maximum elements:
			Console.WriteLine($"-----\nThe smallest element is: {GetMin(mainVectorData, elementIndex)}\n");
			elementIndex = 0;
			Console.WriteLine($"The largest element is: {GetMax(mainVectorData, elementIndex)}");

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
	}
}
