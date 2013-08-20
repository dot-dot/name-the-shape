using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nts.Models
{

    public class SimplePoint
    {        
        public int X, Y;

        public SimplePoint()
        {           
        }

        public SimplePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SimplePoint) obj);
        }

        protected bool Equals(SimplePoint other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

    }   
}