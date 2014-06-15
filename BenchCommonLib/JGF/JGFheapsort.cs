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
*                  Original version of this code by                       *
*                 Gabriel Zachmann (zach@igd.fhg.de)                      *
*                                                                         *
*      This version copyright (c) The University of Edinburgh, 1999.      *
*                         All rights reserved.                            *
*                                                                         *
**************************************************************************/

/**
* Class NumericSortTest
*
* Performs the numeric sort test for the Java BYTEmark
* benchmark suite. This test implements a heapsort
* algorithm, performed on an int array. Results are
* reported in number of iterations per sec.
*/
using System;

namespace heapsort
{

    public class NumericSortTest
    {

        public int array_rows;
        public int[] TestArray; 

// The test sorts an array of pseudo-random 32-bit
// integers. 


/*
* buildTestData
*
* Instantiates array and fills first it with random
* 32-bit integers.
*/

        public void buildTestData()
        {

            TestArray = new int[array_rows];


            Random rndnum = new Random(1729);     // Same seed every time.

            // Fill first TestArray with pseudo-random values.

            for (int i = 0; i < array_rows; i++)
                TestArray[i] = rndnum.Next();

        }

/*
* Do
*
* Perform an iteration of the numeric sort benchmark. Returns
* the elapsed time in milliseconds.
*/
        public void Do()
        {

            // Start the stopwatch.
            //JGFInstrumentor.startTimer("Section2:HeapSort:Kernel"); 

            NumHeapSort();

            // Stop the stopwatch. 
            //JGFInstrumentor.stopTimer("Section2:HeapSort:Kernel");
        }

/*
* NumSift
*
* Performs the sift operation on a numeric array,
* constructing a heap in the array.
* Instructions from strsift:
* Pass this function:
*  1. The string array # being sorted
*  2. Offsets within which to sort
* This performs the core sort of the Heapsort algorithm
*/

        private void NumSift(int min, int max)     // Sort range offsets.
        {
            int k;      // Used for index arithmetic.
            int temp;   // Used for exchange.

            while ((min + min) <= max)
            {
                k = min + min;
                if (k < max)
                    if (TestArray[k]
                        < TestArray[k + 1])
                        ++k;
                if (TestArray[min]
                    < TestArray[k])
                {
                    temp = TestArray[k];
                    TestArray[k]
                        = TestArray[min];
                    TestArray[min] = temp;
                    min = k;
                }
                else
                    min = max + 1;
            }
        }


/*
* NumHeapSort
*
* Sorts one of the int arrays in the array of arrays.
* This routine performs a heap sort on that array.
*/

        private void NumHeapSort()
        {
            int temp;                   // Used to exchange elements.
            int top = array_rows - 1;   // Last index in array. First is zero.

            // First, build a heap in the array. Sifting moves larger
            // values toward bottom of array.

            for (int i = top / 2; i > 0; --i)
                NumSift(i, top);

            // Repeatedly extract maximum from heap and place it at the
            // end of the array. When we get done, we'll have a sorted
            // array.

            for (int i = top; i > 0; --i)
            {
                NumSift(0, i);

                // Exchange bottom element with descending top.

                temp = TestArray[0];
                TestArray[0] = TestArray[i];
                TestArray[i] = temp;
            }
        }

/*
* freeTestData
*
* Nulls array and forces garbage collection to free up memory.
*/

        public void freeTestData()
        {
            TestArray = null;    // Destroy the array.
            System.GC.Collect();         // Force garbage collection.
        }

    }

    public class JGFHeapSortBench : NumericSortTest
    {

        private int size;
        private int[] datasizes ={ 1000000, 5000000, 25000000 };

        public void JGFsetsize(int size)
        {
            this.size = size;
        }

        public void JGFinitialise()
        {
            array_rows = datasizes[size];
            buildTestData();
        }

        public void JGFkernel()
        {
            Do();
        }

        public void JGFvalidate()
        {
            bool error;

            error = false;
            for (int i = 1; i < array_rows; i++)
            {
                error = (TestArray[i] < TestArray[i - 1]);
                if (error)
                {
                    System.Diagnostics.Debug.WriteLine("Validation failed");
                    System.Diagnostics.Debug.WriteLine("Item " + i + " = " + TestArray[i]);
                    System.Diagnostics.Debug.WriteLine("Item " + (i - 1) + " = " + TestArray[i - 1]);
                    break;
                }
            }
        }


        public void JGFtidyup()
        {
            freeTestData();
        }



        public void JGFrun(int size)
        {


            //JGFInstrumentor.addTimer("Section2:HeapSort:Kernel", "items",size);

            JGFsetsize(size);
            JGFinitialise();
            JGFkernel();
            JGFvalidate();
            JGFtidyup();


            //JGFInstrumentor.addOpsToTimer("Section2:HeapSort:Kernel", array_rows); 
            //JGFInstrumentor.printTimer("Section2:HeapSort:Kernel"); 
        }

        public static void Run()
        {
            JGFHeapSortBench hb = new JGFHeapSortBench();
            hb.JGFrun(1);

        }
    }
}
