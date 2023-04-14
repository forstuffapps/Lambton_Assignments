using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03
{
    public class Circle : Ellipse
    {
       public Circle(double x, double y, double radius)
            : base (x, y, radius, radius)
        {}

        public Circle(Circle crl) : base(crl)
        {

        }

        public override object Clone()
        {
            return new Circle(this);
        }

        public override bool Equals(Object obj)
        {
            if(obj != null && obj is Circle)
            {
                Circle crl = (Circle)obj;
                return base.Equals(crl);
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format("Centre Coordinate ({0} , {1})\nRadius: {2}",
                this.xCoordinate, this.yCoordinate, this.majorAxis);
        }

        public double GetRadius()
        {
            return this.majorAxis;
        }

        public void SetRadius(double radius)
        {
            this.majorAxis = radius;
            this.minorAxis= radius;
        }

        public override void SetMajorAxis(double radius)
        {
            this.SetRadius(radius);
        }

        public override void SetMinorAxis(double radius)
        {
            this.SetRadius(radius);
        }
    }
}
