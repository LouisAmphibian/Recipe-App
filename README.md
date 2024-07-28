# Recipe-App-POE-ST10161370

# Description
Recipe app is a application that allows the user to enter and store the ingredients and steps for one recipe.
The application now is a WPF application. Changes involve it allowing new data as dictionary.

## Prerequisites
- Make sure you have [.NET SDK](https://dotnet.microsoft.com/download) installed.
- Make sure you have Visual Studio community(https://visualstudio.microsoft.com/vs/community/) installed

## Installation of applicaation/ project
1. Clone this repository (https://github.com/LouisAmphibian/Recipe-App-POE.git) to your local machine.
2. Navigate to the project directory.
3. Locate the solution explorer
4. Double click or open the RecipeApp.sln

## Building the Software
1. After opening or double clicking the RecipeApp.sln
3. Press Crtl B to Build .

## Running the Software
1. After building the project, navigate the Debug drop menu
2. The click on Start Debugging or Start Without Debug

## Screenshot
![Screenshot 2024-06-28 210312](https://github.com/LouisAmphibian/Recipe-App-POE/assets/106699001/c257c829-d7fb-42fb-a94e-7afd56abaeef)

## Contributing
Pull requests are welcome. No major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)

### [12-May-2023]

### Features Added:
1. The user can now enter an unlimited number of recipes.
2. Each recipe can be given a name by the user.
3. All recipes are displayed to the user in alphabetical order by name.
4. Users can select a recipe from the displayed list.
5. For each ingredient, users can now enter:
    - The number of calories.
    - The food group to which the ingredient belongs.
6. The application now calculates and displays the total calories of all ingredients in a recipe.
7. If the total calories of a recipe exceed 300, the user is notified.

#### Non-functional requirements:
8. Internationally acceptable coding standards are adhered to.
9. Classes are used throughout the application.
10. Generic collections are utilized instead of arrays for storing recipes, ingredients, and steps.
11. A delegate is implemented to notify the user when a recipe exceeds 300 calories.
12. A unit test is created to verify the accuracy of the total calorie calculation.### Features Added:
1. The user can now enter an unlimited number of recipes.
2. Each recipe can be given a name by the user.
3. All recipes are displayed to the user in alphabetical order by name.
4. Users can select a recipe from the displayed list.
5. For each ingredient, users can now enter:
    - The number of calories.
    - The food group to which the ingredient belongs.
6. The application now calculates and displays the total calories of all ingredients in a recipe.
7. If the total calories of a recipe exceed 300, the user is notified.

#### Non-functional requirements:
8. Internationally acceptable coding standards are adhered to.
9. Classes are used throughout the application.
10. Generic collections are utilized instead of arrays for storing recipes, ingredients, and steps.
11. A delegate is implemented to notify the user when a recipe exceeds 300 calories.
12. A unit test is created to verify the accuracy of the total calorie calculation.

### Implementation Details:
- Implemented feedback provided by the lecturer on Part I before proceeding with Part 2.
- Marks awarded for implementing feedback (109).
