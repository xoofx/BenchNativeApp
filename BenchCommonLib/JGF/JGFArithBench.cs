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

    public class JGFArithBench
    {

        //public const int INITSIZE =   10000;
        //public const int MAXSIZE =    1000000000;
        public const int INITSIZE =     10000;
        public const int MAXSIZE =      100000;

        int i, size;
        int i1, i2, i3, i4;
        long l1, l2, l3, l4;
        float f1, f2, f3, f4;
        double d1, d2, d3, d4;

        public void JGFrun()
        {
            size = INITSIZE;
            i1 = 1; i2 = -2; i3 = 3; i4 = -4;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    i2 += i1;
                    i3 += i2;
                    i4 += i3;
                    i1 += i4;
                    i2 += i1;
                    i3 += i2;
                    i4 += i3;
                    i1 += i4;
                    i2 += i1;
                    i3 += i2;
                    i4 += i3;
                    i1 += i4;
                    i2 += i1;
                    i3 += i2;
                    i4 += i3;
                    i1 += i4;
                }
                size *= 2;
            }

            size = INITSIZE;
            l1 = 1L; l2 = -2L; l3 = 3L; l4 = -4L;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    l2 += l1;
                    l3 += l2;
                    l4 += l3;
                    l1 += l4;
                    l2 += l1;
                    l3 += l2;
                    l4 += l3;
                    l1 += l4;
                    l2 += l1;
                    l3 += l2;
                    l4 += l3;
                    l1 += l4;
                    l2 += l1;
                    l3 += l2;
                    l4 += l3;
                    l1 += l4;
                }

                size *= 2;
            }

            size = INITSIZE;
            f1 = 1.0F; f2 = -2.0F; f3 = 3.0F; f4 = -4.0F;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    f2 += f1;
                    f3 += f2;
                    f4 += f3;
                    f1 += f4;
                    f2 += f1;
                    f3 += f2;
                    f4 += f3;
                    f1 += f4;
                    f2 += f1;
                    f3 += f2;
                    f4 += f3;
                    f1 += f4;
                    f2 += f1;
                    f3 += f2;
                    f4 += f3;
                    f1 += f4;
                }

                size *= 2;
            }

            size = INITSIZE;
            d1 = 1.0D; d2 = -2.0D; d3 = 3.0D; d4 = -4.0D;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    d2 += d1;
                    d3 += d2;
                    d4 += d3;
                    d1 += d4;
                    d2 += d1;
                    d3 += d2;
                    d4 += d3;
                    d1 += d4;
                    d2 += d1;
                    d3 += d2;
                    d4 += d3;
                    d1 += d4;
                    d2 += d1;
                    d3 += d2;
                    d4 += d3;
                    d1 += d4;
                }

                size *= 2;
            }

            size = INITSIZE;
            i1 = 1; i2 = -2; i3 = 3; i4 = -4;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    i2 *= i1;
                    i3 *= i2;
                    i4 *= i3;
                    i1 *= i4;
                    i2 *= i1;
                    i3 *= i2;
                    i4 *= i3;
                    i1 *= i4;
                    i2 *= i1;
                    i3 *= i2;
                    i4 *= i3;
                    i1 *= i4;
                    i2 *= i1;
                    i3 *= i2;
                    i4 *= i3;
                    i1 *= i4;
                }

                size *= 2;
            }

            size = INITSIZE;
            l1 = 1L; l2 = -2L; l3 = 3L; l4 = -4L;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    l2 *= l1;
                    l3 *= l2;
                    l4 *= l3;
                    l1 *= l4;
                    l2 *= l1;
                    l3 *= l2;
                    l4 *= l3;
                    l1 *= l4;
                    l2 *= l1;
                    l3 *= l2;
                    l4 *= l3;
                    l1 *= l4;
                    l2 *= l1;
                    l3 *= l2;
                    l4 *= l3;
                    l1 *= l4;
                }
                size *= 2;
            }

            size = INITSIZE;
            // prevent overflow 
            f2 = (float)Math.PI;
            f3 = 1.0F / f2;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                    f1 *= f2;
                    f1 *= f3;
                }

                size *= 2;
            }

            size = INITSIZE;
            // prevent overflow
            d2 = Math.PI;
            d3 = 1.0D / d3;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                    d1 *= d2;
                    d1 *= d3;
                }

                size *= 2;
            }

            size = INITSIZE;
            i1 = int.MaxValue; ;
            i2 = 3;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    i1 /= i2;
                    if (i1 == 0) i1 = int.MaxValue;
                }

                size *= 2;
            }

            size = INITSIZE;
            l1 = long.MaxValue;
            l2 = 3L;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    l1 /= l2;
                    if (l1 == 0) l1 = long.MaxValue;
                }

                size *= 2;
            }

            size = INITSIZE;
            // prevent overflow 
            f2 = (float)Math.PI;
            f3 = 1.0F / f2;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                    f1 /= f2;
                    f1 /= f3;
                }

                size *= 2;
            }

            size = INITSIZE;
            // prevent overflow
            d2 = Math.PI;
            d3 = 1.0D / d3;

            while (size < MAXSIZE)
            {
                for (i = 0; i < size; i++)
                {
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                    d1 /= d2;
                    d1 /= d3;
                }

                size *= 2;
            }
        }

        public static void Run()
        {
            JGFArithBench ab = new JGFArithBench();
            ab.JGFrun();
        }
    }
}



