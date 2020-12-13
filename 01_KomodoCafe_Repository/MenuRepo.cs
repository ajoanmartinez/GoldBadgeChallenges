using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class MenuRepo
    {
        private List<Menu> _MenuList = new List<Menu>();
        // Create - Create new menu item and add to list taking in menu content object called Menu
        public void AddMenuItemToList(Menu item)
        {
            _MenuList.Add(item);
        }
        // Read - Get menu list from _MenuList
        public List<Menu> GetMenuList()
        {
            return _MenuList;
        }
        // Update - Update menu items on menu list
        public bool UpdateExistingMenuItem(string originalMealName, Menu newItem)
        {
            Menu oldItem = GetMenuItemByName(originalMealName);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.ListOfIngredients = newItem.ListOfIngredients;
                oldItem.MealPrice = newItem.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete - Remove menu items from _MenuList
        public bool RemoveExistingMenuItem(string mealName)
        {
            Menu item = GetMenuItemByName(mealName);
            if(item == null)
            {
                return false;
            }
            int initialCount = _MenuList.Count;
            _MenuList.Remove(item);
            if(initialCount > _MenuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   
        // Helper Method 
        public Menu GetMenuItemByName(string mealName)
        {
            foreach (Menu item in _MenuList)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        
    }
}
