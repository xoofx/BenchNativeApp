using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Benchmark
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("C# Benchmarks running...");
			#if DEBUG
			Console.WriteLine("DEBUG BUILD!");
			#endif

			Benchmarker b = new Benchmarker();
			b.RunAllBenchmarksInConsole(new Benchmarks(b), true);

			Console.WriteLine();
			string filename = Path.Combine(HomePath, "ResultsC#.csv");
			Console.WriteLine("Writing results to {0}.", filename);
			
			using (var file = File.OpenWrite(filename))
			using (var writer = new StreamWriter(file))
				b.PrintResults(writer, ",", true, null);
			
			Console.Write("Press Enter to quit.");
			Console.ReadLine();
		}

		static string _homePath;
		public static string HomePath
		{
			get {
				if (_homePath == null) {
					string p = Assembly.GetExecutingAssembly().GetName().CodeBase;
					if (p.StartsWith("file:///"))
						p = p.Substring("file:///".Length);
					_homePath = Path.GetDirectoryName(p);
				}
				return _homePath;
			}
		}
	}
}
