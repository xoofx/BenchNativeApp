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
*    Original version of this code by DHPC Group, Univ. of Adelaide       *
*                    See copyright notice below.                          *
*                                                                         *
*                                                                         *
*      This version copyright (c) The University of Edinburgh, 1999.      *
*                         All rights reserved.                            *
*                                                                         *
**************************************************************************/

/*
 *  Copyright (C) 1998, University of Adelaide, under its participation
 *  in the Advanced Computational Systems Cooperative Research Centre
 *  Agreement.
 *
 *  THIS SOFTWARE IS MADE AVAILABLE, AS IS, AND THE UNIVERSITY
 *  OF ADELAIDE DOES NOT MAKE ANY WARRANTY ABOUT THE SOFTWARE, ITS
 *  PERFORMANCE, ITS MERCHANTABILITY OR FITNESS FOR ANY PARTICULAR
 *  USE, FREEDOM FROM ANY COMPUTER DISEASES OR ITS CONFORMITY TO ANY
 *  SPECIFICATION. THE ENTIRE RISK AS TO QUALITY AND PERFORMANCE OF
 *  THE SOFTWARE IS WITH THE USER.
 *
 *  Copyright of the software and supporting documentation is owned by the
 *  University of Adelaide, and free access is hereby granted as a license
 *  to use this software, copy this software and prepare derivative works
 *  based upon this software.  However, any distribution of this software
 *  source code or supporting documentation or derivative works (source
 *  code and supporting documentation) must include this copyright notice
 *  and acknowledge the University of Adelaide.
 *
 *
 *  Developed by: Distributed High Performance Computing (DHPC) Group
 *                Department of Computer Science
 *                The University of Adelaide
 *                South Australia 5005
 *                Tel +61 8 8303 4519, Fax +61 8 8303 4366
 *                http://dhpc.adelaide.edu.au
 *  Last Modified: 26 January 1999
 */


using System;

namespace CSGrande
{

    public class JGFCreateBench
    {

        //public const int INITSIZE =   10000;
        //public const int MAXSIZE =    1000000000;
        public const int INITSIZE = 10000;
        public const int MAXSIZE = 100000;
        int i, size;
        int[] j;
        long[] k;
        float[] c;
        Object[] d;

        A a; A1 a1; A2 a2; A4 a4; A4L a4l; A4F a4f;
        AA aa; B b; AB ab; Object o; ABC abc;

        int max = 128;
        int n = 1;


