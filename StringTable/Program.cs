/*
 * User: Zsombor
 * Date: 2020-12-05
 * Time: 13:55
 * 2nd.
 */

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
			string[] textLines = ReadLinesOfText(separator); // NOTE: it might be good to add the expected line elements' count as parameter form here.

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
	}
}
