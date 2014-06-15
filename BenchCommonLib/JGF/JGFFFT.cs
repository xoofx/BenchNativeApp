/**************************************************************************
*                                                                         *
*             Java Grande Forum Benchmark Suite - Version 2.0             *
*                                                                         *
*                            produced by                                  *
*                                                                         *
*                  Java Grande Benchmarking Project                       *
*                                                                         *
*                                at                                       *
*                                                                         *
*                Edinburgh Parallel Computing Centre                      *
*                                                                         *
*                email: epcc-javagrande@epcc.ed.ac.uk                     *
*                                                                         *
*      adapted from SciMark 2.0, author Roldan Pozo (pozo@cam.nist.gov)   *
*             see below for previous history of this code                 *
*                                                                         *
*      This version copyright (c) The University of Edinburgh, 1999.      *
*                         All rights reserved.                            *
*                                                                         *
**************************************************************************/

using System;

namespace fft
{

/** Computes FFT's of complex, double precision data where n is an integer power of 2.
  * This appears to be slower than the Radix2 method,
  * but the code is smaller and simpler, and it requires no extra storage.
  * 
  *
  * @author Bruce R. Miller bruce.miller@nist.gov,
  * @author Derived from GSL (Gnu Scientific Library), 
  * @author GSL's FFT Code by Brian Gough bjg@vvv.lanl.gov
  */

    /* See {@link ComplexDoubleFFT ComplexDoubleFFT} for details of data layout.
   */

    public class FFT
    {

        public static double JDKtotal = 0.0;
        public static double JDKtotali = 0.0;

        /** Compute Fast Fourier Transform of (complex) data, in place.*/
        public static void transform(double[] data)
        {
            int JDKrange;

            ////JGFInstrumentor.startTimer("Section2:FFT:Kernel");

            transform_internal(data, -1);

            ////JGFInstrumentor.stopTimer("Section2:FFT:Kernel");

            JDKrange = data.Length;
            for (int i = 0; i < JDKrange; i++)
            {
                JDKtotal += data[i];
            }

        }

        /** Compute Inverse Fast Fourier Transform of (complex) data, in place.*/
        public static void inverse(double[] data)
        {

            ////JGFInstrumentor.startTimer("Section2:FFT:Kernel");

            transform_internal(data, +1);
            // Normalize
            int nd = data.Length;
            int n = nd / 2;
            double norm = 1 / ((double)n);
            for (int i = 0; i < nd; i++)
                data[i] *= norm;

            ////JGFInstrumentor.stopTimer("Section2:FFT:Kernel");

            for (int i = 0; i < nd; i++)
            {
                JDKtotali += data[i];
            }

        }

        /** Accuracy check on FFT of data. Make a copy of data, Compute the FFT, then
    * the inverse and compare to the original.  Returns the rms difference.*/
        public static double test(double[] data)
        {
            int nd = data.Length;
            // Make duplicate for comparison
            double[] copy = new double[nd];
            Array.Copy(data, 0, copy, 0, nd);
            // Transform & invert
            transform(data);
            inverse(data);
            // Compute RMS difference.
            double diff = 0.0;
            for (int i = 0; i < nd; i++)
            {
                double d = data[i] - copy[i];
                diff += d * d;
            }
            return Math.Sqrt(diff / nd);
        }

        /** Make a random array of n (complex) elements. */
        public static double[] makeRandom(int n)
        {
            Random rand = new Random();
            int nd = 2 * n;
            double[] data = new double[nd];
            for (int i = 0; i < nd; i++)
                data[i] = rand.NextDouble();
            return data;
        }

        /** Simple Test routine. */
        /*
        public static void main(String[] args)
        {
            if (args.Length == 0)
            {
                int n = 1024;
                Console.WriteLine("n=" + n + " => RMS Error=" + test(makeRandom(n)));
            }
            for (int i = 0; i < args.Length; i++)
            {
                int n = Integer.parseInt(args[i]);
                Console.WriteLine("n=" + n + " => RMS Error=" + test(makeRandom(n)));
            }
        }*/

        /* ______________________________________________________________________ */

        protected static int log2(int n)
        {
            int log = 0;
            for (int k = 1; k < n; k *= 2, log++) ;
            if (n != (1 << log))
                System.Diagnostics.Debug.WriteLine("FFT: Data Length is not a power of 2!: " + n);
            return log;
        }

