/*
 * User: Zsombor
 * Date: 2020-12-06
 * Time: 17:01
 * 3rd.
 */
using System;

namespace StingFinder
{
// Goal: get text & search word, literal search of whole words, character groups between 2 symbol /whitespace characters or start/end of line.
	class Program
	{
		public static void Main(string[] args)
		{
			string text, word; int am = 0;

//			while(text.IsNullOrEmpty || word.IsNullOrEmpty){}
			Console.WriteLine("Enter text:");
			text = Console.ReadLine(); //.ToLower();
			Console.WriteLine("Enter search word"); // (casing is irrelevant):");
			word = Console.ReadLine(); //.ToLower();

			am = HowOften(text, word);

			Console.WriteLine("\nFound the word:    {0}\n\nThis often:\t\t{1}", word, am);

			Console.Write("\nEnd."); Console.ReadKey();
		}

// not quite.. "az" matches the char.pair regardless of placement (part of a longer word too), "Az" matches exactly, "aZ" & "AZ" never unless exact.
		private static int HowOften(string theText, string countThis)
		{
			int co = 0, n = 0;
			if(countThis != "")
			{
				while((n = theText.IndexOf(countThis, n, StringComparison.InvariantCultureIgnoreCase)) != -1)
				{
					bool isStartOfWordBefore = n == 0 || (n - 1 >= 0) && theText[n - 1] == ' ';
					bool isEndOfWordAfter = (n + countThis.Length + 1 < theText.Length) && theText[n + countThis.Length] == ' ';

					if(isStartOfWordBefore && isEndOfWordAfter)
					{
						co++;
					}

					n += countThis.Length;
				}
			}
			return co;
		}
	}
}