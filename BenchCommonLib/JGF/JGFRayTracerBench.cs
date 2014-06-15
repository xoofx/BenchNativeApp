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
using System.Collections;
using System.Collections.Generic;

namespace raytracer2 {
     
    public class Interval
    {
        public int number;
        public int width;
        public int height;
        public int yfrom;
        public int yto;
        public int total;

        public Interval(int number, int width, int height, int yfrom, int yto, int total)
        {
            this.number = number;
            this.width = width;
            this.height = height;
            this.yfrom = yfrom;
            this.yto = yto;
            this.total = total;
        }
    }

    public class Isect
    {
        public double t;
        public int enter;
        public Primitive prim;
        public Surface surf;
    }

    
    public class Light
    {
        public Vec pos;
        public double brightness;

        public Light()
        {
        }

        public Light(double x, double y, double z, double brightness)
        {
            this.pos = new Vec(x, y, z);
            this.brightness = brightness;
        }
    }

    public class Ray
    {
        public Vec P, D;

        public Ray(Vec pnt, Vec dir)
        {
            P = new Vec(pnt.x, pnt.y, pnt.z);
            D = new Vec(dir.x, dir.y, dir.z);
            D.normalize();
        }

        public Ray()
        {
            P = new Vec();
            D = new Vec();
        }

        public Vec point(double t)
        {
            return new Vec(P.x + D.x * t, P.y + D.y * t, P.z + D.z * t);
        }

        public String toString()
        {
            return "{" + P.toString() + " -> " + D.toString() + "}";
        }
    }


    public class Scene
    {
        public List<Light> lights;
        public List<Primitive> objects;
        private View view;

        public Scene()
        {
            this.lights = new List<Light>();
            this.objects = new List<Primitive>();
        }

        public void addLight(Light l)
        {
            this.lights.Add(l);
        }

        public void addObject(Primitive myobject)
        {
            this.objects.Add(myobject);
        }

        public void setView(View view)
        {
            this.view = view;
        }

        public View getView()
        {
            return this.view;
        }

        public Light getLight(int number)
        {
            return (Light)this.lights[number];
        }

        public Primitive getObject(int number)
        {
            return (Primitive)objects[number];
        }

        public int getLights()
        {
            return this.lights.Count;
        }

        public int getObjects()
        {
            return this.objects.Count;
        }

        public void setObject(Primitive myobject, int pos)
        {
            this.objects[pos] = myobject; ;
        }
    }

    public abstract class Primitive
    {
        public Surface surf = new Surface();

        public void setColor(double r, double g, double b)
        {
            surf.color = new Vec(r, g, b);
        }

        public abstract Vec normal(Vec pnt);
        public abstract Isect intersect(Ray ry);
        public abstract String toString();
        public abstract Vec getCenter();
        public abstract void setCenter(Vec c);
    }

    public class Sphere : Primitive
    {
        Vec c;
        double r, r2;
        Vec v, b; // temporary vecs used to minimize the memory load

        public Sphere(Vec center, double radius)
        {
            c = center;
            r = radius;
            r2 = r * r;
            v = new Vec();
            b = new Vec();
        }

        public override Isect intersect(Ray ry)
        {
            double b, disc, t;
            Isect ip;
            v.sub2(c, ry.P);
            b = Vec.dot(v, ry.D);
            disc = b * b - Vec.dot(v, v) + r2;
            if (disc < 0.0)
            {
                return null;
            }
            disc = Math.Sqrt(disc);
            t = (b - disc < 1e-6) ? b + disc : b - disc;
            if (t < 1e-6)
            {
                return null;
            }
            ip = new Isect();
            ip.t = t;
            ip.enter = Vec.dot(v, v) > r2 + 1e-6 ? 1 : 0;
            ip.prim = this;
            ip.surf = surf;
            return ip;
        }

        public override Vec normal(Vec p)
        {
            Vec r;
            r = Vec.sub(p, c);
            r.normalize();
            return r;
        }

        public override String toString()
        {
            return "Sphere {" + c.toString() + "," + r + "}";
        }

        public override Vec getCenter()
        {
            return c;
        }
        public override void setCenter(Vec c)
        {
            this.c = c;
        }
    }

    public class Surface
    {
        public Vec color;
        public double kd;
        public double ks;
        public double shine;
        public double kt;
        public double ior;

