using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Declarin the Choices
            string[] choice = { "rock", "paper", "scissors" };

            //Asking user for his input
            Console.WriteLine("Please enter input");
            string User_Choice = Console.ReadLine();

            // Declaring a boolean flag
            bool Flag;
            Flag = true;


            while (Flag)
            {
                User_Choice = User_Choice.ToLower();
                if (User_Choice == "rock" || User_Choice == "paper" || User_Choice == "scissors")
                {
                    Flag = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input");
                }
            }


            // Code for generating a random integer
            int Random_Number;
            Random Random_Object = new Random();
            Random_Number = Random_Object.Next(1, 4);

            // Displaying the computer choice
            Console.WriteLine("Computers choice is " + choice[Random_Number - 1]);

            switch (Random_Number)
            {
                case 1:
                    if (User_Choice == "rock")
                    {
                        Console.WriteLine("The game is draw");
                    }
                    else if (User_Choice == "paper")
                    {
                        Console.WriteLine("User has won the game");
                    }
                    else
                    {
                        Console.WriteLine("Computer has won the game");
                    }
                    break;

                case 2:
                    if (User_Choice == "rock")
                    {
                        Console.WriteLine("Computer has won the game");
                    }
                    else if (User_Choice == "paper")
                    {
                        Console.WriteLine("The game is draw");
                    }
                    else
                    {
                        Console.WriteLine("User has won the game");
                    }
                    break;

                case 3:
                    if (User_Choice == "rock")
                    {
                        Console.WriteLine("User has won the game");
                    }
                    else if (User_Choice == "paper")
                    {
                        Console.WriteLine("Computer has won the game");
                    }
                    else
                    {
                        Console.WriteLine("The game is draw");
                    }
                    break;
            }
        }
    }
}
