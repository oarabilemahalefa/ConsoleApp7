using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Recipe> recipes;
        private Recipe selectedRecipe;

        public MainWindow()
        {
            InitializeComponent();

            recipes = new ObservableCollection<Recipe>();
            recipeListBox.ItemsSource = recipes;
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = recipeNameTextBox.Text;
            Recipe newRecipe = new Recipe(recipeName);
            recipes.Add(newRecipe);

            recipeNameTextBox.Clear();
            recipeNameTextBox.Focus();
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecipe = (Recipe)recipeListBox.SelectedItem;
            selectedRecipeTextBlock.Text = selectedRecipe?.Name;

            if (selectedRecipe != null)
            {
                ingredientsListView.ItemsSource = selectedRecipe.Ingredients;
                UpdateTotalCalories();
            }
            else
            {
                ingredientsListView.ItemsSource = null;
                totalCaloriesTextBlock.Text = string.Empty;
            }
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                string ingredientName = ingredientNameTextBox.Text;
                int calories = int.Parse(caloriesTextBox.Text);
                string foodGroup = foodGroupTextBox.Text;

                Ingredient newIngredient = new Ingredient()
                {
                    Name = ingredientName,
                    Calories = calories,
                    FoodGroup = foodGroup
                };

                selectedRecipe.Ingredients.Add(newIngredient);

                ingredientNameTextBox.Clear();
                caloriesTextBox.Clear();
                foodGroupTextBox.Clear();

                UpdateTotalCalories();
            }
        }

        private void UpdateTotalCalories()
        {
            if (selectedRecipe != null)
            {
                int totalCalories = selectedRecipe.Ingredients.Sum(ingredient => ingredient.Calories);
                totalCaloriesTextBlock.Text = $"Total Calories: {totalCalories}";

                if (totalCalories > 300)
                {
                    MessageBox.Show("Total calories exceed 300!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void IngredientFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = ingredientFilterTextBox.Text.ToLower();
            recipeListBox.ItemsSource = recipes.Where(recipe =>
                recipe.Ingredients.Any(ingredient => ingredient.Name.ToLower().Contains(filterText)));
        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFoodGroup = foodGroupComboBox.SelectedItem?.ToString();
            recipeListBox.ItemsSource = recipes.Where(recipe =>
                recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(selectedFoodGroup)));
        }

        private void MaxCaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(maxCaloriesTextBox.Text, out int maxCalories))
            {
                recipeListBox.ItemsSource = recipes.Where(recipe =>
                    recipe.Ingredients.Sum(ingredient => ingredient.Calories) <= maxCalories);
            }
            else
            {
                recipeListBox.ItemsSource = recipes;
            }
        }

        private void recipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Recipe : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new ObservableCollection<Ingredient>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Ingredient : INotifyPropertyChanged
    {
        private string name;
        private int calories;
        private string foodGroup;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public int Calories
        {
            get { return calories; }
            set
            {
                calories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            }
        }

        public string FoodGroup
        {
            get { return foodGroup; }
            set
            {
                foodGroup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FoodGroup)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
