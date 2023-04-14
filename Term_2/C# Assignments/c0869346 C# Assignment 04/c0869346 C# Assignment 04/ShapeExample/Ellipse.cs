using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* c0869346 - Vishal Reddy Guda  */

namespace Assignment03
{
    public class Ellipse : Shape
    {
        /* Ellipse shapes (i.e. ovals) have major and minor axis */
        protected double majorAxis;
        protected double minorAxis;
        public Ellipse(double x, double y, double majorAxis, double minorAxis) : base(x, y)
        {
            this.majorAxis = majorAxis;
            this.minorAxis = minorAxis;
        }

        /* Copy Constructor */
        public Ellipse(Ellipse elp): base(elp)
        {
            this.majorAxis = elp.majorAxis;
            this.minorAxis = elp.minorAxis;
        }

        /* replace the Clone method from Shape */
        public override object Clone()
        {
            return new Ellipse(this);
        }

        public override bool Equals(object obj)
        {
            if(obj != null && obj is Ellipse)
            {
                Ellipse elp = (Ellipse)obj;
                return base.Equals(elp) && this.majorAxis == elp.majorAxis &&
                    this.minorAxis == elp.minorAxis;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + 
                String.Format("\nMajor Axis: {0}\nMinor Axis: {1}", 
                this.majorAxis, this.minorAxis);
        }

        public virtual void SetMajorAxis(double majorAxis)
        {
            this.majorAxis= majorAxis;
        }

        public double GetMajorAxis()
        {
            return this.majorAxis;
        }

        public virtual void SetMinorAxis(double minorAxis)
        {
            this.minorAxis = minorAxis;
        }

        public double GetMinorAxis()
        {
            return this.minorAxis;
        }

        //formula to calculate area of ellipse/oval
        public override double CalcArea()
        {
            return Math.PI * this.majorAxis * this.minorAxis;
        }

        public override double CalcPerimeter()
        {
            double h = Math.Pow(this.majorAxis - this.minorAxis, 2) / 
                Math.Pow(this.majorAxis + this.minorAxis, 2);
            double p = Math.PI * (this.majorAxis + this.minorAxis) *
                (1 + (3 * h / (10 + Math.Sqrt(4 - 3 * h))));
            return p;
        }
    }
}
