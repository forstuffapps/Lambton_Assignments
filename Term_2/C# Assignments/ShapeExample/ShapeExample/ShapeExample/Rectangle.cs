using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03
{
    public class Rectangle : Parallelogram
    {
        /* No extra fields are required for this class 
         * we will use xCoordinate, yCoordinate, side1Length, 
         * side2Length, angleAC, and angleBD from parent classes
         */

        /* TODO: Add the Four arguemnt constructor */
        public Rectangle(double xCoordinate, double yCoordinate, double length, double width) : base(xCoordinate, yCoordinate, length, width,90, 90)
        {}
        /* HINT: Use base() to call Parallelogram's constructor */


        /* TODO: Add a copy Constructor */
        public Rectangle(Rectangle rectToCopy) : this(rectToCopy.xCoordinate, rectToCopy.yCoordinate, rectToCopy.side1Length, rectToCopy.side2Length) 
        { }


        /* TODO: Override the Clone() method */
        public override object Clone()
        {
            return new Rectangle(this);
        }


        /* TODO: Override the ToString method */

        public override string ToString()
        {
            return "Shape : Rectangle" + base.ToString() +
                   String.Format("Centre Cordinate ({0:F2} , {1:F2})",
                                this.xCoordinate, this.yCoordinate) + 
                    String.Format("Angle AC {0:F2} \n Length : {1:F2} \nWidth : {2:F2}",angleAC,side1Length,side2Length);
        }

        /* TODO: Add all required getter and setter methods below*/
        public virtual void SetLength(double l)
        {
            this.side1Length = l;
        }

        public void SetWidth(double w)
        {
            this.side2Length = w;
        }

        public double GetLength()
        {
            return this.side1Length;
        }

        public double GetWidth()
        {
            return this.side2Length;
        }

    }
}
