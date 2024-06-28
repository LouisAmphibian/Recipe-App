using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Recipe_App__WPF_
{
    public partial class MainWindow : Window
    {
        //2. private dictionary to store recipes
        private Dictionary<string, Recipe> DictionaryforRecipe;


        //the Main Window's constructor
        public MainWindow()
        {
            //method which initialize all the UI components and sets up the event handlers, essentially setting up the user interface as defined in the XAML
            InitializeComponent();

            DictionaryforRecipe = new Dictionary<string, Recipe>();

        }


        // Method to make the window draggable
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            landing_page.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            searchRecipeNamePage.Visibility = Visibility.Hidden;
            searchedRecipePage.Visibility = Visibility.Hidden;

        }


        //Add Recipe Button
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            landing_page.Visibility = Visibility.Hidden;
            addRecipePage.Visibility = Visibility.Visible;
            menu.Visibility = Visibility.Visible;
            searchRecipeNamePage.Visibility = Visibility.Hidden;
            searchedRecipePage.Visibility = Visibility.Hidden;
        }



        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {

            string ingredientName = ingredientTextBox.Text;
            string ingredientQuantity = quantityTextBox.Text;
            string ingredientUnit = unitTextBox.Text;
            string ingredientCalories = caloriesTextBox.Text;
            string ingredientFoodGroup = foodGroupTextBox.Text;

            //check the variables if they are not empty
            if (ingredientName.Equals("") || ingredientQuantity.Equals("") || ingredientUnit.Equals("") || ingredientCalories.Equals("") || ingredientFoodGroup.Equals(""))
            {
                //display a message
                MessageBox.Show(" Error Message !! \n\n All fields are" +
                    "required !!\n\n");
            }
            else
            {
                //pass the varibales to store in the generics and display
                ingredientsListBox.Items.Add(new Ingredient { NameOfIngredient = ingredientName, QuantityOfIngredient = ingredientQuantity, UnitOfIngredient = ingredientUnit, CaloriesOfIngredient = ingredientCalories, FoodGroupOfIngredient = ingredientFoodGroup });

                //clear the fields 
                ingredientTextBox.Clear();
                quantityTextBox.Clear();
                unitTextBox.Clear();
                caloriesTextBox.Clear();
                foodGroupTextBox.Clear();
            }
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            string step = stepTextBox.Text;

            if (step.Equals(""))
            {
                //display a message
                MessageBox.Show(" ERROR:At least one step is required" +
                    "required !!\n\n");
            }
            else
            {
                stepsListBox.Items.Add(step);
                stepTextBox.Clear();
            }


        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            //store recipe after save button
            string recipeName = recipe_name.Text;

            if (string.IsNullOrWhiteSpace(recipeName))//Checks if recipeName is no
            {
                //display a message
                MessageBox.Show(" ERROR: Recipe name cannot be empty.");
            }
            else if (DictionaryforRecipe.ContainsKey(recipeName)) //Checks if 'recipeName' exist in the dictionary
            {
                //
                MessageBox.Show("ERROR: Recipe Name does  exist! Please Enter new Recipe Name.");
            }
            else
            {
                //create a new list to store multiple Ingredients objects.
                var ingredients = new List<Ingredient>();

                //for loop to iterate through each item in the ingredientsListBox and add it to the ingredient list
                foreach (Ingredient ingredient in ingredientsListBox.Items)
                {
                    ingredients.Add(ingredient);
                }

                //create a new list to store multiple Steps object 
                var steps = new List<string>();

                //for loop to iterate through each item in the stepListBox and add it to the step list
                foreach (string step in stepsListBox.Items)
                {
                    steps.Add(step);
                }

                //1.Create a new Reccipe object using the ingredients list and the steps list converted to an array
                var recipe = new Recipe(ingredients, steps.ToArray());

                //3.Add the new Recipe object the dictionary with the recipe as the key
                DictionaryforRecipe.Add(recipeName, recipe);

                MessageBox.Show("Recipe is successfully added!");

                //Clear the fields for new recipe entry
                recipe_name.Clear();
                ingredientTextBox.Clear();
                quantityTextBox.Clear();
                unitTextBox.Clear();
                caloriesTextBox.Clear();
                foodGroupTextBox.Clear();
                ingredientsListBox.Items.Clear();
                stepTextBox.Clear();
                stepsListBox.Items.Clear();
            }

        }

        //Search
        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            landing_page.Visibility = Visibility.Hidden;
            addRecipePage.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            searchedRecipePage.Visibility = Visibility.Hidden;
            searchRecipeNamePage.Visibility = Visibility.Visible;

        }

        //Search for Recipe 
        private void btnSearchRecipeDatabase_Click(object sender, RoutedEventArgs e)
        {
            string findRecipeName = searchRecipeName.Text;

            // Flag to check if recipe is found
            bool recipeFound = false;


            if (string.IsNullOrWhiteSpace(findRecipeName))//Checks if recipeName is no
            {
                //display a message
                MessageBox.Show(" ERROR: Recipe name cannot be empty.");
            }
            else
            {
                // Search through the dictionary 
                foreach (string recipeName in DictionaryforRecipe.Keys)
                {

                    if (string.Equals(findRecipeName, recipeName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        searchedRecipePage.Visibility = Visibility.Visible;
                        searchRecipeNamePage.Visibility = Visibility.Hidden;
                        searchRecipeName.Clear();

                        //Displaying for the user
                        recipeDetailsListBox.Items.Clear();

                        DisplayAllRecipe();

                        recipeFound = true;
                        break;
                    }
                }

                if (!recipeFound)
                {
                    // Display a message if recipe is not found
                    MessageBox.Show($"{findRecipeName.Substring(0, 1).ToUpper()}{findRecipeName.Substring(1).ToLower()} is not found");

                }
            }




        }

        //Apply scale 
        private void btnApplyScale_Click(object sender, RoutedEventArgs e)
        {
            double scale;
            if (!double.TryParse((scaleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(), out scale))
            {
                MessageBox.Show("Invalid scale value.");
                return;
            }

            foreach (Recipe recipe in DictionaryforRecipe.Values)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    ingredient.QuantityOfIngredient = (ingredient.OriginalQuantity * scale).ToString();
                }
            }

            DisplayAllRecipe();
        }

        //Reset Quantities
        private void btnResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            foreach (Recipe recipe in DictionaryforRecipe.Values)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    ingredient.QuantityOfIngredient = ingredient.OriginalQuantity.ToString();
                }
            }

            DisplayAllRecipe();
        }

        private void btnFoodGroupFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIngredientFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = filterIngredientTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                MessageBox.Show("ERROR: Ingredient name cannot be empty.");
                return;
            }

            recipeDetailsListBox.Items.Clear();

            foreach (var entry in DictionaryforRecipe)
            {
                Recipe recipe = entry.Value;

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (string.Equals(ingredient.NameOfIngredient, ingredientName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        DisplayAllRecipe();
                        break;
                    }
                }
            }
        }

        private void btnCaloriesFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDisplayPieChart_Click(object sender, RoutedEventArgs e)
        {
            landing_page.Visibility = Visibility.Hidden;
            addRecipePage.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            searchedRecipePage.Visibility = Visibility.Hidden;
            searchRecipeNamePage.Visibility = Visibility.Hidden;

            MessageBox.Show("Comming Soon!");
        }

        public void DisplayAllRecipe()
        {
            recipeDetailsListBox.Items.Clear();

            foreach (Recipe recipe in DictionaryforRecipe.Values)
            {
               // recipeDetailsListBox.Items.Add($"Recipe: { recipe.Name}");
                recipeDetailsListBox.Items.Add("Ingredients:");

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    recipeDetailsListBox.Items.Add(
                        $"Ingredient: {ingredient.NameOfIngredient}, Quantity: {ingredient.QuantityOfIngredient}, Unit: {ingredient.UnitOfIngredient}, Calories: {ingredient.CaloriesOfIngredient}, Food Group: {ingredient.FoodGroupOfIngredient}" +
                        $"\n --------------------------------------"
                    );
                }


                //Display steps

                recipeDetailsListBox.Items.Add("Steps:");
                for (int i = 0; i < recipe.Steps.Length; i++)
                {
                    recipeDetailsListBox.Items.Add($"Step {i + 1}: {recipe.Steps[i]}" +
                        $"\n --------------------------------------");
                }

                // Add an empty line for separation between recipes
                recipeDetailsListBox.Items.Add(string.Empty);
            }
        }

    }
}
