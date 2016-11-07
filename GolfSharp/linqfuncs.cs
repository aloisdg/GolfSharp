using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GolfSharp
{
	public static partial class MainClass
	{

		/* LINQ functions */

		//to array
		public static TSource[] a<TSource>(this IEnumerable<TSource> input) => input.ToArray();
		//to list
		public static List<TSource> l<TSource>(this IEnumerable<TSource> input) => input.ToList();
		//select
		public static IEnumerable<TResult> s<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, TResult> predicate) => input.Select(predicate);
		public static IEnumerable<TResult> s<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, int, TResult> predicate) => input.Select(predicate);
		//where
		public static IEnumerable<TSource> w<TSource>(this IEnumerable<TSource> input, Func<TSource, Boolean> predicate) => input.Where(predicate);
		public static IEnumerable<TSource> w<TSource>(this IEnumerable<TSource> input, Func<TSource, int, Boolean> predicate) => input.Where(predicate);
		//selectmany
		public static IEnumerable<TResult> m<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource, IEnumerable<TResult>> predicate) => input.SelectMany(predicate);
		//take
		public static IEnumerable<TSource> t<TSource>(this IEnumerable<TSource> input, int count) => input.Take(count);
		//takewhile
		public static IEnumerable<TSource> q<TSource>(this IEnumerable<TSource> input, Func<TSource, Boolean> predicate) => input.TakeWhile(predicate);
		//skip
		public static IEnumerable<TSource> k<TSource>(this IEnumerable<TSource> input, int count) => input.Skip(count);
		//skipwhile
		public static IEnumerable<TSource> Q<TSource>(this IEnumerable<TSource> input, Func<TSource, Boolean> predicate) => input.SkipWhile(predicate);
		//range
		public static IEnumerable<int> r(int start, int count) => Enumerable.Range(start, count);
		//foreach
		public static void f<TSource>(IEnumerable<TSource> input, Action<TSource> predicate) => input.ToList().ForEach(predicate);
		//count
		public static int L<TSource>(this IEnumerable<TSource> input) => input.Count();
		//split array by length
		public static TSource[][] S<TSource>(this IEnumerable<TSource> input, int size)
		{
			List<List<TSource>> temp = new List<List<TSource>>();
			do
			{
				int take = Math.Min(size, input.Count());
				temp.Add(input.Take(take).ToList());
				input = input.Skip(take);
			}
			while (input.Count() != 0);
			return temp.Select(n => n.ToArray()).ToArray();
		}
		//split string by length
		public static string[] S(this string input, int size) => S(input.ToCharArray(), size).Select(o).ToArray();
		//get array before and after
		public static IEnumerable<TSource> x<TSource>(this IEnumerable<TSource> input, int start, int end) => input.Take(start).Concat(input.Skip(end));
		//get string before and after
		public static string x(this string input, int start, int end) => x(input.ToArray(), start, end).o();
		//short regex
		public static string[][] r(this string input, string expression, int groupnum) => new Regex(expression).Matches(input).Cast<Match>().Select(n => n.Groups.Cast<Group>().Select(m => m.Value).ToArray()).ToArray();
		//flip array NOT COMPLETED
		public static TSource[][] f<TSource>(this TSource[][] input, int flip)
		{
			//rotates right
			flip = flip % 4;
			if (flip == 0)
				return input;
			if (flip == 1)
			{
				TSource[][] temp = new TSource[input[0].Length][].Select(n => new TSource[input.Length]).ToArray();
				for (int i = 0; i < input[0].Length; i++)
				{
					for (int j = 0; j < input.Length; j++)
					{
						temp[i][j] = input[j][i];
					}
					temp[i] = temp[i].Reverse().ToArray();
				}
				return temp;
			}
			/*
			if (flip == 2)
			{
				TSource[][] temp = new TSource[input.Length][].Select(n => new TSource[input[0].Length]).ToArray();
				for (int i = 0; i < input.Length; i++)
				{
					temp[i] = temp[i].Reverse().ToArray();

				}
				return temp;
			}
			*/
			return null;
		}
		//concat
		public static IEnumerable<TSource> T<TSource>(this IEnumerable<TSource> ie1, IEnumerable<TSource> ie2) => ie1.Concat(ie2);
		//move right
		public static IEnumerable<TSource> P<TSource>(this IEnumerable<TSource> input, int count) => input.Skip(input.Count() - count % input.Count()).Concat(input.Take(input.Count() - count % input.Count()));
		//move left
		public static IEnumerable<TSource> p<TSource>(this IEnumerable<TSource> input, int count) => input.Skip(count % input.Count()).Concat(input.Take(count % input.Count()));
		//contains
		public static bool I<TSource>(this IEnumerable<TSource> input, TSource elem) => input.Contains(elem);
		public static bool I(this string input, object elem) => input.Contains(elem.ToString());
		//elementAt
		public static TSource A<TSource>(this IEnumerable<TSource> input, int index) => input.ElementAt(index);
		//indexOf
		public static int O<TSource>(this IEnumerable<TSource> input, TSource elem) => input.ToList().IndexOf(elem);
	}
}
