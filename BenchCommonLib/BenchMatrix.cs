using System;
using System.Runtime.InteropServices;

namespace BenchCommonLib
{
    public unsafe class BenchMatrix
    {
        private static int MAX_CALL = 3000000;
        private static float[] m1 = new float[16];
        private static float[] m2 = new float[16];
        private static float[] m3 = new float[16];
        private static float[] om1 = new float[16];
        private static float* pm1;
        private static float* pm2;
        private static float* pm3;

        /// <summary>
        /// Matrixes the mul managed standard.
        /// </summary>
        private static void MatrixMulManagedStd(float[] m1, float[] m2, float[] o)
        {
            o[0] = m1[0] * m2[0] + m1[1] * m2[4] + m1[2] * m2[8] + m1[3] * m2[12];
            o[1] = m1[0] * m2[1] + m1[1] * m2[5] + m1[2] * m2[9] + m1[3] * m2[13];
            o[2] = m1[0] * m2[2] + m1[1] * m2[6] + m1[2] * m2[10] + m1[3] * m2[14];
            o[3] = m1[0] * m2[3] + m1[1] * m2[7] + m1[2] * m2[11] + m1[3] * m2[15];

            o[4] = m1[4] * m2[0] + m1[5] * m2[4] + m1[6] * m2[8] + m1[7] * m2[12];
            o[5] = m1[4] * m2[1] + m1[5] * m2[5] + m1[6] * m2[9] + m1[7] * m2[13];
            o[6] = m1[4] * m2[2] + m1[5] * m2[6] + m1[6] * m2[10] + m1[7] * m2[14];
            o[7] = m1[4] * m2[3] + m1[5] * m2[7] + m1[6] * m2[11] + m1[7] * m2[15];

            o[8] = m1[8] * m2[0] + m1[9] * m2[4] + m1[10] * m2[8] + m1[11] * m2[12];
            o[9] = m1[8] * m2[1] + m1[9] * m2[5] + m1[10] * m2[9] + m1[11] * m2[13];
            o[10] = m1[8] * m2[2] + m1[9] * m2[6] + m1[10] * m2[10] + m1[11] * m2[14];
            o[11] = m1[8] * m2[3] + m1[9] * m2[7] + m1[10] * m2[11] + m1[11] * m2[15];

            o[12] = m1[12] * m2[0] + m1[13] * m2[4] + m1[14] * m2[8] + m1[15] * m2[12];
            o[13] = m1[12] * m2[1] + m1[13] * m2[5] + m1[14] * m2[9] + m1[15] * m2[13];
            o[14] = m1[12] * m2[2] + m1[13] * m2[6] + m1[14] * m2[10] + m1[15] * m2[14];
            o[15] = m1[12] * m2[3] + m1[13] * m2[7] + m1[14] * m2[11] + m1[15] * m2[15];
        }

        /// <summary>
        /// Matrixes the mul managed unsafe.
        /// </summary>
        private static void MatrixMulManagedUnsafe(float* m1, float* m2, float* o)
        {
            o[0] = m1[0] * m2[0] + m1[1] * m2[4] + m1[2] * m2[8] + m1[3] * m2[12];
            o[1] = m1[0] * m2[1] + m1[1] * m2[5] + m1[2] * m2[9] + m1[3] * m2[13];
            o[2] = m1[0] * m2[2] + m1[1] * m2[6] + m1[2] * m2[10] + m1[3] * m2[14];
            o[3] = m1[0] * m2[3] + m1[1] * m2[7] + m1[2] * m2[11] + m1[3] * m2[15];

            o[4] = m1[4] * m2[0] + m1[5] * m2[4] + m1[6] * m2[8] + m1[7] * m2[12];
            o[5] = m1[4] * m2[1] + m1[5] * m2[5] + m1[6] * m2[9] + m1[7] * m2[13];
            o[6] = m1[4] * m2[2] + m1[5] * m2[6] + m1[6] * m2[10] + m1[7] * m2[14];
            o[7] = m1[4] * m2[3] + m1[5] * m2[7] + m1[6] * m2[11] + m1[7] * m2[15];

            o[8] = m1[8] * m2[0] + m1[9] * m2[4] + m1[10] * m2[8] + m1[11] * m2[12];
            o[9] = m1[8] * m2[1] + m1[9] * m2[5] + m1[10] * m2[9] + m1[11] * m2[13];
            o[10] = m1[8] * m2[2] + m1[9] * m2[6] + m1[10] * m2[10] + m1[11] * m2[14];
            o[11] = m1[8] * m2[3] + m1[9] * m2[7] + m1[10] * m2[11] + m1[11] * m2[15];

            o[12] = m1[12] * m2[0] + m1[13] * m2[4] + m1[14] * m2[8] + m1[15] * m2[12];
            o[13] = m1[12] * m2[1] + m1[13] * m2[5] + m1[14] * m2[9] + m1[15] * m2[13];
            o[14] = m1[12] * m2[2] + m1[13] * m2[6] + m1[14] * m2[10] + m1[15] * m2[14];
            o[15] = m1[12] * m2[3] + m1[13] * m2[7] + m1[14] * m2[11] + m1[15] * m2[15];
        }

