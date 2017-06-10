//Bryce Ault
//Dr. Yoo Visual Studio OLA 5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ault_hwk7VisualStudio
{
    class Program
    {
        //base class
        abstract class Shape : IComparable
        {
            //default constructor
            public Shape()
            { Name = ""; }

            //name var for all classes
            //to inherit
            public string Name;
            public int x;
            public int y;
            public bool is3d;

            //for printing data
            public abstract string ToString();

            //area & volume
            public abstract double Area();
            public abstract double Volume();

            //compare
            public int CompareTo(object obj)
            {
                Shape otherShape = obj as Shape;

                //if x values are not equal
                if (this.x != otherShape.x)
                    return this.x.CompareTo(otherShape.x);

                //compare y values if x values are same
                else
                    return this.y.CompareTo(otherShape.y);
            }
        }

        //child class of shape
        //base class for 2D shapes
        abstract class TwoDimensionalShape : Shape
        {
            //default constructor
            public TwoDimensionalShape() { }

            //variables for 2D shapes
            public int cradius;
            public int sside;
            
            
        }

        //child class of shape
        //base class for 3D shapes
        abstract class ThreeDimensionalShape : Shape
        {
            //default constructor
            public ThreeDimensionalShape() { }

            //variables for 3D shapes
            public int cside;
            public int sradius;


        }

        //Circle class
        //child class of 2D shapes
        class Circle : TwoDimensionalShape
        {
            //constructor which takes 3 parameters
            //and initializes name to Circle
            public Circle(int first, int second, int r)
            { Name = "Circle"; cradius = r; x = first; y = second; is3d = false; }

            //override Area() to calculate
            //area of a circle
            public override double Area()
            {  return (cradius * cradius)*(3.14159);  }

            public override string ToString()
            { return string.Format("[{0},{1}] radius: {2}", x, y, cradius);  }

            //return 0 cause won't use function
            public override double Volume()
            { return 0;            }
        }

        //Shape class
        //child class of 2D shapes
        class Square : TwoDimensionalShape
        {
            //constructor which takes 3 parameters
            //and initializes name to Square
            public Square(int first, int second, int s)
            { Name = "Square"; sside = s; x = first; y = second; is3d = false; }

            //override Area() to calculate
            //area of a square
            public override double Area()
            {  return (sside * sside);  }

            public override string ToString()
            { return string.Format("[{0},{1}] radius: {2}", x, y, sside); }

            //return 0 cause won't use function
            public override double Volume()
            { return 0; }
        }

        //Sphere class
        //child class of 3D shapes
        class Sphere : ThreeDimensionalShape
        {

            //constructor which takes 3 parameters
            //and initializes name to Sphere
            public Sphere(int first, int second, int r)
            { Name = "Sphere"; sradius = r; x = first; y = second; is3d = true; }

            //override Volume() to calculate
            //volume of a sphere
            public override double Volume()
            {  return ((4/3)*(3.14159)*(sradius * sradius));   }

            //override Area() to calculate
            //area of a sphere
            public override double Area()
            { return (4 * 3.14159 * sradius * sradius); }

            public override string ToString()
            { return string.Format("[{0},{1}] radius: {2}", x, y, sradius); }
        }

        //Cube class
        //child class of 3D shapes
        class Cube : ThreeDimensionalShape
        {
            //constructor which takes 3 parameters
            //and initializes name to Cube
            public Cube(int first, int second, int s)
            { Name = "Cube";  cside = s; x = first; y = second; is3d = true; }

            //override Volume() to calculate
            //volume of a cube
            public override double Volume()
            {  return (cside * cside * cside);  }

            //override Area() to calculate
            //area of a cube
            public override double Area()
            { return (6 * cside * cside); }

            public override string ToString()
            { return string.Format("[{0},{1}] radius: {2}", x, y, cside); }
        }

        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[4];

            shapes[0] = new Circle(22, 88, 4);

            shapes[1] = new Square(71, 96, 10);

            shapes[2] = new Sphere(8, 89, 2);

            shapes[3] = new Cube(79, 61, 8);

            //sort array
            Array.Sort(shapes);

            // call method ToString on circle 

            //loop through array and print
            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine("{0}: {1}", shapes[i].Name, shapes[i].ToString());


                Console.WriteLine("{0}'s area is {1}",

                      shapes[i].Name, shapes[i].Area());

                //if 3d shape
                //print volume
                if (shapes[i].is3d == true)
                    Console.WriteLine("{0}'s volume is {1}",

                  shapes[i].Name, shapes[i].Volume());
                Console.WriteLine();
            }
        }
    }
}