        public void JGFrun()
        {


            // Create arrays of integers of varying sizes (1-128)
            while (n <= max)
            {
                //JGFInstrumentor.addTimer("Section1:Create:Array:Int:"+n, "arrays");

                size = INITSIZE;
                while (size < MAXSIZE)
                {
                    //JGFInstrumentor.resetTimer("Section1:Create:Array:Int:"+n); 
                    //JGFInstrumentor.startTimer("Section1:Create:Array:Int:"+n); 
                    for (i = 0; i < size; i++)
                    {
                        j = new int[n]; j = new int[n]; j = new int[n]; j = new int[n];
                        j = new int[n]; j = new int[n]; j = new int[n]; j = new int[n];
                        j = new int[n]; j = new int[n]; j = new int[n]; j = new int[n];
                        j = new int[n]; j = new int[n]; j = new int[n]; j = new int[n];
                    }
                    //JGFInstrumentor.stopTimer("Section1:Create:Array:Int:"+n); 
                    ////time = //JGFInstrumentor.readTimer("Section1:Create:Array:Int:"+n); 
                    //JGFInstrumentor.addOpsToTimer("Section1:Create:Array:Int:"+n, (double) 16*size);  
                    size *= 2;
                }
                //JGFInstrumentor.printperfTimer("Section1:Create:Array:Int:"+n);
                System.GC.Collect();       // Reclaim memory
                n *= 2;
            }

            // Create arrays of long integers of varying sizes (1-128)
            n = 1;
            while (n <= max)
            {
                //JGFInstrumentor.addTimer("Section1:Create:Array:Long:"+n, "arrays");

                size = INITSIZE;
                while (size < MAXSIZE)
                {
                    //JGFInstrumentor.resetTimer("Section1:Create:Array:Long:"+n); 
                    //JGFInstrumentor.startTimer("Section1:Create:Array:Long:"+n); 
                    for (i = 0; i < size; i++)
                    {
                        k = new long[n]; k = new long[n]; k = new long[n]; k = new long[n];
                        k = new long[n]; k = new long[n]; k = new long[n]; k = new long[n];
                        k = new long[n]; k = new long[n]; k = new long[n]; k = new long[n];
                        k = new long[n]; k = new long[n]; k = new long[n]; k = new long[n];
                    }
                    //JGFInstrumentor.stopTimer("Section1:Create:Array:Long:"+n); 
                    ////time = //JGFInstrumentor.readTimer("Section1:Create:Array:Long:"+n); 
                    //JGFInstrumentor.addOpsToTimer("Section1:Create:Array:Long:"+n, (double) 16*size);
                    size *= 2;
                }
                //JGFInstrumentor.printperfTimer("Section1:Create:Array:Long:"+n);
                System.GC.Collect();  // Reclaim memory
                n *= 2;
            }

            // Create arrays of floats of varying sizes (1-128)
            n = 1;
            while (n <= max)
            {
                //JGFInstrumentor.addTimer("Section1:Create:Array:Float:"+n, "arrays");

                size = INITSIZE;
                while (size < MAXSIZE)
                {
                    //JGFInstrumentor.resetTimer("Section1:Create:Array:Float:"+n); 
                    //JGFInstrumentor.startTimer("Section1:Create:Array:Float:"+n); 
                    for (i = 0; i < size; i++)
                    {
                        c = new float[n]; c = new float[n]; c = new float[n]; c = new float[n];
                        c = new float[n]; c = new float[n]; c = new float[n]; c = new float[n];
                        c = new float[n]; c = new float[n]; c = new float[n]; c = new float[n];
                        c = new float[n]; c = new float[n]; c = new float[n]; c = new float[n];
                    }
                    //JGFInstrumentor.stopTimer("Section1:Create:Array:Float:"+n); 
                    ////time = //JGFInstrumentor.readTimer("Section1:Create:Array:Float:"+n); 
                    //JGFInstrumentor.addOpsToTimer("Section1:Create:Array:Float:"+n, (double) 16*size);  
                    size *= 2;
                }
                //JGFInstrumentor.printperfTimer("Section1:Create:Array:Float:"+n);
                System.GC.Collect();  // Reclaim memory
                n *= 2;
            }

            // Create arrays of Objects of varying sizes (1-128)   
            n = 1;
            while (n <= max)
            {
                //JGFInstrumentor.addTimer("Section1:Create:Array:Object:"+n, "arrays");

                size = INITSIZE;
                while (size < MAXSIZE)
                {
                    //JGFInstrumentor.resetTimer("Section1:Create:Array:Object:"+n); 
                    //JGFInstrumentor.startTimer("Section1:Create:Array:Object:"+n); 
                    for (i = 0; i < size; i++)
                    {
                        d = new Object[n]; d = new Object[n]; d = new Object[n]; d = new Object[n];
                        d = new Object[n]; d = new Object[n]; d = new Object[n]; d = new Object[n];
                        d = new Object[n]; d = new Object[n]; d = new Object[n]; d = new Object[n];
                        d = new Object[n]; d = new Object[n]; d = new Object[n]; d = new Object[n];
                    }
                    //JGFInstrumentor.stopTimer("Section1:Create:Array:Object:"+n); 
                    ////time = //JGFInstrumentor.readTimer("Section1:Create:Array:Object:"+n); 
                    //JGFInstrumentor.addOpsToTimer("Section1:Create:Array:Object:"+n, (double) 16*size);  
                    size *= 2;
                }
                //JGFInstrumentor.printperfTimer("Section1:Create:Array:Object:"+n);
                System.GC.Collect();  // Reclaim memory
                n *= 2;
            }

            // Basic object
            //JGFInstrumentor.addTimer("Section1:Create:Object:Base", "objects");

            size = INITSIZE;
            o = new Object();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Base"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Base"); 
                for (i = 0; i < size; i++)
                {
                    o = new Object(); o = new Object(); o = new Object(); o = new Object();
                    o = new Object(); o = new Object(); o = new Object(); o = new Object();
                    o = new Object(); o = new Object(); o = new Object(); o = new Object();
                    o = new Object(); o = new Object(); o = new Object(); o = new Object();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Base"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Base"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Base", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Base");
            System.GC.Collect(); // Reclaim memory

