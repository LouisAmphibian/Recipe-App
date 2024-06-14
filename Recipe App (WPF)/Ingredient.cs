using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App__WPF_
{
    class Ingredient
    {
        //Public property to hold the list of ingredient details
        public string NameOfIngredient { get; set; }
        public double QuantityOfIngredient { get; set; }
        public string UnitOfIngredient { get; set; }
        public double CaloriesOfIngredient { get; set; }
        public string FoodGroupOfIngredient { get; set; }

        public override string ToString()
        {
            return $"{QuantityOfIngredient} {UnitOfIngredient} of {NameOfIngredient} ({CaloriesOfIngredient} calories, {FoodGroupOfIngredient})";
        }
    }
}