        /// <summary>
        /// Matrixes Mul using interop SSE2.
        /// </summary>
        [DllImport("InteropLib.dll", CallingConvention = CallingConvention.StdCall,
            EntryPoint = "InteropMatrixMulSSE2")]
#if WINDOWS_DESKTOP
        [SuppressUnmanagedCodeSecurity]
#endif
        private static extern void MatrixMulInteropSSE2(float* m1, float* m2, float* o);

        /// <summary>
        /// Matrixes Mul using interop Std.
        /// </summary>
        [DllImport("InteropLib.dll", CallingConvention = CallingConvention.StdCall,
        EntryPoint = "InteropMatrixMul")]
#if WINDOWS_DESKTOP
        [SuppressUnmanagedCodeSecurity]
#endif
        private static extern void MatrixMulInteropStd(float* m1, float* m2, float* o);

        public static void RunInteropSSE2()
        {
            fixed (float* pm1F = &m1[0], pm2F = &m2[0], pm3F = &m3[0])
            {
                pm1 = pm1F;
                pm2 = pm2F;
                pm3 = pm3F;
                Array.Copy(om1, m1, 16);
                for (int i = 0; i < MAX_CALL; i++)
                {
                    MatrixMulInteropSSE2(pm1, pm2, pm3);
                    MatrixMulInteropSSE2(pm3, pm2, pm1);
                    MatrixMulInteropSSE2(pm1, pm2, pm3);
                    MatrixMulInteropSSE2(pm3, pm2, pm1);
                    MatrixMulInteropSSE2(pm1, pm2, pm3);
                    MatrixMulInteropSSE2(pm3, pm2, pm1);
                    MatrixMulInteropSSE2(pm1, pm2, pm3);
                    MatrixMulInteropSSE2(pm3, pm2, pm1);
                    MatrixMulInteropSSE2(pm1, pm2, pm3);
                    MatrixMulInteropSSE2(pm3, pm2, pm1);
                    Array.Copy(om1, m1, 16);
                }
            }
        }

        public static void RunInteropStd()
        {
            fixed (float* pm1F = &m1[0], pm2F = &m2[0], pm3F = &m3[0])
            {
                pm1 = pm1F;
                pm2 = pm2F;
                pm3 = pm3F;
                Array.Copy(om1, m1, 16);
                for (int i = 0; i < MAX_CALL; i++)
                {
                    MatrixMulInteropStd(pm1, pm2, pm3);
                    MatrixMulInteropStd(pm3, pm2, pm1);
                    MatrixMulInteropStd(pm1, pm2, pm3);
                    MatrixMulInteropStd(pm3, pm2, pm1);
                    MatrixMulInteropStd(pm1, pm2, pm3);
                    MatrixMulInteropStd(pm3, pm2, pm1);
                    MatrixMulInteropStd(pm1, pm2, pm3);
                    MatrixMulInteropStd(pm3, pm2, pm1);
                    MatrixMulInteropStd(pm1, pm2, pm3);
                    MatrixMulInteropStd(pm3, pm2, pm1);
                    Array.Copy(om1, m1, 16);
                }
            }
        }

        public static void RunManagedStd()
        {
            Array.Copy(om1, m1, 16);
            for (int i = 0; i < MAX_CALL; i++)
            {
                MatrixMulManagedStd(m1, m2, m3);
                MatrixMulManagedStd(m3, m2, m1);
                MatrixMulManagedStd(m1, m2, m3);
                MatrixMulManagedStd(m3, m2, m1);
                MatrixMulManagedStd(m1, m2, m3);
                MatrixMulManagedStd(m3, m2, m1);
                MatrixMulManagedStd(m1, m2, m3);
                MatrixMulManagedStd(m3, m2, m1);
                MatrixMulManagedStd(m1, m2, m3);
                MatrixMulManagedStd(m3, m2, m1);
                Array.Copy(om1, m1, 16);
            }
        }

        public static void RunManagedUnsafe()
        {
            fixed (float* pm1F = &m1[0], pm2F = &m2[0], pm3F = &m3[0])
            {
                pm1 = pm1F;
                pm2 = pm2F;
                pm3 = pm3F;
                Array.Copy(om1, m1, 16);
                for (int i = 0; i < MAX_CALL; i++)
                {
                    MatrixMulManagedUnsafe(pm1, pm2, pm3);
                    MatrixMulManagedUnsafe(pm3, pm2, pm1);
                    MatrixMulManagedUnsafe(pm1, pm2, pm3);
                    MatrixMulManagedUnsafe(pm3, pm2, pm1);
                    MatrixMulManagedUnsafe(pm1, pm2, pm3);
                    MatrixMulManagedUnsafe(pm3, pm2, pm1);
                    MatrixMulManagedUnsafe(pm1, pm2, pm3);
                    MatrixMulManagedUnsafe(pm3, pm2, pm1);
                    MatrixMulManagedUnsafe(pm1, pm2, pm3);
                    MatrixMulManagedUnsafe(pm3, pm2, pm1);
                    Array.Copy(om1, m1, 16);
                }
            }
        }

        static BenchMatrix()
        {
            var random = new Random();
            for (int i = 0; i < 16; i++)
            {
                m1[i] = (float)random.NextDouble();
                om1[i] = m1[i];
                m2[i] = (float)random.NextDouble();
                m3[i] = 0.0f;
            }
        }
    }
}