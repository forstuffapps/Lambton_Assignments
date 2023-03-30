using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    internal class Program
    {
        // Declaring this boolean type method
        static bool isValid(string F_Parameter)
        {
            F_Parameter = F_Parameter.Trim();
            if (F_Parameter.EndsWith("(18)") || F_Parameter.EndsWith("(U)") || F_Parameter.EndsWith("(12A)") || F_Parameter.EndsWith("(15)") || F_Parameter.EndsWith("(12)"))
            {
                return true;
            }
            return false;
        }

        // Declaring This Read nUmebr method
        static int ReadNumber(string prompt, int min, int max)
        {
            int Res = 0;
            do
            {
                Console.Write(prompt);
                string Number_String = Console.ReadLine();
                Res = int.Parse(Number_String);
                if (Res > max && Res < max)
                    Console.WriteLine("Please enter a value in the range " +
                    min + " to " + max);
                else
                    break;
            } while (true);
            return Res;

        }
        static void Main(string[] args)
        {
            // Repeat String for the asking the user incase if he wants to repeat this action
            string Repeat;
            do
            {
                Console.WriteLine("Enter the number of films");
                int n = int.Parse(Console.ReadLine());
                string[] names = new string[n];
                for (int k = 0; k < n; k = k + 1)
                {
                    int disp = k + 1;
                    Console.Write("Enter the name " + disp + ": ");
                    names[k] = Console.ReadLine();
                    while (!isValid(names[k]))
                    {
                        Console.Write("Invalid film name");
                        names[k] = Console.ReadLine();
                    }
                }
                for (int k = 0; k < names.Length; k = k + 1)
                {
                    int disp = k + 1;
                    Console.WriteLine(disp + " :" + names[k]);
                }
                int Number = ReadNumber("Enter the number of the", 1, names.Length);
                Console.WriteLine("Film number " + Number + " chosen");
                int Age_Number = ReadNumber("Enter your age: ", 5, 120);
                Console.WriteLine("Age entered " + Age_Number);
                var Index = Number - 1;
                if (names[Index].EndsWith("(12A)") && Age_Number < 12)
                {
                    Console.WriteLine("Access denied");
                }
                else if (names[Index].EndsWith("(15)") && Age_Number < 15)
                {
                    Console.WriteLine("Access denied");
                }
                else if (names[Index].EndsWith("(12)") && Age_Number < 12)
                {
                    Console.WriteLine("Access denied");
                }
                else if (names[Index].EndsWith("(18)") && Age_Number < 18)
                {
                    Console.WriteLine("Access denied");
                }
                else
                {
                    Console.WriteLine("Enjoy");
                }
                Console.WriteLine("Another customer? (Y or N):");
                Repeat = Console.ReadLine();
            }
            while (Repeat == "Y");
        }
    }
}
