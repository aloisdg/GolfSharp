using System;
using System.Collections.Generic;

namespace GolfSharp
{
	public static partial class MainClass
	{
		/* Output functions */
		public static void c<T>(T input) => Console.WriteLine(input);
		public static void C<T>(IEnumerable<T> input) => Console.WriteLine(input.j());

		public static void d<T>(T input) => Console.Write(input);
		public static void D<T>(IEnumerable<T> input) => Console.Write(input.j());

	}
}
