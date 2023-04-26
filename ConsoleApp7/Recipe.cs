using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7

{
    class Recipe
    { //created variables for my application
        private string[] ingredients; 
        private double[] quantities;
        private string[] unit;
       private string[] steps;
       private double scaleFactor = 1.0;
        /*private string[] ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        private double[] quantities
        {
            get { return quantities; }
            set { quantities = value; }
        }
        private string[] units
        {
            get { return units; }
            set { units = value; }
        }

        private string[] steps
        {
            get { return steps; }
            set { steps = value; }
        }*/
        //input method which has code for ingridients,quantity,measurement, and number of steps for the recipe
        public void InputRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("How many ingredients are in the recipe?");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            unit = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity  {i + 1}:");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for ingredient {i + 1}:");
                unit[i] = Console.ReadLine();
            }

            Console.WriteLine("How many steps are in the recipe?");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }
        }

        // this method will display the information that the user entered
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }


        //this method will scale the users information by the listed numbers
        public void Scale()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnter the scaling factor (0.5, 2, or 3):");
            double factor = double.Parse(Console.ReadLine());

            if (factor == 0.5 || factor == 2 || factor == 3)
            {

                scaleFactor = factor;
                Console.WriteLine($"\nRecipe scaled by factor {factor}.");
            }
            else
            {
                Console.WriteLine("\nInvalid scaling factor.");
            }
        }
        //the mothod will reset the quanties to the original value
        public void Reset()
        {
            //put the reset message
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = 0;
            }

        }

        //this method will clear all the information the user has entered
        //but first it will ask them to confirm if they are sure
        public void Clear()
        {
            ingredients = null;
            quantities = null;
            unit = null;
            steps = null;
        }
    }
}