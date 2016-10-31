using System;
using i = System.Int32;
using l = System.Int64;
using f = System.Single;
using s = System.String;
using c = System.Char;
using b = System.Boolean;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using System.IO;
using System.Web;
namespace GolfSharp
{
	static class MainClass
	{
		
		public static void Main(string[] args)
		{
			/* put your code here */
		}
		/* constant variables */
		public static s z = "abcdefghijklmnop";
		public static s Z = "ABCDEFGHIJKLMNOP";


		/* String functions */
		public static String t(this object input) => input.ToString();
		public static String j<TSource>(this IEnumerable<TSource> input, string seperator = "") => String.Join(seperator, input.s(n => n.t()));
		public static String R(this string input, int startIndex, int length, string replacement = "")
		{
			int extra = length - (input.L() - startIndex);
			extra = extra < 0 ? 0 : extra;
			return input.Substring(startIndex,Min(length,input.L()-startIndex))+r(0,extra).s(n=>replacement).j();
		}


		/* LINQ functions */
		public static TSource[] a<TSource>(this IEnumerable<TSource> input) => input.ToArray();
		public static List<TSource> l<TSource>(this IEnumerable<TSource> input) => input.ToList();
		public static IEnumerable<TResult> s<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, TResult> predicate) => input.Select(predicate);
		public static IEnumerable<TSource> w<TSource>(this IEnumerable<TSource> input, Func<TSource, Boolean> predicate) => input.Where(predicate);
		public static IEnumerable<TResult> m<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, IEnumerable<TResult>> predicate) => input.SelectMany(predicate);
		public static IEnumerable<int> r(int start, int count) => Enumerable.Range(start, count);
		public static void f<TSource>(IEnumerable<TSource> input, Action<TSource> predicate) => input.ToList().ForEach(predicate);
		public static int L<TSource>(this IEnumerable<TSource> input) => input.Count();


		/* Output functions */
		public static void c<T>(T input) => Console.WriteLine(input);
		public static void C<T>(IEnumerable<T> input) => Console.WriteLine(input.j());

		public static void d<T>(T input) => Console.Write(input);
		public static void D<T>(IEnumerable<T> input) => Console.Write(input.j());


	}
}
