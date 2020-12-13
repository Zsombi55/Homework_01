/*
 * User: Zsombor
 * Date: 2020-12-12
 * Time: 22:04
 * 6th.
 */

using System;

namespace LoginLoops
{
// Goal: 2 constant sting User&Pass, ask input while not equals, ifOK print msg, ifNO print so & repeat, max 3 tries; THREE versions: FOR, WHILE, DO-WHILE.
	class Program
	{
		public static void Main(string[] args)
		{
			string[] loginData = { "Meme.5", "Mama+5" }; // User name, Password.
			string[] askLabels = { "Enter User Name: ", "Enter Password: " }; // Input request in order.

			string[] inValues = new string[2]; // Store user input.
			
			// --- VERSION 1, FOR
/*			for(int tries = 0; tries < 3; tries++)
			{
				Console.WriteLine($"\nTry {tries + 1} out of 3.\n");

				ReadInput(askLabels, inValues);
				bool isOk = CheckInputFOR(loginData, inValues);

				if(isOk)
				{
					Console.WriteLine("=====\nWelcome!");
					break;
				} else {
					if(tries == 2 && !isOk) {
						Console.WriteLine("=====\nThere are NO more tries! Please restart.");
						break;
					}
					continue;
				}
			}
*/
			// --- VERSION 2, WHILE
			int tries = 0;
			while(tries < 3)
			{
				Console.WriteLine($"\nTry {tries + 1} out of 3.\n");

				ReadInput(askLabels, inValues);
				bool isOk = CheckInputFOR(loginData, inValues);

				if(isOk)
				{
					Console.WriteLine("=====\nWelcome!");
					break;
				} else {
					if(tries == 2 && !isOk) {
						Console.WriteLine("=====\nThere are NO more tries! Please restart.");
						break;
					}
					tries++;
					continue;
				}
			}

			Console.Write("\nEnd.\n"); Console.ReadKey();
		}

		/// <summary>
		/// Get user input, store in predefined array.
		/// </summary>
		/// <param name="labels">Predefined text & order by which to ask input.</param>
		/// <param name="values">Store input here.</param>
		/// <returns>The input-filled array.</returns>
		private static string[] ReadInput(string[] labels, string[] values)
		{
			Console.Write(labels[0]); // User Name
			values[0] = Console.ReadLine();

			Console.Write(labels[1]); // Password
			values[1] = Console.ReadLine();
			
			return values;
		}

		/// <summary>
		/// Check if the stored input values are the same as what's required.
		/// </summary>
		/// <param name="namePass">Predefined values to check input against.</param>
		/// <param name="values">Stored input.</param>
		/// <returns>Boolean: are they the same?</returns>
		private static bool CheckInputFOR(string[] namePass, string[] values)
		{
			// null check unnecesary: if empty/ null/ wrong = NOT equal anyways.
			if(! (namePass[0].Equals(values[0]) && namePass[1].Equals(values[1])) )
			{
				Console.WriteLine("Incorrect input!"); // Bad.
				return false;
			}

			return true; // Good.
		}
	}
}
