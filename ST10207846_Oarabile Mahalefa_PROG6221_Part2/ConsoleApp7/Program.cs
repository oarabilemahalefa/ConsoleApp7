using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    public class Program
    {
        // The main method that gets executed when the program starts.
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;


            StoreRecipe storeRecipe = new StoreRecipe();

            // Run the program in an infinite loop until the user chooses to exit.
            while (true)
            {

               
                Console.WriteLine("*********WELCOME**************");
                Console.WriteLine("What would you like to do? \n"
                    + "1) Enter a new recipe. \n"
                    + "2) Display recipes. \n"
                    + "3) Scale the recipe. \n"
                    + "4) Reset the recipe quantities. \n"
                    + "5) Delete all recipes. \n"
                    + "6) Exit the program.");


                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();


                switch (choice)
                {
                    case 1:

                        storeRecipe.InputRecipe();
                        break;
                    case 2:

                        storeRecipe.DisplayRecipes();
                        break;
                    case 3:

                        storeRecipe.Scale();
                        break;
                    case 4:

                        storeRecipe.Reset();
                        break;
                    case 5:

                        storeRecipe.ClearRecipes();
                        break;
                    case 6:

                        Console.WriteLine("Thank you for using the Recipe Application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

        }
    }
}
