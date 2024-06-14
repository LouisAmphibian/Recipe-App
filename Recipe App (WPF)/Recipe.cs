using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App__WPF_
{
    class Recipe
    {
        // Public property to hold a list of ingredients
        // List<Ingredient> is a collection that stores Ingredient objects
        public List<Ingredient> Ingredients { get; set; }

        // Public property to hold an array of steps
        // string[] is an array that stores strings, where each string represents a step
        public string[] Steps { get; set; }


        // Constructor for the Recipe class
        // Takes a list of ingredients and an array of steps as parameters
        public Recipe(List<Ingredient> ingredients, string[] steps)
        {
            
            Ingredients = ingredients;
            Steps = steps;
        }

    }
}
