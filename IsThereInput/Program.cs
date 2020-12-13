/*
 * User: Zsombor
 * Date: 2020-12-07
 * Time: 20:17
 * 5th.
 * ----- Made By Instructor, after collective request -----
 */
using System;

namespace IsThereInput
{
// Goal: get 3 text, check content, for each input if null print "no content" else return input; USE NOT: loop instructions (eg. if, for), try "??" when reading.
    class Program
    {
        static void Main(string[] args)
        {
            string value = ReadString("Enter value (1): ")
                ?? ReadString("Enter value (2): ")
                ?? ReadString("Enter value (3): ")
                ?? "\nNo content.";

            Console.WriteLine(value);
        }

        private static string ReadString(string label)
        {
            Console.Write(label);
            string value = Console.ReadLine();

            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }
}