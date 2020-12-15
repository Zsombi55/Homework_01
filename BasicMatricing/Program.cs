/*
 * User: Zsombor
 * Date: 2020-12-15
 * Time: 17:40
 * 8th.
 */
using System;

namespace BasicMatricing
{
// Goal: get a matrix, print the secondary diagonal line, transpose the matrix and print result, check for identity matrix.
	class Program
	{
		static void Main(string[] args)
		{
			int cols = DefineTheMatrixLimits("Row length (nr. of columns) = ");
			int rows = DefineTheMatrixLimits("Column length (nr. of rows) = ");
			string askMatrix = "\n\tEnter The Matrix:\n--------------------------";
			int[,] theMatrix = new int[rows, cols];

			GetTheMatrix(askMatrix, theMatrix);
			PrintTheMatrix(theMatrix);
			
			FindSecondaryDiagonal(theMatrix);
			
			Console.WriteLine("\nEnd.\n");
		}

		/// <summary>
		/// Get the desired dimensions of the matrix from the user.
		/// </summary>
		/// <param name="label">Ask this.</param>
		/// <returns>The validated number.</returns>
		private static int DefineTheMatrixLimits(string label)
		{
			Console.Write(label);  string s = Console.ReadLine();
			if(! int.TryParse(s, out int r))
			{ throw new Exception($"ERROR.. \nThis \"{s}\" is not a valid number!"); }

			return r;
		}

		/// <summary>
		/// Ask the user to fill up the empty matrix.
		/// </summary>
		/// <param name="label">Ask this.</param>
		/// <param name="inMatrix">The empty matrix to be filled.</param>
		/// <returns>The filled matrix.</returns>
		private static int[,] GetTheMatrix(string label, int[,] inMatrix)
		{
			Console.WriteLine(label);

			for (int rowi = 0; rowi < inMatrix.GetLength(0); rowi++) {
                for (int coli = 0; coli < inMatrix.GetLength(1); coli++) {
                    inMatrix[rowi, coli] = DefineTheMatrixLimits($"Enter element [{rowi}, {coli}] = ");
                }
            }

			return inMatrix;
		}

		private static void PrintTheMatrix(int[,] inMatrix)
		{
			if (inMatrix is null) return;

            int rows = inMatrix.GetLength(0); // Nr. of  rows.
            int cols = inMatrix.GetLength(1); // Nr. of  columns.

            Console.WriteLine("-----------");
			for (int rowi = 0; rowi < rows; rowi++)
            {
                for (int coli = 0; coli < cols; coli++) // Put all same row items on the same line.
                {
                    Console.Write($"{inMatrix[rowi, coli], 5}"); // <item, distance between items on same line>.
                }

                Console.WriteLine(); // New row.
            }
			Console.WriteLine("-----------");
		}

		private static void FindSecondaryDiagonal(int[,] inMatrix)
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
