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
			int cols = SetPrint.DefineTheMatrixLimits("Row length (nr. of columns) = ");
			int rows = SetPrint.DefineTheMatrixLimits("Column length (nr. of rows) = ");
			string askMatrix = "\n\tEnter The Matrix:\n--------------------------";
			int[,] theMatrix = new int[rows, cols];

			SetPrint.GetTheMatrix(askMatrix, theMatrix);
			SetPrint.PrintTheMatrix(theMatrix);
			
			GetDiagonal.FindSecondaryDiagonal(theMatrix);

			SetPrint.PrintTheMatrix(GetTransposed.TransposeMatrix(theMatrix));
			
			CheckIdentity.IsIdentity(theMatrix);

			Console.WriteLine("\nEnd.\n");
		}
	}
}