            // User defined object
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple", "objects");

            size = INITSIZE;
            a = new A();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple"); 
                for (i = 0; i < size; i++)
                {
                    a = new A(); a = new A(); a = new A(); a = new A();
                    a = new A(); a = new A(); a = new A(); a = new A();
                    a = new A(); a = new A(); a = new A(); a = new A();
                    a = new A(); a = new A(); a = new A(); a = new A();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple");
            System.GC.Collect(); // Reclaim memory

            // User defined object with empty contructor   
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple:Constructor", "objects");

            size = INITSIZE;
            aa = new AA();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple:Constructor"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple:Constructor"); 
                for (i = 0; i < size; i++)
                {
                    aa = new AA(); aa = new AA(); aa = new AA(); aa = new AA();
                    aa = new AA(); aa = new AA(); aa = new AA(); aa = new AA();
                    aa = new AA(); aa = new AA(); aa = new AA(); aa = new AA();
                    aa = new AA(); aa = new AA(); aa = new AA(); aa = new AA();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple:Constructor"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple:Constructor"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple:Constructor", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple:Constructor");
            System.GC.Collect(); // Reclaim memory

            // User defined object with 1 integer field   
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple:1Field", "objects");

            size = INITSIZE;
            a1 = new A1();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple:1Field"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple:1Field"); 
                for (i = 0; i < size; i++)
                {
                    a1 = new A1(); a1 = new A1(); a1 = new A1(); a1 = new A1();
                    a1 = new A1(); a1 = new A1(); a1 = new A1(); a1 = new A1();
                    a1 = new A1(); a1 = new A1(); a1 = new A1(); a1 = new A1();
                    a1 = new A1(); a1 = new A1(); a1 = new A1(); a1 = new A1();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple:1Field"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple:1Field"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple:1Field", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple:1Field"); 
            System.GC.Collect(); // Reclaim memory

            // User defined object with 2 integer fields  
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple:2Field", "objects");

