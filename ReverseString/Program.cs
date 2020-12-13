/*
 * User: Zsombor
 * Date: 2020-12-06
 * Time: 15:04
 * 4th.
 */
using System;

namespace ReverseString
{
// Goal: get 1 word text, reverse order characters, compare result with original text, return true/false.
	class Program
	{
		public static void Main(string[] args)
		{
			string text = ""; int tl = 0; string mirror = ""; bool isPalindrome = false;

			while(tl == 0 && tl < 3)
			{
				Console.WriteLine("Enter word:"); text = Console.ReadLine();
				tl = text.Length;
			}

			char[] tempText = new char[tl]; tempText = text.ToCharArray();

			for(int c = tl - 1; c >= 0; c--)
			{
				mirror += tempText[c];
			}

//			foreach  (char c in tempText)  Console.Write(c);
			Console.WriteLine("\nText: {0} ; Mirrored: {1}", text, mirror);

			if(text == mirror) isPalindrome = true;
			Console.WriteLine("\nIs the word   {0}   a palindrome? : {1}", text, isPalindrome);

			Console.Write("\nEnd."); Console.ReadKey();
		}
	}
}