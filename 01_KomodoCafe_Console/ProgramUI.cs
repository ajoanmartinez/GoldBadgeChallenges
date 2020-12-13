using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View List of Menu Items\n" +
                    "3. View Menu Item by Name\n" +
                    "4. Update Existing Menu Item\n" +
                    "5. Delete Existing Menu Item\n" +
                    "6. Exit");
                // Get user's input
                string input = Console.ReadLine();
                //Evaluate user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create new menu item
                        CreateNewMenuItem();
                        break;
                    case "2":
                        // View all menu items
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        // View menu item by name
                        DisplayMenuItemByMealName();
                        break;
                    case "4":
                        // Update existing menu item
                        UpdateExistingMenuItem();
                        break;
                    case "5":
                        //Delete existing menu item
                        DeleteExistingMenuItem();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Create new menu item
        private void CreateNewMenuItem()
        {
            Console.Clear();
            Menu newItem = new Menu();
            // Meal Number
            Console.WriteLine("Enter the meal number for the new item:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);
            // Meal Name
            Console.WriteLine("Enter the meal name for the new item:");
            newItem.MealName = Console.ReadLine();
            // Meal Description
            Console.WriteLine("Enter the meal description for the new item:");
            newItem.MealDescription = Console.ReadLine();
            // List of Ingredients
            Console.WriteLine("Enter ingredient for the new item:");
            newItem.ListOfIngredients.Add(Console.ReadLine());
            Console.WriteLine("Add another ingredient for the new item? (y/n)");
            string addAnotherIngredient = Console.ReadLine().ToLower();
            while (addAnotherIngredient != "n")
            {
                // Prompt user to enter another ingredient 
                Console.WriteLine("Enter another ingredient for the new item:");
                // Add ingredient to list of ingredients for menu item
                newItem.ListOfIngredients.Add(Console.ReadLine());
                // Ask the user if they want to add another ingredient to the menu item
                Console.WriteLine("Add another ingredient for the new item? (y/n)");
                // Capture the user's answer
                addAnotherIngredient = Console.ReadLine().ToLower();
                // If addIngredient = no, then exit loop
            }
            // Meal Price
            Console.WriteLine("Enter the price of for the new item:");
            string mealPriceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(mealNumberAsString);

            _menuRepo.AddMenuItemToList(newItem);
        }
        // View all menu items
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<Menu> MenuList = _menuRepo.GetMenuList();
            foreach (Menu item in MenuList)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Desc: {item.MealDescription}");
                Console.WriteLine("Meal Ingredients:");
                   foreach (string ingredient in item.ListOfIngredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine($"Meal Price: {item.MealPrice}");
               
            }

        }
        // View existing menu item by meal name
        private void DisplayMenuItemByMealName()
        {
            Console.Clear();
            // Prompt user to provide a meal name
            Console.WriteLine("Enter the meal name you would like to see:");
            // Get user's input
            string mealName = Console.ReadLine().ToLower();
            // Find the item by meal name
            Menu item = _menuRepo.GetMenuItemByName(mealName);
            if (item != null)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Desc: {item.MealDescription}\n" +
                    $"Meal Ingredients: {item.ListOfIngredients}\n" +
                    $"Meal Price: {item.MealPrice}");
            }
            else
            {
                Console.WriteLine("No menu item by that meal name.");
            }
        }
        // Update existing menu item
        private void UpdateExistingMenuItem()
        {
            // Display all menu items
            DisplayAllMenuItems();
            // Ask for meal name of the item to update
            Console.WriteLine("\nEnter the meal name of the item you would like to update:");
            // Get the meal from the user
            string oldMealName = Console.ReadLine();
            Menu newItem = new Menu();
            // Meal Number
            Console.WriteLine("Enter the meal number for the new item:");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(mealNumberAsString);
            // Meal Name
            Console.WriteLine("Enter the meal name for the new item:");
            newItem.MealName = Console.ReadLine();
            // Meal Description
            Console.WriteLine("Enter the meal description for the new item:");
            newItem.MealDescription = Console.ReadLine();
            // List of Ingredients
            Console.WriteLine("Enter an ingredient for the new item:");
            newItem.ListOfIngredients.Add(Console.ReadLine());
            Console.WriteLine("Add another ingredient for the new item? (y/n)");
            string addAnotherIngredient = Console.ReadLine().ToLower();
            while (addAnotherIngredient != "n")
            {
                // Prompt user to enter another ingredient 
                Console.WriteLine("Enter another ingredient for the new item:");
                // Add ingredient to list of ingredients for menu item
                newItem.ListOfIngredients.Add(Console.ReadLine());
                // Ask the user if they want to add another ingredient to the menu item
                Console.WriteLine("Add another ingredient for the new item? (y/n)");
                // Capture the user's answer
                addAnotherIngredient = Console.ReadLine().ToLower();
                // If addIngredient = no, then exit loop
            }
            // Meal Price
            Console.WriteLine("Enter the price of for the new item:");
            string mealPriceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(mealNumberAsString);

            _menuRepo.AddMenuItemToList(newItem);
            // Verify the update worked
            bool wasUpdated = _menuRepo.UpdateExistingMenuItem(oldMealName, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Menu item successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content");
            }
        }
        // Delete existing menu item
        private void DeleteExistingMenuItem()
        {
            // Display all menu items
            DisplayAllMenuItems();
            // Prompt user to get the meal name they want to delete
            Console.WriteLine("\nEnter the meal name of the menu item you would like to remove:");
            // Capture the user input
            string input = Console.ReadLine().ToLower();
            // Call the delete method
            bool wasDeleted = _menuRepo.RemoveExistingMenuItem(input);
            // If the menu item was deleted successfully tell the user it was deleted
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }
        }
        private void SeedMenuList()
        {
            List<string> listOfIngredients = new List<string>();
            listOfIngredients.Add("cheese");
            listOfIngredients.Add("flour");
            listOfIngredients.Add("garlic butter");
            listOfIngredients.Add("marinara sauce");

            Menu pizza = new Menu(1, "Pizza", "10 inch thin crust cheese pizza", listOfIngredients, 5.75);

            _menuRepo.AddMenuItemToList(pizza);
        }
    }
}
