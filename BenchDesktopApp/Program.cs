using System;
using BenchCommonLib;

namespace BenchDesktopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Benchmarker
            {
                Writer = Console.Out,
                //Filter = "ManagedVsInterop"
            };  
            b.RunAllBenchmarkstoWriter(new Benchmarks(b));
        }
    }
}
