using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7

{
    // Class representing an ingredient in a recipe.
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    // Class representing a recipe.
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
        public double ScaleFactor { get; set; } = 1.0;
    }

    // Delegate to notify when the total calories are calculated.
    public delegate void CalorieNotification(int totalCalories);

    // Class for storing and manipulating recipes.
    public class StoreRecipe
    {
        private List<Recipe> recipes = new List<Recipe>();

        // Method to input a new recipe.
        public void InputRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Recipe recipe = new Recipe();

            Console.Write("Enter recipe name: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredient ingredient = new Ingredient();

                Console.Write($"Enter the name of ingredient {i + 1}: ");
                ingredient.Name = Console.ReadLine();

                Console.Write("Enter the quantity: ");
                ingredient.Quantity = double.Parse(Console.ReadLine());


                Console.Write("Enter the unit of measurement: ");
                ingredient.Unit = Console.ReadLine();

                Console.Write("Enter the number of calories: ");
                ingredient.Calories = int.Parse(Console.ReadLine());

                Console.Write("Enter the food group: ");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.Ingredients.Add(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.Steps.Add(step);
            }

            recipe.ScaleFactor = 1.0;

            recipes.Add(recipe);

            CalculateCalories(recipe);
        }


        //this method will display the information that the user entered
        public void DisplayRecipes()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            recipes = recipes.OrderBy(r => r.Name).ToList();

            Console.WriteLine("Available Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }

            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                Console.WriteLine();
                Console.WriteLine("Recipe:");
                Console.WriteLine($"Name: {selectedRecipe.Name}");

                Console.WriteLine("Ingredients:");
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    double scaledQuantity = ingredient.Quantity * selectedRecipe.ScaleFactor;
                    Console.WriteLine($"{ingredient.Name}: {scaledQuantity} {ingredient.Unit}");
                }

                Console.WriteLine("Steps:");
                for (int i = 0; i < selectedRecipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedRecipe.Steps[i]}");
                }
                CalculateCalories(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
        //this method will scale the users information by the listed number

        public void Scale()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
            double scaleFactor = double.Parse(Console.ReadLine());
            Console.Write("Enter the name of the recipe to scale: ");
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                selectedRecipe.ScaleFactor = scaleFactor;

                Console.WriteLine("Recipe scaled successfully.");
                Console.WriteLine();
                DisplayRecipe(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        //the mothod will reset the quanties to the original value
        public void Reset()
        {
            Console.Write("Enter the name of the recipe to reset quantities: ");
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                selectedRecipe.ScaleFactor = 1.0;

                Console.WriteLine("Quantities reset successfully.");
                Console.WriteLine();
                DisplayRecipe(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }



        // this method will display the information that the user entered
        private void DisplayRecipe(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Recipe:");
            Console.WriteLine($"Name: {recipe.Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                double scaledQuantity = ingredient.Quantity * recipe.ScaleFactor;
                Console.WriteLine($"{ingredient.Name}: {scaledQuantity} {ingredient.Unit}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }
        }

        //this method will clear all the information the user has entered
        //but first it will ask them to confirm if they are sure
        public void ClearRecipes()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Are you sure you want to clear? \n" +
                "Press Y to confirm or N to cancel");
            string opps = Console.ReadLine();
            if (opps.Equals("Y") || opps.Equals("y"))
            {
                recipes.Clear();
                Console.WriteLine("All Recipes have been cleared");
            }
            else if (opps.Equals("N") || opps.Equals("n"))
            {
                Console.WriteLine("You've canceled");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
        // method to calculate total calories of a recipe.
        private void CalculateCalories(Recipe recipe)
        {
            int totalCalories = 0;

            foreach (var ingredient in recipe.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            Console.WriteLine($"Total calories for the recipe '{recipe.Name}': {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("The recipe exceeds 300 calories.");
            }
        }
    }
}