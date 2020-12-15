/*
 * User: Zsombor
 * Date: 2020-12-15
 * Time: 17:40
 * 8th.
 */
using System;

namespace BasicMatricing
{
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

			for (int i = 0; i < inMatrix.GetLength(0); i++) {
                for (int j = 0; j < inMatrix.GetLength(1); j++) {
                    inMatrix[i, j] = DefineTheMatrixLimits($"Enter element [{i}, {j}] = ");
                }
            }

			return inMatrix;
		}

		private static void PrintTheMatrix(int[,] inMatrix)
		{
			if (inMatrix is null) return;

            int rows = inMatrix.GetLength(0);
            int cols = inMatrix.GetLength(1);

            Console.WriteLine("-----------");
			for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) // Put all same row items on the same line.
                {
                    Console.Write($"{inMatrix[i, j], 5}"); // <item, distance between items on same line>.
                }

                Console.WriteLine(); // New row.
            }
			Console.WriteLine("-----------");
		}

	}
}