        protected static void transform_internal(double[] data, int direction)
        {
            int n = data.Length / 2;
            if (n == 1) return;		// Identity operation!
            int logn = log2(n);

            /* bit reverse the input data for decimation in time algorithm */
            bitreverse(data);

            /* apply fft recursion */
            for (int bit = 0, dual = 1; bit < logn; bit++, dual *= 2)
            {
                double w_real = 1.0;
                double w_imag = 0.0;

                double theta = 2.0 * direction * Math.PI / (2.0 * (double)dual);
                double s = Math.Sin(theta);
                double t = Math.Sin(theta / 2.0);
                double s2 = 2.0 * t * t;

                /* a = 0 */
                for (int b = 0; b < n; b += 2 * dual)
                {
                    int i = 2 * b;
                    int j = 2 * (b + dual);

                    double wd_real = data[j];
                    double wd_imag = data[j + 1];

                    data[j] = data[i] - wd_real;
                    data[j + 1] = data[i + 1] - wd_imag;
                    data[i] += wd_real;
                    data[i + 1] += wd_imag;
                }

                /* a = 1 .. (dual-1) */
                for (int a = 1; a < dual; a++)
                {
                    /* trignometric recurrence for w-> exp(i theta) w */
                    {
                        double tmp_real = w_real - s * w_imag - s2 * w_real;
                        double tmp_imag = w_imag + s * w_real - s2 * w_imag;
                        w_real = tmp_real;
                        w_imag = tmp_imag;
                    }
                    for (int b = 0; b < n; b += 2 * dual)
                    {
                        int i = 2 * (b + a);
                        int j = 2 * (b + a + dual);

                        double z1_real = data[j];
                        double z1_imag = data[j + 1];

                        double wd_real = w_real * z1_real - w_imag * z1_imag;
                        double wd_imag = w_real * z1_imag + w_imag * z1_real;

                        data[j] = data[i] - wd_real;
                        data[j + 1] = data[i + 1] - wd_imag;
                        data[i] += wd_real;
                        data[i + 1] += wd_imag;
                    }
                }
            }
        }


        protected static void bitreverse(double[] data)
        {
            /* This is the Goldrader bit-reversal algorithm */
            int n = data.Length / 2;
            for (int i = 0, j = 0; i < n - 1; i++)
            {
                int ii = 2 * i;
                int jj = 2 * j;
                int k = n / 2;
                if (i < j)
                {
                    double tmp_real = data[ii];
                    double tmp_imag = data[ii + 1];
                    data[ii] = data[jj];
                    data[ii + 1] = data[jj + 1];
                    data[jj] = tmp_real;
                    data[jj + 1] = tmp_imag;
                }

                while (k <= j)
                {
                    j = j - k;
                    k = k / 2;
                }
                j += k;
            }
        }
    }

    public class JGFFFTBench : FFT
    {

        private int size;
        private int[] datasizes ={ 2097152, 8388608, 16777216 };


        //private static int RANDOM_SEED = 10101010;
        //Random R = new Random(RANDOM_SEED);

        Random R = new Random();

        public void JGFsetsize(int size)
        {
            this.size = size;
        }

        public void JGFinitialise()
        {

        }

        public void JGFkernel()
        {

            double[] x = RandomVector(2 * (datasizes[size]), R);

            FFT.transform(x);
            FFT.inverse(x);

        }

        public void JGFvalidate()
        {

            double[] refval = { 1.726962988395339, 6.907851953579193, 13.815703907167297 };
            double[] refvali = { 2.0974756152524314, 8.389142211032294, 16.778094422092604 };
            double dev = Math.Abs(JDKtotal - refval[size]);
            double devi = Math.Abs(JDKtotali - refvali[size]);
            if (dev > 1.0e-12)
            {
                System.Diagnostics.Debug.WriteLine("Validation failed");
                System.Diagnostics.Debug.WriteLine("JDKtotal = " + JDKtotal + "  " + dev + "  " + size);
            }
            if (devi > 1.0e-12)
            {
                System.Diagnostics.Debug.WriteLine("Validation failed");
                System.Diagnostics.Debug.WriteLine("JDKtotalinverse = " + JDKtotali + "  " + dev + "  " + size);
            }



        }

        public void JGFtidyup()
        {
            System.GC.Collect();
        }



        public void JGFrun(int size)
        {


            //JGFInstrumentor.addTimer("Section2:FFT:Kernel", "Samples",size);

            JGFsetsize(size);
            JGFinitialise();
            JGFkernel();
            JGFvalidate();
            JGFtidyup();


            //JGFInstrumentor.addOpsToTimer("Section2:FFT:Kernel", (double) (datasizes[size]));

            //JGFInstrumentor.printTimer("Section2:FFT:Kernel"); 
        }

        private static double[] RandomVector(int N, System.Random R)
        {
            double[] A = new double[N];

            for (int i = 0; i < N; i++)
                A[i] = R.NextDouble() * 1e-6;

            return A;
        }


        public static void Run()
        {
            JGFFFTBench fft = new JGFFFTBench();
            fft.JGFrun(0);

            //fft.JGFrun(1);
        }
    }
}