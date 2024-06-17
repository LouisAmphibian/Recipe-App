using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Recipe_App__WPF_
{
    public partial class MainWindow : Window
    {
        //2. private dictionary to store recipes
        private Dictionary<string, Recipe> DictionaryforRecipe;


        //the Main Window's constructor
        public MainWindow(Dictionary<string, Recipe> dictionaryforRecipe)
        {
            //method which initialize all the UI components and sets up the event handlers, essentially setting up the user interface as defined in the XAML
            InitializeComponent();

            DictionaryforRecipe = dictionaryforRecipe;
        }


        // Method to make the window draggable
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMiniize_Click(object sender, RoutedEventArgs e)
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


        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            landing_page.Visibility = Visibility.Hidden;
            addRecipePage.Visibility = Visibility.Visible;
            menu.Visibility = Visibility.Visible;

        }

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {

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

            if (recipeName.Equals(""))
            {
                //display a message
                MessageBox.Show(" ERROR: Check if there is no empty field");
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
            }

        }

        private void btnApplyScale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnResetQuantities_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFoodGroupFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIngredientFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCaloriesFilter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
