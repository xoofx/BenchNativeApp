# BenchNativeApp

Small suite of micro benchmarks to test .NET Native and RyuJIT. See full article: ["Micro-Benchmarking .NET Native and RyuJit"](http://code4k.blogspot.com/2014/06/micro-benchmarking-net-native-and-ryujit.html)

This small suite is composed of:

- "[Head-to-head benchmark: C++ vs .NET](http://www.codeproject.com/Articles/212856/Head-to-head-benchmark-Csharp-vs-NET)" by Qwertie has a nice collection of micro-benchmarks
- "[A Collection of Phoenix-Compatible C# Benchmarks](http://www.cs.ucsb.edu/~ckrintz/racelab/PhxCSBenchmarks/)" I used the port of a subset of Java Grande benchmarks. 
- Two custom benchmarks measuring the cost of interop which is important in cases where you can possibly call lots of native methods (which is the case when using SharpDX for example)

## License

See respective license in source code. The code provided here is provided "as is", without warranty of any kind


