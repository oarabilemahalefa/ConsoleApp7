using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
       private string[] steps;

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
        public void InputRecipe()
        {
            Console.WriteLine("How many ingredients are in the recipe?");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                ingredients[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity  {i + 1}:");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for ingredient {i + 1}:");
                units[i] = Console.ReadLine();
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

        public void Scale()
        {
            Console.WriteLine("Enter the scale factor (0.5, 2, or 3):");
            double scaleFactor = double.Parse(Console.ReadLine());

            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= scaleFactor;
            }
        }

        public void Reset()
        {
            //put the reset message
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = 0;
            }

        }

       
        public void Clear()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Are you sure, you want to clear \n" +
                "Press Y to confirm or N to cancel");
            String opps = Console.ReadLine();
            if (opps.Equals("Y") || opps.Equals("y"))
            {
                ingredients = null;
                quantities = null;
                units = null;
                steps = null;
                Console.WriteLine("Recipe has been cleared");
            }
            else if (opps.Equals("N") || opps.Equals("n"))
            {
                Console.WriteLine("You've canceled");

            }
            else
            {
                Console.WriteLine("Invaild choice");
            }

        }
    }
}