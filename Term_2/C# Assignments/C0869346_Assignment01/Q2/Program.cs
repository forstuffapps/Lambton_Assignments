using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // From this I ahve picked the Grading Potatoes program

            // Asking for the weight of the potato
            Console.WriteLine("Enter the weight of the potato :");
            double weight = Convert.ToDouble(Console.ReadLine());

            // Main Logic : Gradin teh potato based on the weight
            if (weight < 200)
            {
                Console.WriteLine("Grade is X");
            }
            else if (weight >= 200 && weight < 400)
            {
                Console.WriteLine("Grade is A");
            }
            else if (weight >= 400 && weight < 800)
            {
                Console.WriteLine("Grade is B");
            }
            else if (weight >= 800)
            {
                Console.WriteLine("Grade is Z");
            }
        }
    }
}