        public Surface()
        {
            color = new Vec(1, 0, 0);
            kd = 1.0;
            ks = 0.0;
            shine = 0.0;
            kt = 0.0;
            ior = 1.0;
        }

        public String toString()
        {
            return "Surface { color=" + color + "}";
        }
    }

    public class Vec
    {

        /**
   * The x coordinate
   */
        public double x;

        /**
   * The y coordinate
   */
        public double y;

        /**
   * The z coordinate
   */
        public double z;

        /**
   * Constructor
   * @param a the x coordinate
   * @param b the y coordinate
   * @param c the z coordinate
   */
        public Vec(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }

        /**
   * Copy constructor
   */
        public Vec(Vec a)
        {
            x = a.x;
            y = a.y;
            z = a.z;
        }
        /**
   * Default (0,0,0) constructor
   */
        public Vec()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
        }

        /**
   * Add a vector to the current vector
   * @param: a The vector to be added
   */
        public void add(Vec a)
        {
            x += a.x;
            y += a.y;
            z += a.z;
        }

        /**
   * adds: Returns a new vector such as
   * new = sA + B
   */
        public static Vec adds(double s, Vec a, Vec b)
        {
            return new Vec(s * a.x + b.x, s * a.y + b.y, s * a.z + b.z);
        }

        /**
   * Adds vector such as:
   * this+=sB
   * @param: s The multiplier
   * @param: b The vector to be added
   */
        public void adds(double s, Vec b)
        {
            x += s * b.x;
            y += s * b.y;
            z += s * b.z;
        }

