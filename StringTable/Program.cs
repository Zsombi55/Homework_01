/*
 * User: Zsombor
 * Date: 2020-12-05
 * Time: 13:55
 * 2nd.
 */

// Commented the whole thing because it contains certain elements unrecognizable to SharpDevelop, such as the $ sign.
// This way it will not thow a fit while trying to build/debug the other projects I made where I take care to only use
// elements supported in .NET 4.5.2.

using System;

namespace StringTable
{
// Goal: get text, verify it has the appropriate type & nr. of separators, store in arrays /matrix, print formatted like borderless table.
	class Program
	{
		// FIXME: If an entry is not entered as the user is asked to the output will not have any separators !
		public static void Main(string[] args)
		{
			char separator = ReadSeparator(3, '|');
			string[] textLines = ReadLinesOfText(separator);

			for(int i = 0; i < textLines?.Length; i++)
			{
				string[] parts = textLines[i].Split(new[] { separator }, StringSplitOptions.None);

				foreach(string element in parts)
				{
					Console.Write(string.Format("{0,-6}", element));
				}

				Console.WriteLine();
			}

			Console.Write("\nEnd."); Console.ReadKey();

/*
			string[,] elementsTable = new string[3,3];
			
			FillElements(elementsTable);
			Outputting(elementsTable);
			Console.Write ("\nEnd.");  Console.ReadKey();
*/
		}

		private static int ReadNumber(string label, int maxTries, int defaultValue)
		{
			int tryNo = 1;
			bool isValid = false;

			Console.Write(label);
			while(!isValid && tryNo <= maxTries)
			{
				isValid = int.TryParse(Console.ReadLine(), out int number);

				if(isValid)
				{
					return number;
				}
				else
				{
					Console.WriteLine("The input value is not a valid number, please try again");
					Console.Write(label);
					tryNo++;
				}
			}

			Console.WriteLine($"You have exceeded the max attempts count, asuming {defaultValue}");
			return defaultValue;
		}

		private static char ReadSeparator(int maxTries, char defaultSeparator)
		{
			int triesNo = 1;
			bool isValid = false;

			while(!isValid && triesNo <= maxTries)
			{
				Console.Write("Please choose a separator (',', '|', ';')=");
				string s = Console.ReadLine();
				switch(s)
				{
					case ";":
					case ",":
					case "|":
						return s[0];

					default:
						Console.WriteLine("Wrong separator, please try again...");
						triesNo++;
						break;
				}
			}

			Console.WriteLine($"You have exceeded the max attempts count, asuming {defaultSeparator}");
			return defaultSeparator;
		}

		private static string ReadSeparatedLine(string label, char separator, int expectedMinElementsCount, int maxTries)
		{
			int tryNo = 1;
			bool isValid = false;

			while(!isValid && tryNo <= maxTries)
			{
				Console.Write(label);
				string s = Console.ReadLine();
				string[] parts = s.Split(new[] { separator }, StringSplitOptions.None);
				if(parts.Length >= expectedMinElementsCount)
				{
					return s;
				}

				tryNo++;
			}

			return new string(separator, expectedMinElementsCount);
		}

		private static string[] ReadLinesOfText(char separator)
		{
			int noOfLines = ReadNumber("Number of lines of text=", 3, 3);
			string[] textLines = new string[noOfLines];
			for(int i = 0; i < noOfLines; i++)
			{
				textLines[i] = ReadSeparatedLine($"Line {i + 1}=", separator, 3, 3);
			}

			return textLines;
		}

/* ----- FIRST TRIES, FAIL -----
		private static string[,] FillElements(string[,] elementsTable)
		{
			int rle = elementsTable.GetLength(0); // 2d GetLength(x): Rows: 0, Columns: 1.
			int cle = elementsTable.GetLength(1);
			string[] element = new string[3];

			Console.WriteLine("Enter {0} things divided by 1 pipe sign, \"|\":", rle);
			element = CheckText(Console.ReadLine()).Split('|');
			foreach(string e in element) Console.WriteLine("Input:  {0}", e); // input is entered.

			for(int i = 0; i < rle; i++)
			{
				for(int j = 0; j < cle; j++)
				{
					elementsTable[i, j] = element[j];
				}
			}
			foreach(string item in elementsTable) { Console.Write("{0} ", item); } // pass test

			Console.WriteLine(); return elementsTable;
		}

		// EXCEPTION if the pipes have nothing to separate, eg.: "|" , "|s|d" , "b|" , "||" ...
		private static string CheckText(string ct)
		{
			bool isOk = true;
			while(isOk)
			{
				if(!string.IsNullOrEmpty(ct) && ct.Contains("|"))
				{
					isOk = false;
				}
				else { Console.WriteLine("Invalid input! Try again."); ct = Console.ReadLine(); }
			}
			return ct;
		}

		private static void Outputting(string[,] theTable)
		{
			for(int i = 0; i < theTable.GetLength(0); i++)
			{
				Console.WriteLine(i);
				for(int j = 0; j < theTable.GetLength(1); j++)
				{
					Console.WriteLine("Element({0}, {1}) = {2}", i, j, theTable[i, j]);
				}
			}
		}
*/
	}
}