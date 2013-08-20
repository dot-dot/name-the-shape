using System;
using System.Linq;

namespace nts.Models
{
    public class Quadrilateral : Shape
    {
        public Quadrilateral() : base(4)
        {
            
        }

        public Quadrilateral(LineSegment[] lines) : base(lines)
        {
            if (lines.Length != 4)
            {
                throw new Exception("Invalid Quadrilaterals");
            }
        }

        public Quadrilateral(SimplePoint[] points) : base(points)
        {
            if (points.Length != 4)
            {
                throw new Exception("Invalid Quadrilaterals");
            }
        }

        public override string GetShapeType()
        {
            if (!IsValidShape() || Lines.Length != 4)
            {
                return ShapeType = "Invalid Quadrilateral";
            }

            ShapeType = "Quadrilateral";

            //Determining the shape type by checking its characteristics
            //if the sides intersect with each other - Complex Quadrilaterals 
            if (Lines[0].IsLineSegmentIntersect(Lines[2]) || Lines[1].IsLineSegmentIntersect(Lines[3]))
            {
                return ShapeType = "Complex Quadrilaterals";
            }

            var diagonalLine1 = new LineSegment { Coordinates = new[] { Points[0], Points[2] } };
            var diagonalLine2 = new LineSegment { Coordinates = new[] { Points[1], Points[3] } };

            //if its diagonals don't intersect - Concave Quadrilateral
            if (!diagonalLine1.IsLineSegmentIntersect(diagonalLine2))
            {
                return ShapeType = "Concave Quadrilateral";
            }

            var totalParallel = TotalParallelSides();

            //if it has 2 parallel sides, it would be either a Square, Rectangle, Rhombus or Parallelogram
            if (totalParallel == 2)
            {
                double angle = Math.Round(Lines[0].GetAngle(Lines[1]), 2);
                var isEqualSides = (Lines[0].Length == Lines[1].Length);
                if (angle == 90.00 || angle == 270)
                {                    
                    if (isEqualSides)
                    {                 
                        return ShapeType = "Square";
                    }
                    return ShapeType = "Rectangle";
                }

                if (isEqualSides)
                {
                    return ShapeType = "Rhombus";
                }
                return ShapeType = "Parallelogram";
            }

            if (IsKite())
            {
                return ShapeType = "Kite";
            }


            if (totalParallel == 1)
            {
                return ShapeType = "Trapezoid - (UK: Trapezium)";
            }

            //can't determine the Quadrilateral
            return ShapeType;
        }

        private bool IsKite()
        {
            /*
             a kite is a quadrilateral whose four sides can be grouped into two pairs of equal-length sides that are adjacent to each other. 
             In contrast, a parallelogram also has two pairs of equal-length sides, but they are opposite each other rather than adjacent.            
            */
            var line = Lines.First();
            var isAdjacentLinesSameLength = GetAdjacentLines(line).Any(l => l.Length == line.Length);
            if (!isAdjacentLinesSameLength) return false;

            var nonAdjacentSide = GetNonAdjacentLines(line).First();
            var isSameLength = GetAdjacentLines(nonAdjacentSide).Any(l => l.Length == nonAdjacentSide.Length);
            if (!isSameLength) return false;
            
            return true;
        }

        private int TotalParallelSides()
        {
            int total = 0;

            if (Lines[0].IsParallel(Lines[2]))
            {
                total++;
            }
            if (Lines[1].IsParallel(Lines[3]))
            {
                total++;
            }
            return total;
        }

    }
}