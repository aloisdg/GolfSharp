using System;
using i = System.Int32;
using l = System.Int64;
using f = System.Single;
using s = System.String;
using c = System.Char;
using System.Collections.Generic;
using System.Linq;

namespace GolfSharp
{
	static class MainClass
	{
		public static void Main(string[] args)
		{
			/* put your code here */
		}

		/* String functions */
		public static String t(this object input) => input.ToString();
		public static String j<TSource>(this IEnumerable<TSource> input, string seperator) => String.Join(seperator, input.s(n => n.t()));
		public static String j<TSource>(this IEnumerable<TSource> input) => String.Join("", input.s(n => n.t()));


		/* LINQ functions */
		public static TSource[] a<TSource>(this IEnumerable<TSource> input) => input.ToArray();
		public static List<TSource> l<TSource>(this IEnumerable<TSource> input) => input.ToList();
		public static IEnumerable<TResult> s<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, TResult> predicate) => input.Select(predicate);
		public static IEnumerable<TSource> w<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, bool> predicate) => input.Where(predicate);
		public static IEnumerable<TResult> m<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, IEnumerable<TResult>> predicate) => input.SelectMany(predicate);
		public static IEnumerable<int> r(int start, int count) => Enumerable.Range(start, count);
		public static void f<TSource>(IEnumerable<TSource> input, Action<TSource> predicate) => input.l().ForEach(predicate);

		/* Output functions */
		public static void c<T>(T input) => Console.WriteLine(input);
		public static void C<T>(IEnumerable<T> input) => Console.WriteLine(input.j());

		public static void d<T>(T input) => Console.Write(input);
		public static void D<T>(IEnumerable<T> input) => Console.Write(input.j());





	}
}
