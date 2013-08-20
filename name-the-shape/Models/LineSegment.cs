using System;
using System.Drawing;
using System.Linq;

namespace nts.Models
{
    public class LineSegment
    {
        public SimplePoint[] Coordinates;

        public LineSegment()
        {
            Coordinates = new []{ new SimplePoint(), new SimplePoint()};
        }

        public int X1
        {
            get { return Coordinates[0].X; }
            set { Coordinates[0].X = value; }
        }

        public int Y1
        {
            get { return Coordinates[0].Y; }
            set { Coordinates[0].Y = value; }
        }

        public int X2
        {
            get { return Coordinates[1].X; }
            set { Coordinates[1].X = value; }
        }

        public int Y2
        {
            get { return Coordinates[1].Y; }
            set { Coordinates[1].Y = value; }
        }

        public double Length { get; set; }

        public bool IsParallel(LineSegment lineA)
        {
            /*              
                Ax+By=C - (x1, y1) and (x2, y2), 
                A = y2-y1
                B = x1-x2
                C = A*x1+B*y1             
             */
            var a1 = lineA.Y2 - lineA.Y1;
            var b1 = lineA.X2 - lineA.X1;           

            var a2 = Y2 - Y1;
            var b2 = X2 - X1;            

            var det = a1 * b2 - a2 * b1;

            return det == 0;
        }

        public bool IsLineSegmentIntersect(LineSegment lineA)
        {
            var a = new SimplePoint(X1 - lineA.X1, Y1 - lineA.Y1);
            var b = new SimplePoint(lineA.X2 - lineA.X1, lineA.Y2 - lineA.Y1);
            var c = new SimplePoint(X2 - X1, Y2 - Y1);

            var ab = a.X * b.Y - a.Y * b.X;
            var ac = a.X * c.Y - a.Y * c.X;
            var bc = b.X * c.Y - b.Y * c.X;

            if (ab == 0)
            {
                // Lines are collinear, and so intersect if they have any overlap
                return ((X1 - lineA.X1 < 0) != (X1 - lineA.X2 < 0))
                       || ((Y1 - lineA.Y1 < 0) != (Y1 - lineA.Y2 < 0));
            }

            if (bc == 0)
                return false; // Lines are parallel.

            float d = 1f / bc;
            float e = ac * d;
            float f = ab * d;

            return (e >= 0f) && (e <= 1f) && (f >= 0f) && (f <= 1f);
        }
        

        public double CalculateLength()
        {
            var x = Math.Pow(X2 - X1, 2);
            var y = Math.Pow(Y2 - Y1, 2);

            return Math.Sqrt(x + y);
        }


        public double GetAngle(LineSegment line1)
        {
            /*
            let:
            line1 = (x1,y1), (x2,y2)
            line2 = (x1,y1), (x3, y3)
            
            line3  = (x2,y2), (x3,y3)
            */
            var sharedPoint = line1.Coordinates.Intersect(Coordinates).FirstOrDefault();

            if (sharedPoint == null)
            {
                throw new Exception("Lines do not intersect");
            }

            if (line1.Length == 0 && Length == 0)
            {
                throw new Exception("Lines do have length");
            }

            //find the line3
            var line3 = new LineSegment();
            line3.Coordinates[0] = line1.Coordinates.First(point => !point.Equals(sharedPoint));
            line3.Coordinates[1] = Coordinates.First(point => !point.Equals(sharedPoint));
            line3.Length = line3.CalculateLength();

            var a = Math.Pow(line1.Length, 2) + Math.Pow(Length, 2) - Math.Pow(line3.Length, 2);
            var b = 2 * line1.Length * Length;
            return RadianToDegree(Math.Acos(a / b));
        }

        //convert from radian to degree
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
        
    }
}