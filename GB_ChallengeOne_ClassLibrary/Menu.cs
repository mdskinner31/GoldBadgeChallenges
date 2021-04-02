using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne_Repos
{
    public enum MealIngredients { single_burger, cheese_burger, burger_with_bacon, cookie}
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }
        public MealIngredients IngredientsOfMeal { get; set; }

    

    public Menu() { }

        public Menu(int mealNumber, string mealName, string mealDescription, double mealPrice, MealIngredients ingredientsOfMeal)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            IngredientsOfMeal = ingredientsOfMeal;
        }

    }
}