            size = INITSIZE;
            a2 = new A2();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple:2Field"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple:2Field"); 
                for (i = 0; i < size; i++)
                {
                    a2 = new A2(); a2 = new A2(); a2 = new A2(); a2 = new A2();
                    a2 = new A2(); a2 = new A2(); a2 = new A2(); a2 = new A2();
                    a2 = new A2(); a2 = new A2(); a2 = new A2(); a2 = new A2();
                    a2 = new A2(); a2 = new A2(); a2 = new A2(); a2 = new A2();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple:2Field"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple:2Field"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple:2Field", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple:2Field"); 
            System.GC.Collect(); // Reclaim memory

            // User defined object with 2 integer fields
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple:4Field", "objects");

            size = INITSIZE;
            a4 = new A4();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple:4Field"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple:4Field"); 
                for (i = 0; i < size; i++)
                {
                    a4 = new A4(); a4 = new A4(); a4 = new A4(); a4 = new A4();
                    a4 = new A4(); a4 = new A4(); a4 = new A4(); a4 = new A4();
                    a4 = new A4(); a4 = new A4(); a4 = new A4(); a4 = new A4();
                    a4 = new A4(); a4 = new A4(); a4 = new A4(); a4 = new A4();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple:4Field"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple:4Field"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple:4Field", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple:4Field"); 
            System.GC.Collect(); // Reclaim memory

            // User defined object with 4 integer fields
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple:4fField", "objects");

            size = INITSIZE;
            a4f = new A4F();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple:4fField"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple:4fField"); 
                for (i = 0; i < size; i++)
                {
                    a4f = new A4F(); a4f = new A4F(); a4f = new A4F(); a4f = new A4F();
                    a4f = new A4F(); a4f = new A4F(); a4f = new A4F(); a4f = new A4F();
                    a4f = new A4F(); a4f = new A4F(); a4f = new A4F(); a4f = new A4F();
                    a4f = new A4F(); a4f = new A4F(); a4f = new A4F(); a4f = new A4F();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple:4fField"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple:4fField"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple:4fField", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple:4fField"); 
            System.GC.Collect();

            // User defined object with 4 long integer fields
            //JGFInstrumentor.addTimer("Section1:Create:Object:Simple:4LField", "objects");

            size = INITSIZE;
            a4l = new A4L();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Simple:4LField"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Simple:4LField"); 
                for (i = 0; i < size; i++)
                {
                    a4l = new A4L(); a4l = new A4L(); a4l = new A4L(); a4l = new A4L();
                    a4l = new A4L(); a4l = new A4L(); a4l = new A4L(); a4l = new A4L();
                    a4l = new A4L(); a4l = new A4L(); a4l = new A4L(); a4l = new A4L();
                    a4l = new A4L(); a4l = new A4L(); a4l = new A4L(); a4l = new A4L();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Simple:4LField"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Simple:4LField"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Simple:4LField", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Simple:4LField"); 
            System.GC.Collect(); // Reclaim memory

            // User defined object that is a subclass
            //JGFInstrumentor.addTimer("Section1:Create:Object:Subclass", "objects");

            size = INITSIZE;
            b = new B();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Subclass"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Subclass"); 
                for (i = 0; i < size; i++)
                {
                    b = new B(); b = new B(); b = new B(); b = new B();
                    b = new B(); b = new B(); b = new B(); b = new B();
                    b = new B(); b = new B(); b = new B(); b = new B();
                    b = new B(); b = new B(); b = new B(); b = new B();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Subclass"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Subclass"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Subclass", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Subclass"); 
            System.GC.Collect(); // Reclaim memory

            // User defined object that instantiates another object
            //JGFInstrumentor.addTimer("Section1:Create:Object:Complex", "objects");

            size = INITSIZE;
            ab = new AB();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Complex"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Complex"); 
                for (i = 0; i < size; i++)
                {
                    ab = new AB(); ab = new AB(); ab = new AB(); ab = new AB();
                    ab = new AB(); ab = new AB(); ab = new AB(); ab = new AB();
                    ab = new AB(); ab = new AB(); ab = new AB(); ab = new AB();
                    ab = new AB(); ab = new AB(); ab = new AB(); ab = new AB();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Complex"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Complex"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Complex", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Complex");
            System.GC.Collect(); // Reclaim memory

            // User defined object that instantiates another object in it's contructor
            //JGFInstrumentor.addTimer("Section1:Create:Object:Complex:Constructor", "objects");

            size = INITSIZE;
            abc = new ABC();
            while (size < MAXSIZE)
            {
                //JGFInstrumentor.resetTimer("Section1:Create:Object:Complex:Constructor"); 
                //JGFInstrumentor.startTimer("Section1:Create:Object:Complex:Constructor"); 
                for (i = 0; i < size; i++)
                {
                    abc = new ABC(); abc = new ABC(); abc = new ABC(); abc = new ABC();
                    abc = new ABC(); abc = new ABC(); abc = new ABC(); abc = new ABC();
                    abc = new ABC(); abc = new ABC(); abc = new ABC(); abc = new ABC();
                    abc = new ABC(); abc = new ABC(); abc = new ABC(); abc = new ABC();
                }
                //JGFInstrumentor.stopTimer("Section1:Create:Object:Complex:Constructor"); 
                //time = //JGFInstrumentor.readTimer("Section1:Create:Object:Complex:Constructor"); 
                //JGFInstrumentor.addOpsToTimer("Section1:Create:Object:Complex:Constructor", (double) 16*size);  
                size *= 2;
            }
            //JGFInstrumentor.printperfTimer("Section1:Create:Object:Complex:Constructor");
            System.GC.Collect(); // Reclaim memory

        }

        public static void Run()
        {

            //JGFInstrumentor.printHeader(1,0);

            JGFCreateBench crb = new JGFCreateBench();
            crb.JGFrun();

        }
    }

    class A { }

    class AA
    {
        public AA() { }
    }

    class A1
    {
        int a;
    }

    class A2
    {
        int a, b;
    }
    class A4
    {
        int a, b, c, d;
    }
    class A4L
    {
        long a, b, c, d;
    }
    class A4F
    {
        float a, b, c, d;
    }
    class A4if
    {
        int a, b, c, d;
        float g, h, i, j;
    }

    class AB
    {
        A a = new A();
    }

    class ABC
    {
        A a;

        public ABC()
        {
            a = new A();
        }
    }

    class B : A { };
}






