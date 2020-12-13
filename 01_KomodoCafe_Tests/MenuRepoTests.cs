using _01_KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _repo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();

            List<string> listOfIngredients = new List<string>();
            listOfIngredients.Add("flour bun");
            listOfIngredients.Add("hamburger");
            listOfIngredients.Add("pickle");
            listOfIngredients.Add("onion");
            listOfIngredients.Add("cheese");

            _item = new Menu(3, "Cheeseburger", "Quarter pound beef cheeseburger.", listOfIngredients, 4.5);
            _repo.AddMenuItemToList(_item);

            List<string> listOfIngredients2 = new List<string>();
            listOfIngredients.Add("cheese");
            listOfIngredients.Add("flour");
            listOfIngredients.Add("garlic butter");
            listOfIngredients.Add("marinara sauce");

            Menu pizza = new Menu(1, "Pizza", "10 inch thin crust cheese pizza", listOfIngredients2, 5.75);

            _repo.AddMenuItemToList(pizza);

            // Test Add Method
        }
        public void AddToLIst_ShouldGetNotNull()
        {
            // Arrange
            Menu item = new Menu();
            item.MealName = "Hamburger";
            MenuRepo repo = new MenuRepo();

            // Act
            repo.AddMenuItemToList(item);
            Menu itemFromList = repo.GetMenuItemByName("Hamburger");

            // Assert
            Assert.IsNotNull(itemFromList);
        }
        // Update Method
        [TestMethod]
        public void UpdateExistingMenuItem_ShouldReturnTrue()
        {
            // Arrange
            List<string> listOfIngredients = new List<string>();
            listOfIngredients.Add("cheese");
            listOfIngredients.Add("flour");
            listOfIngredients.Add("garlic butter");
            listOfIngredients.Add("marinara sauce");

            Menu newItem = new Menu(1, "Cheese Pizza", "10 inch thin crust cheese pizza.", listOfIngredients, 4.75);

            // Act
            bool updateResult = _repo.UpdateExistingMenuItem("Pizza", newItem);

            // Assert
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteResult = _repo.RemoveExistingMenuItem(_item.MealName);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
