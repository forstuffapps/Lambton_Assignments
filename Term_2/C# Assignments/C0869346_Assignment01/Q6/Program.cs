using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Declaring the Word file
            string file = "words.txt";

            // Declarin the Max Vowel count varibalre to stor ethe max and Temp counter to count for each and every word
            int Max_Vowel_Count = 0, Temp_Counter = 0;

            // For loop for reading the contentc of the file
            foreach (string line in System.IO.File.ReadLines(file))
            {

                Temp_Counter = 0;
                foreach (char s in line)
                {
                    if (s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u' || s == 'A' || s == 'E' || s == 'I' || s == 'O' || s == 'U')
                    {
                        Temp_Counter++;
                    }
                }

                // Updating the max counetr while checking for every word
                if (Max_Vowel_Count < Temp_Counter)
                {
                    Max_Vowel_Count = Temp_Counter;
                }
            }

            Console.Write("\n The largest number of vowels in any one word is : {0}\n", Max_Vowel_Count);

        }
    }
}
