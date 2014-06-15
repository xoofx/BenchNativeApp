using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace BenchCommonLib
{
    public partial class Benchmarks
    {
        private const int CountManagedAdd = 5000000;
        public static int value = 0;

        [Benchmark("19-float4x4 matrix mul, Managed Standard", 8)]
        public void RunMatrixMulManagedStandard()
        {
            BenchMatrix.RunManagedStd();
        }

        [Benchmark("20-float4x4 matrix mul, Managed unsafe", 8)]
        public void RunMatrixMulManagedUnsafe()
        {
            BenchMatrix.RunManagedUnsafe();
        }

        [Benchmark("21-float4x4 matrix mul, Interop Standard", 8)]
        public void RunMatrixMulInteropStandard()
        {
            BenchMatrix.RunInteropStd();
        }

        [Benchmark("22-float4x4 matrix mul, Interop SSE2", 8)]
        public void RunMatrix()
        {
            BenchMatrix.RunInteropSSE2();
        }

        [Benchmark("23-managed add", 8)]
        public static int RunManagedAdd()
        {
            value = 0;
            for (int i = 0; i < CountManagedAdd; i++)
            {
                value = ManagedAdd(value, 1);
                value = ManagedAdd(value, 2);
                value = ManagedAdd(value, -3);
                value = ManagedAdd(value, 1);
                value = ManagedAdd(value, 2);

                value = ManagedAdd(value, -3);
                value = ManagedAdd(value, 1);
                value = ManagedAdd(value, 2);
                value = ManagedAdd(value, -3);
                value = ManagedAdd(value, 1);
            }
            return value;
        }

        [Benchmark("24-managed no-inline add", 8)]
        public static int RunManagedNoInlineAdd()
        {
            value = 0;
            for (int i = 0; i < CountManagedAdd; i++)
            {
                value = ManagedNoInlineAdd(value, 1);
                value = ManagedNoInlineAdd(value, 2);
                value = ManagedNoInlineAdd(value, -3);
                value = ManagedNoInlineAdd(value, 1);
                value = ManagedNoInlineAdd(value, 2);

                value = ManagedNoInlineAdd(value, -3);
                value = ManagedNoInlineAdd(value, 1);
                value = ManagedNoInlineAdd(value, 2);
                value = ManagedNoInlineAdd(value, -3);
                value = ManagedNoInlineAdd(value, 1);
            }
            return value;
        }

        [Benchmark("25-interop add", 8)]
        public static int RunInteropAdd()
        {
            value = 0;
            for (int i = 0; i < CountManagedAdd; i++)
            {
                value = NativeAdd(value, 1);
                value = NativeAdd(value, 2);
                value = NativeAdd(value, -3);
                value = NativeAdd(value, 1);
                value = NativeAdd(value, 2);

                value = NativeAdd(value, -3);
                value = NativeAdd(value, 1);
                value = NativeAdd(value, 2);
                value = NativeAdd(value, -3);
                value = NativeAdd(value, 1);
            }
            return value;
        }

        [Benchmark("26-interop indirect add", 8)]
        public static int RunInteropIndirectAdd()
        {
            value = 0;
            for (int i = 0; i < CountManagedAdd; i++)
            {
                value = NativeIndirectAdd(value, 1);
                value = NativeIndirectAdd(value, 2);
                value = NativeIndirectAdd(value, -3);
                value = NativeIndirectAdd(value, 1);
                value = NativeIndirectAdd(value, 2);

                value = NativeIndirectAdd(value, -3);
                value = NativeIndirectAdd(value, 1);
                value = NativeIndirectAdd(value, 2);
                value = NativeIndirectAdd(value, -3);
                value = NativeIndirectAdd(value, 1);
            }

            return value;
        }

        private static int ManagedAdd(int x, int y)
        {
            return x + y;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ManagedNoInlineAdd(int x, int y)
        {
            return x + y;
        }

        private static int NativeIndirectAdd(int x, int y)
        {
            return NativeAdd(x, y);
        }

        [DllImport("InteropLib", EntryPoint = "InteropAdd", CallingConvention = CallingConvention.StdCall)]
        [SuppressUnmanagedCodeSecurity]
#if WINDOWS_DESKTOP
#endif
        private static extern int NativeAdd(int x, int y);
    }
}

namespace System.Security
{

    [AttributeUsageAttribute(
        AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate,
        AllowMultiple = true,
        Inherited = false)]
    [ComVisibleAttribute(true)]
    public sealed class SuppressUnmanagedCodeSecurityAttribute : Attribute
    {

    }
}