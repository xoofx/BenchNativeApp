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
*                                                                         *
*      This version copyright (c) The University of Edinburgh, 1999.      *
*                         All rights reserved.                            *
*                                                                         *
**************************************************************************/


using System;

namespace CSGrande
{

    public class JGFCastBench
    {

        //public const int INITSIZE =   10000;
        //public const int MAXSIZE =    1000000000;
        public const int INITSIZE =     10000;
        public const int MAXSIZE =      2000000;
        int i, size;

        int i1 = 0;
        long l1 = 0;
        float f1 = 0.0F;
        double d1 = 0.0D;

        public void JGFrun()
        {
            size = INITSIZE;
            i1 = 6;


            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                    f1 = (float)i1; i1 = (int)f1;
                }

                size *= 2;
            }

            //JGFInstrumentor.printperfTimer("Section1:Cast:IntFloat"); 

            //JGFInstrumentor.addTimer("Section1:Cast:IntDouble", "casts");


            size = INITSIZE;
            i1 = 6;

            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Cast:IntDouble"); 
                //JGFInstrumentor.startTimer("Section1:Cast:IntDouble"); 
                for (i = 0; i < size; i++)
                {
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                    d1 = (double)i1; i1 = (int)d1;
                }
                //JGFInstrumentor.stopTimer("Section1:Cast:IntDouble"); 

                size *= 2;
            }

            //JGFInstrumentor.printperfTimer("Section1:Cast:IntDouble"); 

            //JGFInstrumentor.addTimer("Section1:Cast:LongFloat", "casts");


            size = INITSIZE;
            l1 = 7;

            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Cast:LongFloat"); 
                //JGFInstrumentor.startTimer("Section1:Cast:LongFloat"); 
                for (i = 0; i < size; i++)
                {
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                    f1 = (float)l1; l1 = (long)f1;
                }
                //JGFInstrumentor.stopTimer("Section1:Cast:LongFloat"); 

                size *= 2;
            }

            //JGFInstrumentor.printperfTimer("Section1:Cast:LongFloat"); 

            //JGFInstrumentor.addTimer("Section1:Cast:LongDouble", "casts");


            size = INITSIZE;
            l1 = 7;

            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Cast:LongDouble"); 
                //JGFInstrumentor.startTimer("Section1:Cast:LongDouble"); 
                for (i = 0; i < size; i++)
                {
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                    d1 = (double)l1; l1 = (long)d1;
                }
                //JGFInstrumentor.stopTimer("Section1:Cast:LongDouble"); 

                size *= 2;
            }

            //JGFInstrumentor.printperfTimer("Section1:Cast:LongDouble"); 

        }

        public static void Run()
        {

            //JGFInstrumentor.printHeader(1,0);

            JGFCastBench cb = new JGFCastBench();
            cb.JGFrun();

        }
    }
}


