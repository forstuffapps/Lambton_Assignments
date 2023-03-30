using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring the Sart character
            const string STAR = "*";

            // Declaring teh COnstant for Store count
            const int STORE_COUNT = 5;

            // Count variable
            int count = 0;

            // seclaring the variable for teh sales amount
            int Sales_Amount = 0;

            // Declaring the sales array for store count
            int[] sales = new int[STORE_COUNT];

            // declaring the temp variable fr  the temp count
            string Temp_Variable = "";

            // Declarind the new start array for storing the answers
            string[] Star_Array = new String[STORE_COUNT];


            // For loop for handling the invalid inputs
            for (count = 0; count < STORE_COUNT; count++)
            {
                Console.WriteLine("Enter today's sales for store " + (count + 1) + ":");
                Sales_Amount = Convert.ToInt32(Console.ReadLine());
                while (Sales_Amount < 0)
                {
                    Console.WriteLine("Sales amount must be above positive only");
                    Console.WriteLine("Enter today's sales for store " + (count + 1) + ":");
                    Sales_Amount = Convert.ToInt32(Console.ReadLine());
                }
                sales[count] = Sales_Amount / 100;
            }

            // Printingthe sales bar chart
            Console.WriteLine("SALES BAR CHART ");
            for (count = 0; count < STORE_COUNT; count++)
            {
                Temp_Variable = "";

                for (int j = 0; j < sales[count]; j++)
                {
                    Temp_Variable += STAR;
                }

                Star_Array[count] = Temp_Variable;
                Console.WriteLine("Store " + (count + 1) + ":" + Star_Array[count]);


            }
        }
    }
}
