/*
 * User: Zsombor
 * Date: 2020-12-16
 * Time: 07:56
 * 8th.
 */

using System;

namespace BasicMatricing
{
	class SetPrint
	{
		/// <summary>
		/// Get the desired dimensions of the matrix from the user.
		/// </summary>
		/// <param name="label">Ask this.</param>
		/// <returns>The validated number.</returns>
		public static int DefineTheMatrixLimits(string label)
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
		public static int[,] GetTheMatrix(string label, int[,] inMatrix)
		{
			Console.WriteLine(label);

			for (int rowi = 0; rowi < inMatrix.GetLength(0); rowi++) {
                for (int coli = 0; coli < inMatrix.GetLength(1); coli++) {
                    inMatrix[rowi, coli] = DefineTheMatrixLimits($"Enter element [{rowi}, {coli}] = ");
                }
            }

			return inMatrix;
		}

		public static void PrintTheMatrix(int[,] inMatrix)
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
	}
}
