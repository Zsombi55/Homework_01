/*
 * User: Zsombor
 * Date: 2020-12-16
 * Time: 08:53
 * 8th.
 */
using System;

namespace BasicMatricing
{
	class CheckIdentity
	{
		// get matrix (n^2 size ! , 1-s on main diagonal 0 elsewhere), multiply with itself, if result is identical to original TRUE, else FALSE.
		public static void IsIdentity(int[,] inMatrix)
		{
			string askIsIt = "\nIs The Matrix likely to be an \"Identity Matrix\"?";
			int idRows = inMatrix.GetLength(0);  int idCols = inMatrix.GetLength(1);
			int[,] identity = new int[idRows, idCols];
			double s = Math.Sqrt(idRows * idCols);
			
			Console.WriteLine($"-------------------------\n" +
				"Identity Matrix check\n----------\n" +
				$"Row length (nr. of columns): {idCols}\n" +
				$"Column length (nr. of rows): {idRows}\n" +
				$"This one's square root: {s}");
			
			// FIRST - an IM is a matrix with equal length rows and columns.
			if(idRows == s && idCols == s)
			{
				Console.Write($"{askIsIt}  May be {true}.");

				// SECOND - an IM on the power of 2 (basically multiplied ONCE with itself) ia always identical to the one being evaluated!
				MakeIdentity(inMatrix, identity);

				Console.WriteLine("\n\nThe Matrix, Origins:");  SetPrint.PrintTheMatrix(inMatrix);
			
				Console.WriteLine("\nThe Matrix, Squared:");  SetPrint.PrintTheMatrix(identity);
			
				Console.WriteLine($"\nIs \"The Matrix\" an \"Identity Matrix\"?  {VerifyIdentity(inMatrix, identity)}.");
			}		
			else Console.Write($"{askIsIt}  Definitely {false}.\n" +
				$"Such a matrix has to be square (equal length rows & columns) to even be considered.\n");
        }

		private static int[,] MakeIdentity(int[,] inMatrix, int[,] idMatrix)
		{
			for(int rowi = 0; rowi < inMatrix.GetLength(0); rowi++)
			{
				for(int coli = 0; coli < inMatrix.GetLength(1); coli++)
				{
					int sum = 0; // { [ (A1 * B1) + (A1 * B2) + (A1 * B3) ... ], [ (A2 * B1) + ...], [ (A3 * B1) + ...], ... }
					for(int rowi2 = 0; rowi2 < inMatrix.GetLength(0); rowi2++)
					{
						sum += inMatrix[rowi, rowi2] * inMatrix[rowi2, coli];
					}

					idMatrix[rowi, coli] = sum;
				}
			}
			return idMatrix;
		}

		private static bool VerifyIdentity(int[,] inMatrix, int[,] idMatrix)
		{
			for (int rowi = 0; rowi < inMatrix.GetLength(0); rowi++)
			{
				for (int coli = 0; coli < inMatrix.GetLength(1); coli++)
				{
					if (idMatrix[rowi, coli] != inMatrix[rowi, coli])
					{
						return false;  // If even one element is different, the two matrices differ
					}
				}
			}
			return true;
		}
	}
}
