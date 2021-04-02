using GB_ChallengeOne_Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace GB_ChallengeOne_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _repo;
        private Menu _items;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _items = new Menu(5, "Chicken Sandwich", "Chicken Sandwich with pickles", 8.95, MealIngredients.cookie);

            _repo.AddItemsToMenu(_items);
        }
        [TestMethod]
        public void SetMealName_ShouldSetName()
        {
            Menu menu = new Menu();
            menu.MealName = "Single Cheese Burger";
            string expected = "Single Cheese Burger";
            string actual = menu.MealName;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddMenuItems_ShouldShowMenu()
        {

            Menu menu = new Menu();
            MenuRepository menuRepository = new MenuRepository();
        }
        [TestMethod]
        public void ShowAllMenuItems_ShouldReturnList()
        {
            Menu menu = new Menu();
            MenuRepository menuRepository = new MenuRepository();
            menuRepository.AddItemsToMenu(menu);

            List<Menu> listOfMenuItems = menuRepository.ShowAllMenuItems();

            bool menuHasItems = listOfMenuItems.Contains(menu);

            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void DeleteMenuItems_ToSeeIfGone()
        {
            bool deleteResult = _repo.DeleteMenuItems(_items.MealName);

            Assert.IsTrue(deleteResult);
        }



       

    }


}

