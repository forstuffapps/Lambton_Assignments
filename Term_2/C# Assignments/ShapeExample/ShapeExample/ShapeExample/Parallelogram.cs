using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* c0869346 - Vishal Reddy Guda  */

namespace Assignment03
{
    public class Parallelogram : Shape
    {
        protected double side1Length;
        protected double side2Length;
        protected double angleAC;
        protected double angleBD;


        /* TODO: Add the six argument constructor */
        /* HINT: Use base()to call Shape's constructor */
        public Parallelogram(double x, double y, double side1Length, double side2Length,double angleAC,  double angleBD) : base(x,y)
        {
            this.side1Length = side1Length;
            this.side2Length = side2Length;
            this.angleAC = angleAC;
            this.angleBD = angleBD;
        }

        /* TODO: Add a copy Constructor */
        public Parallelogram(Parallelogram parallelogramToCopy) :
            this(parallelogramToCopy.xCoordinate, parallelogramToCopy.yCoordinate, parallelogramToCopy.side1Length, parallelogramToCopy.side2Length, parallelogramToCopy.angleAC,parallelogramToCopy.angleBD)
        { }

        /* TODO: Override the Clone() method */
        public override object Clone()
        {
           return new Parallelogram(this);
        }


        /* TODO: Override the ToString method */
        public override string ToString()
        {
            return "Shape : Parallelogram " + base.ToString() +
                    String.Format("\nAngle AC : {0:F2} \nAngle BD : {1:F2} \n" + 
                    "Side 1 length : {2 :F2} \n Side 2 length : {3:F2}", angleAC,angleBD,side1Length,side2Length);
        }

        /* Override equals*/
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Parallelogram)
            {
                Parallelogram pr1 = this;
                Parallelogram pr2 = (Parallelogram)obj;
                return pr1.xCoordinate == pr2.xCoordinate
                    && pr1.yCoordinate == pr2.yCoordinate
                    && pr1.side1Length == pr2.side1Length
                    && pr1.side2Length == pr2.side2Length
                    && pr1.angleAC == pr2.angleAC
                    && pr1.angleBD == pr2.angleBD;
            }
            return false;
        }



        public override double CalcArea()
        {
            //TODO: Implement CalcArea for Parallelogram
            //Use Shape.ToRadians() to convert degrees to Radian units
            return (side1Length * side2Length)* Math.Sin(Shape.ToRadians(angleBD));
        }

        public override double CalcPerimeter()
        {
            //TODO: Implement CalcPerimeter for Parallelogram
            return (side1Length + side2Length) * 2;
        }

        public void SetSideLength1(double sideLength1)
        {
            this.side1Length = sideLength1;
        }
        public void SetSideLength2(double sideLength2)
        {
            this.side2Length = sideLength2;
        }

        public double GetSideLength1()
        {
            return side1Length;
        }
        public double GetSideLength2()
        {
            return side2Length;
        }
        public void SetAngles(double ac, double bd)
        {
            this.angleAC = ac;
            this.angleBD = bd;
        }
        public double GetAngleAC()
        {
            return this.angleAC;
        }

        public double GetAngleBD()
        {
            return this.angleBD;
        }
    }
}
