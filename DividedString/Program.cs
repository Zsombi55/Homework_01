/*
 * User: Zsombor
 * Date: 2020-12-03
 * Time: 11:51
 * 1st.
 */

using System;

namespace DividedString
{
// Goal: in 10 numbers, out in a line separated by: semicolon, colon, whitespace and pipe sign by programmer choice.
	class Program
	{
		// static string[] numbers = new string[4];
		// static string separator; // <- this did not keep its value so it didn't work here.

		public static void Main(string[] args)
		{
			string[] numbers = new string[10];

			FillNumber(numbers);
			// string separator = FillSeparator();
			// Outputting(numbers, separator);
			Outputting(numbers, FillSeparator());
			Console.Write("\nEnd."); Console.ReadKey();
		}

		private static string[] FillNumber(string[] numbers)
		{
			int le = numbers.Length; float f; bool isOk = true; string s;
			Console.WriteLine("Enter {0} numbers:", le);
			// string nr = CheckNumber(Console.ReadLine());
			while(isOk)
			{
				for(int i = 0; i < le; i++)
				{
					s = Console.ReadLine();
					if(float.TryParse(s, out f)) { numbers[i] = s; isOk = false; }
					else { Console.WriteLine("Invalid input! Try again."); i--; }
				}
			}
			Console.WriteLine();
			return numbers;

		}

/*		// FIXME couldn't find a way to separate input & validation like I did with the Separator.
		private static string CheckNumber(string[] cnr) {
			bool isOk = true;  float f;
			while (isOk) {
				if(float.TryParse(s, out f)) {cnr[i] = s;  isOk = false; }
				else { Console.WriteLine("Invalid input! Try again.");  i--; }
			}
			return cnr;
		}
*/
		private static string FillSeparator()
		{
			Console.WriteLine("Choose a separator (semicolon \";\" , comma \",\" , whitespace \" \" , or pipe \"|\"):");
			string se = CheckSeparator(Console.ReadLine());
			Console.WriteLine();
			return se;
		}

		private static string CheckSeparator(string cse)
		{
			bool isOk = true;
			while(isOk)
			{
				if(cse.Equals(";") | cse.Equals(",") | cse.Equals(" ") | cse.Equals("|")) { isOk = false; }
				else { Console.WriteLine("Invalid input! Try again."); cse = Console.ReadLine(); }
			}
			return cse;
		}

		private static void Outputting(string[] numbers, string separator)
		{
/*			for(i = 0; i < numbers.Length; i++) { Console.Write("{0};", numbers[i])); }  Console.WriteLine();
			for(i = 0; i < numbers.Length; i++) { Console.Write("{0},", numbers[i]); }  Console.WriteLine();
			for(i = 0; i < numbers.Length; i++) { Console.Write("{0} ", numbers[i]); }  Console.WriteLine();
			for(i = 0; i < numbers.Length; i++) { Console.Write("{0}|", numbers[i]); }*/
/*			Console.WriteLine(string.Join(";", numbers));
			Console.WriteLine(string.Join(",", numbers));
			Console.WriteLine(string.Join(" ", numbers));
			Console.WriteLine(string.Join("|", numbers));*/
			Console.WriteLine(string.Join(separator, numbers));
		}
	}
}
