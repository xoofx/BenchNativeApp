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
*                                                                         *
*      This version copyright (c) The University of Edinburgh, 1999.      *
*                         All rights reserved.                            *
*                                                                         *
**************************************************************************/

using System;

namespace sparsematmult
{


    public class SparseMatmult
    {

        public static double ytotal = 0.0;

        /* 10 iterations used to make kernel have roughly
		same granulairty as other Scimark kernels. */

        public static void test(double[] y, double[] val, int[] row,
                    int[] col, double[] x, int NUM_ITERATIONS)
        {
            int nz = val.Length;

            //JGFInstrumentor.startTimer("Section2:SparseMatmult:Kernel"); 

            for (int reps = 0; reps < NUM_ITERATIONS; reps++)
            {
                for (int i = 0; i < nz; i++)
                {
                    y[row[i]] += x[col[i]] * val[i];
                }
            }

            //JGFInstrumentor.stopTimer("Section2:SparseMatmult:Kernel"); 


            for (int i = 0; i < nz; i++)
            {
                ytotal += y[row[i]];
            }

        }
    }

    public class JGFSparseMatmultBench : SparseMatmult
    {

        private int size;

        private static int[] datasizes_M = { 50000, 100000, 500000 };
        private static int[] datasizes_N = { 50000, 100000, 500000 };
        private static int[] datasizes_nz = { 250000, 500000, 2500000 };
        private static int SPARSE_NUM_ITER = 200;

        Random R;

        double[] x;
        double[] y;
        double[] val;
        int[] col;
        int[] row;

        public void JGFsetsize(int size)
        {
            this.size = size;

        }

        public void JGFinitialise()
        {
            R = new Random(1010);

            x = RandomVector(datasizes_N[size], R);
            y = new double[datasizes_M[size]];

            val = new double[datasizes_nz[size]];
            col = new int[datasizes_nz[size]];
            row = new int[datasizes_nz[size]];

            for (int i = 0; i < datasizes_nz[size]; i++)
            {

                // generate random row index (0, M-1)
                row[i] = Math.Abs(R.Next()) % datasizes_M[size];

                // generate random column index (0, N-1)
                col[i] = Math.Abs(R.Next()) % datasizes_N[size];

                val[i] = R.NextDouble();

            }

        }

        public void JGFkernel()
        {

            SparseMatmult.test(y, val, row, col, x, SPARSE_NUM_ITER);

        }

        public void JGFvalidate()
        {

            double[] refval = { 75.02484945753453, 150.0130719633895, 749.5245870753752 };
            double dev = Math.Abs(ytotal - refval[size]);
            if (dev > 1.0e-12)
            {
                System.Diagnostics.Debug.WriteLine("Validation failed");
                System.Diagnostics.Debug.WriteLine("ytotal = " + ytotal + "  " + dev + "  " + size);
            }

        }

        public void JGFtidyup()
        {
            System.GC.Collect();
        }



        public void JGFrun(int size)
        {


            //JGFInstrumentor.addTimer("Section2:SparseMatmult:Kernel", "Iterations",size);

            JGFsetsize(size);
            JGFinitialise();
            JGFkernel();
            JGFvalidate();
            JGFtidyup();


            //JGFInstrumentor.addOpsToTimer("Section2:SparseMatmult:Kernel", (double) (SPARSE_NUM_ITER));

            //JGFInstrumentor.printTimer("Section2:SparseMatmult:Kernel"); 
        }

        private static double[] RandomVector(int N, Random R)
        {
            double[] A = new double[N];

            for (int i = 0; i < N; i++)
                A[i] = R.NextDouble() * 1e-6;

            return A;
        }


        public static void Run()
        {

            //JGFInstrumentor.printHeader(2,0);

            JGFSparseMatmultBench smm = new JGFSparseMatmultBench();
            smm.JGFrun(1);

        }

    }

}
