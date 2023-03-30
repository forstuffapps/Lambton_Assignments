using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C0869346_Assignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Defining the Movie list
            Console.WriteLine("Welcome to our Multiplex");
            Console.WriteLine("We are presently showing:");
            Console.WriteLine("1. Rush (15)");
            Console.WriteLine("2. How I Live Now (15)");
            Console.WriteLine("3. Thor: The Dark World (12A)");
            Console.WriteLine("4. Filth (18)");
            Console.WriteLine("5. Planes (U)");

            // Asking your for the movie choice
            Console.WriteLine("Enter the number of the film you wish to see: ");
            int Movie_Choice = Convert.ToInt32(Console.ReadLine());

            //Asking the user for his age
            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            /*
             * Main Logic of the PRogram
             * Which invloves the if conditions ans else conditions to check 
             * if the user has valid age to watch the movie
             * and writing an opposite case where if he is not eligible
             */
            if (Movie_Choice == 1 && age >= 15)
            {
                Console.WriteLine("Enjoy the film");
            }
            else if (Movie_Choice == 2 && age >= 15)
            {
                Console.WriteLine("Enjoy the film");

            }
            else if (Movie_Choice == 3 && age >= 12)
            {
                Console.WriteLine("Enjoy the film");

            }
            else if (Movie_Choice == 4 && age >= 18)
            {
                Console.WriteLine("Enjoy the film");
            }
            else if (Movie_Choice == 5)
            {
                Console.WriteLine("Enjoy the film");
            }
            else
            {
                Console.WriteLine("Access Denied - You are too young");
            }
        }
    }
}
