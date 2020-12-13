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

			Console.WriteLine($"{string.Join(" ", mainVectorData)}"); // Input OK.
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
	}
}
