using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {//my main method has code that will display menu and will also call
     //other method in recipe class that will be used in the application
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Recipe recipe = new Recipe();
            while (true)
            {


                Console.WriteLine("What would you like to do? \n"
                                + "1) Enter a new recipe \n"
                                + "2) Display the current recipe \n"
                                + "3) Scale the recipe \n"
                                + "4) Reset the recipe quantities \n"
                                + "5) Clear all data \n"
                                + "6) Exit the program");

                string input = Console.ReadLine();
                int choice = int.Parse(input);

                switch (choice)
               { 
                    case 1:
                        recipe.InputRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.Scale();
                        break;
                    case 4:
                        recipe.Reset();
                        break;
                    case 5:
                        recipe.Clear();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
               }
            }

        }
    }

}
