/*
 * User: Zsombor
 * Date: 2020-12-16
 * Time: 08:02
 * 8th.
 */

using System;

namespace BasicMatricing
{
	class GetDiagonal
	{
		public static void FindSecondaryDiagonal(int[,] inMatrix)
		{
			if(inMatrix is null) return;

            int coll = inMatrix.GetLength(0); // C O L U M N  length.
            int rowl = inMatrix.GetLength(1); // R O W  length.
            int minSize = Math.Min(rowl, coll);
			Console.WriteLine($"Row length: {rowl} | Column length: {coll} | Minimum size: {minSize} .");

            Console.WriteLine();
            Console.WriteLine("Secondary diagonal line:\n-------------------------");

			if(coll == minSize)
			{
				int elem = rowl - 1;
				for(int row = 0; row < minSize; row++)
				{
					Console.Write(inMatrix[row, elem]);

					if(row < minSize - 1) { Console.Write(", ");  elem--; }
				}
			}
			else
			{
				int elem = rowl - 1;
				for(int row = 0; row < minSize; row++)
		        {
					Console.Write(inMatrix[row, elem]);

					if(row < minSize - 1) { Console.Write(", ");  elem--; }
				}
			}

            Console.Write(" .\n");
		}
	}
}
