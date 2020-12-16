/*
 * User: Zsombor
 * Date: 2020-12-16
 * Time: 08:50
 * 8th.
 */

using System;

namespace BasicMatricing
{
	class GetTransposed
	{
		/// <summary>
		/// Transpose and print The Matrix.
		/// </summary>
		/// <param name="inMatrix">The previously filled matrix.</param>
		public static int[,] TransposeMatrix(int[,] inMatrix)
		{
			// A [row, col] -> B [row (a col), col (a row)]
			Console.WriteLine($"Transposed Matrix\n" +
				$"Row length (nr. of columns) = {inMatrix.GetLength(0)}\n" +
				$"Column length (nr. of rows) = {inMatrix.GetLength(1)}");

			int[,] transposed = new int[inMatrix.GetLength(1), inMatrix.GetLength(0)];

			for (int inRowi = 0; inRowi < inMatrix.GetLength(0); inRowi++) {
                for (int inColi = 0; inColi < inMatrix.GetLength(1); inColi++) {
                    transposed[inColi, inRowi] = inMatrix[inRowi, inColi];
                }
            }

			return transposed;
		}
	}
}