        /**
   * Substracs two vectors
   */
        public static Vec sub(Vec a, Vec b)
        {
            return new Vec(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        /**
   * Substracts two vects and places the results in the current vector
   * Used for speedup with local variables -there were too much Vec to be gc'ed
   * Consumes about 10 units, whether sub consumes nearly 999 units!! 
   * cf thinking in java p. 831,832
   */
        public void sub2(Vec a, Vec b)
        {
            this.x = a.x - b.x;
            this.y = a.y - b.y;
            this.z = a.z - b.z;
        }

        public static Vec mult(Vec a, Vec b)
        {
            return new Vec(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vec cross(Vec a, Vec b)
        {
            return
              new Vec(a.y * b.z - a.z * b.y,
                  a.z * b.x - a.x * b.z,
                  a.x * b.y - a.y * b.x);
        }

        public static double dot(Vec a, Vec b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vec comb(double a, Vec A, double b, Vec B)
        {
            return
              new Vec(a * A.x + b * B.x,
                  a * A.y + b * B.y,
                  a * A.z + b * B.z);
        }

        public void comb2(double a, Vec A, double b, Vec B)
        {
            x = a * A.x + b * B.x;
            y = a * A.y + b * B.y;
            z = a * A.z + b * B.z;
        }

        public void scale(double t)
        {
            x *= t;
            y *= t;
            z *= t;
        }

        public void negate()
        {
            x = -x;
            y = -y;
            z = -z;
        }

        public double normalize()
        {
            double len;
            len = Math.Sqrt(x * x + y * y + z * z);
            if (len > 0.0)
            {
                x /= len;
                y /= len;
                z /= len;
            }
            return len;
        }

        public String toString()
        {
            return "<" + x + "," + y + "," + z + ">";
        }
    }


    public class View
    {
/*    public  Vec     from;
	public  Vec	    at;
	public  Vec	    up;
	public  double	dist;
	public  double	angle;
	public  double	aspect;*/
        public Vec from;
        public Vec at;
        public Vec up;
        public double dist;
        public double angle;
        public double aspect;

        public View(Vec from, Vec at, Vec up, double dist, double angle, double aspect)
        {
            this.from = from;
            this.at = at;
            this.up = up;
            this.dist = dist;
            this.angle = angle;
            this.aspect = aspect;
        }
    }


    public class RayTracer
    {
        public Scene scene;
        /**
   * Lights for the rendering scene
   */
        public Light[] lights;

        /**
   * Objects (spheres) for the rendering scene
   */
        public Primitive[] prim;


        /**
   * The view for the rendering scene
   */
        public View view;

        /**
   * Temporary ray
   */
        public Ray tRay = new Ray();

        /**
   * Alpha channel
   */
        static int alpha = 255 << 24;

        /**
   * Null vector (for speedup, instead of <code>new Vec(0,0,0)</code>
   */
        static Vec voidVec = new Vec();

        /**
   * Temporary vect
   */
        Vec L = new Vec();

        /**
   * Current intersection instance (only one is needed!)
   */
        public Isect inter = new Isect();

        /**
   * Height of the <code>Image</code> to be rendered
   */
        public int height;

        /**
   * Width of the <code>Image</code> to be rendered
   */
        public int width;

        public int[] datasizes = new int[] { 150, 500 };

        public long checksum = 0;

        public int size;

        public int numobjects;

        /**
   * Create and initialize the scene for the rendering picture.
   * @return The scene just created
   */

        public Scene createScene()
        {
            int x = 0;
            int y = 0;

            Scene scene = new Scene();


            /* create spheres */

            Primitive p;
            int nx = 4;
            int ny = 4;
            int nz = 4;
            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {
                    for (int k = 0; k < nz; k++)
                    {
                        double xx = 20.0 / (nx - 1) * i - 10.0;
                        double yy = 20.0 / (ny - 1) * j - 10.0;
                        double zz = 20.0 / (nz - 1) * k - 10.0;

                        p = new Sphere(new Vec(xx, yy, zz), 3);
                        //p.setColor(i/(double) (nx-1), j/(double)(ny-1), k/(double) (nz-1));
                        p.setColor(0, 0, (i + j) / (double)(nx + ny - 2));
                        p.surf.shine = 15.0;
                        p.surf.ks = 1.5 - 1.0;
                        p.surf.kt = 1.5 - 1.0;
                        scene.addObject(p);
                    }
                }
            }



            /* Creates five lights for the scene */
            scene.addLight(new Light(100, 100, -50, 1.0));
            scene.addLight(new Light(-100, 100, -50, 1.0));
            scene.addLight(new Light(100, -100, -50, 1.0));
            scene.addLight(new Light(-100, -100, -50, 1.0));
            scene.addLight(new Light(200, 200, 0, 1.0));

            /* Creates a View (viewing point) for the rendering scene */
            View v = new View(new Vec(x, 20, -30),
                                new Vec(x, y, 0),
                                new Vec(0, 1, 0),
                                1.0,
                    35.0 * 3.14159265 / 180.0,
                                1.0);
/*
    v.from = new Vec(x, y, -30);
    v.at = new Vec(x, y, -15);
    v.up = new Vec(0, 1, 0);
    v.angle = 35.0 * 3.14159265 / 180.0;
    v.aspect = 1.0; 
    v.dist = 1.0;
    
    */
            scene.setView(v);

            return scene;
        }


        public void setScene(Scene scene)
        {
            // Get the objects count
            int nLights = scene.getLights();
            int nObjects = scene.getObjects();

            lights = new Light[nLights];
            prim = new Primitive[nObjects];

            // Get the lights
            for (int l = 0; l < nLights; l++)
            {
                lights[l] = scene.getLight(l);
            }

            // Get the primitives
            for (int o = 0; o < nObjects; o++)
            {
                prim[o] = scene.getObject(o);
            }

            // Set the view
            view = scene.getView();
        }

        public void render(Interval interval)
        {

            // Screen variables
            int[] row = new int[interval.width * (interval.yto - interval.yfrom)];
            int pixCounter = 0; //iterator


            // Rendering variables
            int x, y, red, green, blue;
            double xlen, ylen;
            Vec viewVec;


            viewVec = Vec.sub(view.at, view.from);

            viewVec.normalize();

            Vec tmpVec = new Vec(viewVec);
            tmpVec.scale(Vec.dot(view.up, viewVec));

            Vec upVec = Vec.sub(view.up, tmpVec);
            upVec.normalize();

            Vec leftVec = Vec.cross(view.up, viewVec);
            leftVec.normalize();

            double frustrumwidth = view.dist * Math.Tan(view.angle);

            upVec.scale(-frustrumwidth);
            leftVec.scale(view.aspect * frustrumwidth);

            Ray r = new Ray(view.from, voidVec);
            Vec col = new Vec();

            // Header for .ppm file 
            // System.out.println("P3"); 
            // System.out.println(width + " " + height);
            // System.out.println("255"); 


            // All loops are reversed for 'speedup' (cf. thinking in java p331)

            // For each line
            for (y = interval.yfrom; y < interval.yto; y++)
            {
                ylen = (double)(2.0 * y) / (double)interval.width - 1.0;
                // System.out.println("Doing line " + y);
                // For each pixel of the line
                for (x = 0; x < interval.width; x++)
                {
                    xlen = (double)(2.0 * x) / (double)interval.width - 1.0;
                    r.D = Vec.comb(xlen, leftVec, ylen, upVec);
                    r.D.add(viewVec);
                    r.D.normalize();
                    col = trace(0, 1.0, r);

                    // computes the color of the ray
                    red = (int)(col.x * 255.0);
                    if (red > 255)
                        red = 255;
                    green = (int)(col.y * 255.0);
                    if (green > 255)
                        green = 255;
                    blue = (int)(col.z * 255.0);
                    if (blue > 255)
                        blue = 255;

                    checksum += red;
                    checksum += green;
                    checksum += blue;

                    // RGB values for .ppm file 
                    // System.out.println(red + " " + green + " " + blue); 
                    // Sets the pixels
                    row[pixCounter++] = alpha | (red << 16) | (green << 8) | (blue);
                } // end for (x)
            } // end for (y)

        }

        bool intersect(Ray r, double maxt)
        {
            Isect tp;
            int i, nhits;

            nhits = 0;
            inter.t = 1e9;
            for (i = 0; i < prim.Length; i++)
            {
                // uses global temporary Prim (tp) as temp.object for speedup
                tp = prim[i].intersect(r);
                if (tp != null && tp.t < inter.t)
                {
                    inter.t = tp.t;
                    inter.prim = tp.prim;
                    inter.surf = tp.surf;
                    inter.enter = tp.enter;
                    nhits++;
                }
            }
            return nhits > 0 ? true : false;
        }

        /**
   * Checks if there is a shadow
   * @param r The ray
   * @return Returns 1 if there is a shadow, 0 if there isn't
   */
        int Shadow(Ray r, double tmax)
        {
            if (intersect(r, tmax))
                return 0;
            return 1;
        }


        /**
   * Return the Vector's reflection direction
   * @return The specular direction
   */
        Vec SpecularDirection(Vec I, Vec N)
        {
            Vec r;
            r = Vec.comb(1.0 / Math.Abs(Vec.dot(I, N)), I, 2.0, N);
            r.normalize();
            return r;
        }

        /**
   * Return the Vector's transmission direction
   */
        Vec TransDir(Surface m1, Surface m2, Vec I, Vec N)
        {
            double n1, n2, eta, c1, cs2;
            Vec r;
            n1 = m1 == null ? 1.0 : m1.ior;
            n2 = m2 == null ? 1.0 : m2.ior;
            eta = n1 / n2;
            c1 = -Vec.dot(I, N);
            cs2 = 1.0 - eta * eta * (1.0 - c1 * c1);
            if (cs2 < 0.0)
                return null;
            r = Vec.comb(eta, I, eta * c1 - Math.Sqrt(cs2), N);
            r.normalize();
            return r;
        }


        /**
   * Returns the shaded color
   * @return The color in Vec form (rgb)
   */
        Vec shade(int level, double weight, Vec P, Vec N, Vec I, Isect hit)
        {
            double n1, n2, eta, c1, cs2;
            Vec r;
            Vec tcol;
            Vec R;
            double t, diff, spec;
            Surface surf;
            Vec col;
            int l;

            col = new Vec();
            surf = hit.surf;
            R = new Vec();
            if (surf.shine > 1e-6)
            {
                R = SpecularDirection(I, N);
            }

            // Computes the effectof each light
            for (l = 0; l < lights.Length; l++)
            {
                L.sub2(lights[l].pos, P);
                if (Vec.dot(N, L) >= 0.0)
                {
                    t = L.normalize();

                    tRay.P = P;
                    tRay.D = L;

                    // Checks if there is a shadow
                    if (Shadow(tRay, t) > 0)
                    {
                        diff = Vec.dot(N, L) * surf.kd *
                          lights[l].brightness;

                        col.adds(diff, surf.color);
                        if (surf.shine > 1e-6)
                        {
                            spec = Vec.dot(R, L);
                            if (spec > 1e-6)
                            {
                                spec = Math.Pow(spec, surf.shine);
                                col.x += spec;
                                col.y += spec;
                                col.z += spec;
                            }
                        }
                    }
                } // if
            } // for

            tRay.P = P;
            if (surf.ks * weight > 1e-3)
            {
                tRay.D = SpecularDirection(I, N);
                tcol = trace(level + 1, surf.ks * weight, tRay);
                col.adds(surf.ks, tcol);
            }
            if (surf.kt * weight > 1e-3)
            {
                if (hit.enter > 0)
                    tRay.D = TransDir(null, surf, I, N);
                else
                    tRay.D = TransDir(surf, null, I, N);
                tcol = trace(level + 1, surf.kt * weight, tRay);
                col.adds(surf.kt, tcol);
            }

            // garbaging...
            tcol = null;
            surf = null;

            return col;
        }

        /**
   * Launches a ray
   */
        Vec trace(int level, double weight, Ray r)
        {
            Vec P, N;
            bool hit;

            // Checks the recursion level
            if (level > 6)
            {
                return new Vec();
            }

            hit = intersect(r, 1e6);
            if (hit)
            {
                P = r.point(inter.t);
                N = inter.prim.normal(P);
                if (Vec.dot(r.D, N) >= 0.0)
                {
                    N.negate();
                }
                return shade(level, weight, P, N, r.D, inter);
            }
            // no intersection --> col = 0,0,0
            return voidVec;
        }

/*
        public static void Main()
        {
            RayTracer rt = new RayTracer();

            // create the objects to be rendered 
            rt.scene = rt.createScene();

            // get lights, objects etc. from scene. 
            rt.setScene(rt.scene);

            // Set interval to be rendered to the whole picture 
            // (overkill, but will be useful to retain this for parallel versions)
            Interval interval = new Interval(0, rt.width, rt.height, 0, rt.height, 1);

            // Do the business!
            rt.render(interval);
        }
  
        */
    }



        

    public class JGFRayTracerBench : RayTracer
    {


        public void JGFsetsize(int size)
        {
            this.size = size;
        }

        public void JGFinitialise()
        {

            // set image size 
            width = height = datasizes[size];

            // create the objects to be rendered 
            scene = createScene();

            // get lights, objects etc. from scene. 
            setScene(scene);

            numobjects = scene.getObjects();
        }

        public void JGFapplication()
        {

            // Set interval to be rendered to the whole picture 
            // (overkill, but will be useful to retain this for parallel versions)
            Interval interval = new Interval(0, width, height, 0, height, 1);

            // Do the business!
            render(interval);


        }


        public void JGFvalidate()
        {
            long[] refval = { 2676692, 29827635 };
            long dev = checksum - refval[size];
            if (dev != 0)
            {
                System.Diagnostics.Debug.WriteLine("Validation failed");
                System.Diagnostics.Debug.WriteLine("Pixel checksum = " + checksum);
                System.Diagnostics.Debug.WriteLine("Reference value = " + refval[size]);
            }
        }

        public void JGFtidyup()
        {
            scene = null;
            lights = null;
            prim = null;
            tRay = null;
            inter = null;

            System.GC.Collect();
        }


        public void JGFrun(int size)
        {

            //JGFInstrumentor.addTimer("Section3:RayTracer:Total", "Solutions",size);
            //JGFInstrumentor.addTimer("Section3:RayTracer:Init", "Objects",size);
            //JGFInstrumentor.addTimer("Section3:RayTracer:Run", "Pixels",size);

            JGFsetsize(size);

            //JGFInstrumentor.startTimer("Section3:RayTracer:Total");

            JGFinitialise();
            JGFapplication();
            JGFvalidate();
            JGFtidyup();

            //JGFInstrumentor.stopTimer("Section3:RayTracer:Total");

            //JGFInstrumentor.addOpsToTimer("Section3:RayTracer:Init", (double) numobjects);
            //JGFInstrumentor.addOpsToTimer("Section3:RayTracer:Run", (double) (width*height));
            //JGFInstrumentor.addOpsToTimer("Section3:RayTracer:Total", 1);

            //JGFInstrumentor.printTimer("Section3:RayTracer:Init"); 
            //JGFInstrumentor.printTimer("Section3:RayTracer:Run"); 
            //JGFInstrumentor.printTimer("Section3:RayTracer:Total"); 
        }

        public static void Run()
        {

            JGFRayTracerBench rtb = new JGFRayTracerBench();
            rtb.JGFrun(0);

        }
    }
}
 
