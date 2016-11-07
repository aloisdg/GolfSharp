using System;
using System.Collections.Generic;
using System.Linq;

namespace GolfSharp
{
	public static partial class MainClass
	{


		/* String functions */
		//char array to string
		public static string o(this IEnumerable<char> input) => new string(input.ToArray());
		//object to string
		public static string T<TSource>(this TSource input) => input.ToString();
		//join array with string
		public static String j<TSource>(this IEnumerable<TSource> input, string seperator = "") => String.Join(seperator, input.s(n => n.T()));
		//smart substring
		public static String R(this string input, int startIndex, int length, string replacement = "")
		{
			int extra = length - (input.L() - startIndex);
			extra = extra < 0 ? 0 : extra;
			return input.Substring(startIndex, Math.Min(length, input.L() - startIndex)) + r(0, extra).s(n => replacement).j();
		}
		//toupper
		public static String U(this string input) => input.ToUpper();
		//char toupper
		public static Char U(this char input) => Char.ToUpper(input);
		//tolower
		public static String u(this string input) => input.ToLower();
		//char tolower
		public static Char u(this char input) => Char.ToLower(input);

	}
}
