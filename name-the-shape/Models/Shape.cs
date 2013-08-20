using System;
using System.Collections.Generic;
using System.Linq;

namespace nts.Models
{
    public class Shape
    {
        private SimplePoint[] _points;
        public SimplePoint[] Points
        {
            get { return _points; }
            set
            {
                _points = value;
                PopulateLines();
            }
        }

        public LineSegment[] Lines { get; set; }

        public int TotalSide
        {
            get { return Points.Length; }
        }

        public string ShapeType { get; set; }

        //note: should check if points are within lines
        // (eg: (1,1), (4,1), (3,1)) should be illegal...

        public Shape() 
        {
            
        }

        public Shape(int totalSides)
        {           
            Points = new SimplePoint[totalSides];            
            Lines = new LineSegment[totalSides];
        }

        public Shape(SimplePoint[] points )
        {            
            Points = points;           
        }

        public Shape(LineSegment[] lines)
        {
            Points = GetPoints(lines);

            if (Points.Length != lines.Length)
            {
                throw new Exception("Invalid Shape");
            }
        }

        public bool IsValidShape()
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                var line = Lines[i];
                var nextLine = (i == (Lines.Length - 1)) ? Lines[0] : Lines[i + 1];

                if (line.IsParallel(nextLine))
                {
                    return false;
                }                
            }
            return true;
        }

        public virtual string GetShapeType()
        {
           if (!IsValidShape())
           {
               return "Invalid Shape";
           }
            return "A Shape";
        }
        
        private void PopulateLines()
        {
            Lines = new LineSegment[TotalSide];

            for (int i = 0; i < Points.Length; i++)
            {
                var line = Lines[i] ?? (Lines[i] = new LineSegment());

                line.X1 = Points[i].X;
                line.Y1 = Points[i].Y;

                var nextPoint = (i == (Points.Length - 1)) ? Points[0] : Points[i + 1];
                line.X2 = nextPoint.X;
                line.Y2 = nextPoint.Y;

                line.Length = line.CalculateLength();
            }                
        }
                        
        public IEnumerable<LineSegment> GetAdjacentLines(LineSegment line)
        {
            return
                Lines.Where(
                    l => l.Coordinates.Any(point => point.Equals(line.Coordinates[0])) ^ 
                        l.Coordinates.Any(point => point.Equals(line.Coordinates[1])));          
        }

        public IEnumerable<LineSegment> GetNonAdjacentLines(LineSegment line)
        {
            return
                Lines.Where(
                    l => !(l.Coordinates.Any(point => point.Equals(line.Coordinates[0])) || 
                        l.Coordinates.Any(point => point.Equals(line.Coordinates[1]))));
        }
       
        public static SimplePoint[] GetPoints(LineSegment[] lines)
        {

            var points = new List<SimplePoint>();            
            var currentLine = lines.First();

            points.AddRange(currentLine.Coordinates);
            
            for (int i = 1; i < lines.Length; i++)
            {
                var nextLine = lines.First(
                l => l.Coordinates[0].Equals(currentLine.Coordinates[1]));

                if (nextLine != null && !points.Contains(nextLine.Coordinates[1]))
                {
                    points.Add(nextLine.Coordinates[1]);
                }

                currentLine = nextLine;
            }

            return points.ToArray();
        }
    }       
}