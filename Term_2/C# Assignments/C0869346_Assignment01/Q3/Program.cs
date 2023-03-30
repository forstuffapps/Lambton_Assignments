using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Declaring the Repeat variable to handling the program, to make it run multiple times
            string Repeat;

            // Creating a Do while : Main Logic
            do
            {

                // Declaring the Movie Info
                Console.WriteLine("Welcome to our Multiplex");
                Console.WriteLine("We are presently showing:");
                Console.WriteLine("1. Rush (15)");
                Console.WriteLine("2. How I Live Now (15)");
                Console.WriteLine("3. Thor: The Dark World (12A)");
                Console.WriteLine("4. Filth (18)");
                Console.WriteLine("5. Planes (U)");



                // Declaring the varibale to handle the kovie choice 
                int Movie_Choice;
                // Writing a sub do while loop to handle the invalid inputs of the mOvie choice
                do
                {
                    Console.WriteLine("Enter the number of the film");
                    Movie_Choice= int.Parse(Console.ReadLine());
                    if ((Movie_Choice< 1) || (Movie_Choice> 5))
                        Console.WriteLine("Invalid input");
                } while ((Movie_Choice< 1) || (Movie_Choice> 5));



                // Declaring the varibale to hold the age
                int Age_Number;
                // Writing a sub do while loop to handle the Invalid input of age
                do
                {
                    Console.WriteLine("Enter your Age_Number:");
                    Age_Number = int.Parse(Console.ReadLine());
                    if (Age_Number < 5 || Age_Number > 120)
                        Console.WriteLine("Invalid Age_Number .Range is 5 and 120");
                } while (Age_Number < 5 || Age_Number > 120);



                // Conditional cases for the eligible criteria
                if ((Movie_Choice== 1) && (Age_Number < 15))
                {
                    Console.WriteLine("Access denied");
                }
                else if ((Movie_Choice== 2) && (Age_Number < 15))
                {
                    Console.WriteLine("Access denied");
                }
                else if ((Movie_Choice== 3) && (Age_Number < 12))
                {
                    Console.WriteLine("Access denied");
                }
                else if ((Movie_Choice== 4) && (Age_Number < 18))
                {
                    Console.WriteLine("Access denied");
                }
                else
                {
                    Console.WriteLine("Enjoy");
                }

                // askingfor another customers
                Console.WriteLine("Another customer? (Y or N):");
                Repeat = Console.ReadLine();
            }
            while (Repeat == "Y");

        }
    }
}
