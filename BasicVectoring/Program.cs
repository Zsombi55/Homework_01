﻿/*
 * User: Zsombor
 * Date: 2020-12-15
 * Time: 13:58
 * 7th.
 */
using System;

namespace BasicVectoring
{
// Goal: read integers in vector, do calculations/manipulations: smallest & largest item index, sort as-& descending, print subvector of even & odd items, print a subvector with items of the original's section starting from a user given index and length; use a function like `string.Substring(index, length)`.
	class Program
	{
		static void Main(string[] args)
		{
			string askVector = "Enter 10 integer numbers to create the vector: ";
			int[] mainVectorData = new int[10];
			
			MakeVector(askVector, mainVectorData);
			Console.WriteLine($"The vector: {string.Join(" ", mainVectorData)}\nLength: {mainVectorData.Length}.");

			GetMinMax(mainVectorData); // Find and print the minimum and maximum elements.

			//SortAscDesc(mainVectorData); // Sort and print the vector in ascending and descending order.
			SortAsc(mainVectorData); // Sort and print the vector in ascending order.
			SortDes(mainVectorData); // Sort and print the vector in descending order.


			Console.Write("\nEnd.\n"); Console.ReadKey();
		}

		/// <summary>
		/// Read user input to make vector.
		/// </summary>
		/// <param name="label">Text by which to ask for input.</param>
		/// <param name="mainData">Primary integer array to store user input.</param>
		/// <returns>The filled array.</returns>
		private static int[] MakeVector(string label, int[] mainData)
		{
			Console.WriteLine(label);
			
			for(int i = 0; i < mainData.Length; i++)
			{
				try
				{
					if(int.TryParse(Console.ReadLine(), out int md))
						mainData[i] = md;
				}
				catch(Exception e)
				{ 
					Console.WriteLine($"ERROR.. {e}");
				}
			}
			Console.WriteLine("-----");
			
			return mainData;
		}

		/// <summary>
		/// Find and print the minimum and maximum elements.
		/// </summary>
		/// <param name="inVector">The vector to work with.</param>
		private static void GetMinMax(int[] inVector)
		{
			int min = inVector[0];  int max = inVector[0]; 
			for(int i = 1; i < inVector.Length; i++)
			{
				if(min > inVector[i]) min = inVector[i];
				if(max < inVector[i]) max = inVector[i];
			}
			
			Console.WriteLine("----------");
			Console.WriteLine($"The minimum (smallest) value is: {min}.\n" +
								$"The maximum (largest) value is: {max}.");
		}

/*		private static void SortAscDesc(int[] inVector) // --- Likely this is not what the instructor wanted. ---
		{
			
			Array.Sort(inVector);  Console.WriteLine($"{string.Join(" ", inVector)}");
			Array.Reverse(inVector);  Console.WriteLine($"{string.Join(" ", inVector)}");
		}
*/

		private static void SortAsc(int[] inVector)
		{
			// int[] sa = new int[inVector.Length];  int[] sd = new int[inVector.Length];
			// for(int e = 0; e < a.Length; e++) { sa[e] = inVector[e];  sd[e] = inVector[e]; }
			
			for (int i = 0; i < inVector.Length - 1; i++)  
			{  
				for (int j = 0; j < inVector.Length - 1; j++)  
				{  
					if (inVector[j] > inVector[j + 1])  
					{
						int t = inVector[j];  
						inVector[j] = inVector[j + 1];  
						inVector[j + 1] = t;  
					}
				}  
			}
			Console.WriteLine("----------");
			Console.WriteLine($"Sorted ascending: {string.Join(" ", inVector)}.\n");
		}	

		private static void SortDes(int[] inVector)
		{	
			for (int i = 0; i < inVector.Length - 1; i++)  
			{  
				for (int j = 0; j < inVector.Length - 1; j++)  
				{  
					if (inVector[j] < inVector[j + 1])  
					{  
						int t = inVector[j];  
						inVector[j] = inVector[j + 1];  
						inVector[j + 1] = t;  
					}
				}  
			}
			Console.WriteLine($"Sorted descending: {string.Join(" ", inVector)}.");
		}


	}
}