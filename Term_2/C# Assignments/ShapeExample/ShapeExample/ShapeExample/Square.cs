using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03
{
    public class Square : Rectangle
    {

        /* No extra fields are required for this class 
         * we will use xCoordinate, yCoordinate, side1Length, 
         * side2Length, angleAC, and angleBD from parent classes
         */

        /* TODO: Add the Three arguemnt constructor */
        /* HINT: Use base() to call Rectangle's constructor */

        public Square(double xCoordinate, double yCoordinate, double length) :
                        base(xCoordinate, yCoordinate, length, length)
        { }


        /* TODO: Add a copy Constructor */
        public Square(Square squareToCopy) : this(squareToCopy.xCoordinate, squareToCopy.yCoordinate, squareToCopy.side1Length) { }


        /* TODO: Override the Clone() method */
        public override object Clone()
        {
            return new Square(this);
        }

        /* TODO: Override the ToString method */
        public override string ToString()
        {
            return "Shape : Square" + base.ToString() +
                   String.Format("Centre Cordinate ({0:F2} , {1:F2})",
                                this.xCoordinate, this.yCoordinate) +
                    String.Format("Angle AC {0:F2} \n Length : {1:F2}", angleAC, side1Length);

        }

        /* TODO: Add all required getter and setter methods below*/
        public override void SetLength(double l)
        {
            this.side1Length = l;
            this.side2Length = l;
        }
       /* get length is same as Parent */
    }
}
