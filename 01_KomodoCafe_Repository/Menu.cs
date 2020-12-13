using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public double MealPrice { get; set; }
        public Menu() { }
        public Menu(int mealNumber, string mealName, string mealDescription, List<string> ingredientsList, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = ingredientsList;
            MealPrice = mealPrice;
        }

    }
}
