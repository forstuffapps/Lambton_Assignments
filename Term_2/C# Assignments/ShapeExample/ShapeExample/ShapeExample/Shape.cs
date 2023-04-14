using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03
{
    public abstract class Shape : ICloneable
    {
        /* Centre coordinate of Shape on 2D plane specified as (x,y) coordinate*/
        protected double xCoordinate;
        protected double yCoordinate;

        /*
         * Two argument constructor that sets centre coordinate of Shape
         * x - Centre x coordinate on a 2D place
         * y - Centre y coordinate on a 2D place
         */
        public Shape(double x, double y)
        {
            this.xCoordinate = x;
            this.yCoordinate = y;
        }

        /* Copy Constructor */
        public Shape(Shape shapeToCopy)
        {
            this.xCoordinate = shapeToCopy.xCoordinate;
            this.yCoordinate = shapeToCopy.yCoordinate;
        }

        //All Shapes will implement a Clone method that simply return
        //a Deep copy of "this" object
        public virtual object Clone()
        {
            return this.Clone(); //call the appropraite Shape's Clone method
        }

        public void SetCentreX(double x) { this.xCoordinate = x; }

        public void SetCentreY(double y) { this.xCoordinate = y; }

        public override string ToString()
        {
            return String.Format("Centre Cordinate ({0} , {1})",
                this.xCoordinate, this.yCoordinate);
        }

        /* Override Object's default equals method */
        public override bool Equals(object obj)
        {
            if(obj != null && obj is Shape)
            {
                Shape shp1 = this;
                Shape shp2 = (Shape)obj;
                return shp1.Equals(shp2);
            }
            return false;
        }

        public abstract double CalcArea();

        public abstract double CalcPerimeter();

        public static double ToRadians(double angleInDegrees)
        {
            return Math.PI * angleInDegrees / 180.0;
        }

    }
}
