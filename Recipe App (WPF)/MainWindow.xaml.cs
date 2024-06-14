using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Recipe_App__WPF_
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
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
                var ingredients = new List<Ingredient>();
                foreach (Ingredient ingredient in ingredientsListBox.Items)
                {
                    ingredients.Add(ingredient);
                }

                var steps = new List<string>();
                foreach (string step in stepsListBox.Items)
                {
                    steps.Add(step);
                }

                var recipe = new Recipe(ingredients, steps.ToArray());
            }

        }
    }
}
