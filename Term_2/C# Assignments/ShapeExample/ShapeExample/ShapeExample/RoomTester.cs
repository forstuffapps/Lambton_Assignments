using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* c0869346 - Vishal Reddy Guda  */

namespace Assignment03
{
   
        public class RoomTester
        {

            public static void Main(String[] args)
            {

                double totalArea = 0;
                double totalPerimeter = 0;

                double trimCostPerMeter = 0;
                double carpetCostPerSqrMeter = 0;

                double totalCarpetCost = 0;
                double totalTrimCost = 0;
                double totalCost = 0;

                Console.WriteLine("Please enter the cost of carpert per square meter: $");
                carpetCostPerSqrMeter = Double.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the cost of wooden trim per meter: $");
                trimCostPerMeter = Double.Parse(Console.ReadLine());

                Room[] house = new Room[5]; //A house consists of rooms
                Room[] copyHouse = new Room[5]; //copy

                Circle circle1 = new Circle(0, 0, 5);
                Room cellar = new Room("Cellar", circle1);
                house[0] = cellar;

                Shape oval1 = new Ellipse(3, 2, 10, 5);
                Room ovalOffice = new Room("Oval Office", oval1);
                house[1] = ovalOffice;

                Parallelogram prlg = new Parallelogram(5, 5, 10, 3, 60, 120);
                Room bedroom = new Room("Master Bedroom", prlg);
                house[2] = bedroom;

                Rectangle rct = new Rectangle(7, 7, 10, 20);
                Room kitchen = new Room("Main Floor - Kitchen", rct);
                house[3] = kitchen;

                Square sqr = new Square(10, 10, 6);
                Room bathroom = new Room("Bathroom", sqr);
                house[4] = bathroom;

                //This loop ensures our clone methods work properly
                for (int i = 0; i < house.Length; i++)
                {
                    copyHouse[i] = (Room)house[i].Clone();
                }

                Console.WriteLine("\n*******ROOMS********");
                foreach(Room rm in copyHouse)
                {
                    totalArea += rm.GetArea();
                    totalPerimeter += rm.GetPerimeter();
                    Console.WriteLine(rm); //calls toString()
                    Console.WriteLine("Area:{0} sqaured meters\n", rm.GetArea());
                    Console.WriteLine("Perimeter:{0} meters\n", rm.GetPerimeter());
                   Console.WriteLine("********************");
                }

                totalCarpetCost = totalArea * carpetCostPerSqrMeter;
                totalTrimCost = totalPerimeter * trimCostPerMeter;
                totalCost = totalCarpetCost + totalTrimCost;

                Console.WriteLine("\n*******TOTALS*******");
                Console.WriteLine(String.Format("Carpet Required: {0} squared meters", totalArea));
                Console.WriteLine(String.Format("Trim Required: {0} meters", totalPerimeter));

                Console.WriteLine("\n*******COST*********");
                Console.WriteLine(String.Format("Carpet Cost: {0:F2}", totalCarpetCost));
                Console.WriteLine(String.Format("Trim Cost: {0:F2}", totalTrimCost));
                 Console.WriteLine(String.Format("Total Cost: {0:F2}", totalCost));
            Console.ReadLine();
            }

    }
}
