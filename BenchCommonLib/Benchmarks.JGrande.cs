using CSGrande;
using fft;
using heapsort;
using raytracer2;

namespace BenchCommonLib
{
    public partial class Benchmarks
    {
        [Benchmark("11-JGFArithBench", 8)]
        public void RunJGFArithBench() { JGFArithBench.Run(); }
        [Benchmark("12-JGFAssignBench", 8)]
        public void RunJGFAssignBench() { JGFAssignBench.Run(); }
        [Benchmark("13-JGFCastBench", 8)]
        public void RunJGFCastBench() { JGFCastBench.Run(); }
        [Benchmark("14-JGFCreateBench", 8)]
        public void RunJGFCreateBench() { JGFCreateBench.Run(); }
        [Benchmark("15-JGFFFTBench", 8)]
        public void RunJGFFFTBench() { JGFFFTBench.Run(); }
        [Benchmark("16-JGFHeapSortBench", 8)]
        public void RunJGFHeapSortBench() { JGFHeapSortBench.Run(); }
        [Benchmark("17-JGFLoopBench", 8)]
        public void RunJGFLoopBench() { JGFLoopBench.Run(); }
        [Benchmark("18-JGFRayTracerBench", 8)]
        public void runJGFRayTracerBench() { JGFRayTracerBench.Run(); }
   }
}