using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne_Repos
{
    public class MenuRepository
    {
        public List<Menu> _listOfItems = new List<Menu>();
        //Create
        public void AddItemsToMenu(Menu menu)
        {
            _listOfItems.Add(menu);

        }

        //Read
        public List<Menu> ShowAllMenuItems()
        {
            return _listOfItems;
        }

        //Update

 //         public bool UpdateMenuItems(int originalMenu, Menu newMenu)
 //       {
 //           Menu oldMenu = GetListByMealNumber(originalMealNumber);

 //          if (oldMenu != null)
            //{
 //               oldMenu.MealNumber = newMenu.MealNumber;
 //               oldMenu.MealName = newMenu.MealName;
 //               oldMenu.Description = newMenu.Description;
 //               oldMenu.Ingredients = newMenu.Ingredients;
 //               oldMenu.Price = newMenu.Price;
//
 //               return true;
 //           }
 //           else
 //           {
 //               return false;
 //           }
//
  //      }




        //Delete
        public bool DeleteMenuItems(string mealName)
        {
            Menu menu = GetListByMealName(mealName);

            if (menu == null)
            {
                return false;
            }
            int intialCount = _listOfItems.Count;
            _listOfItems.Remove(menu);

            if (intialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Menu GetListByMealName(string mealName)
        {
            foreach (Menu menu in _listOfItems)
            {
                if (menu.MealName.ToLower() == mealName.ToLower())
                {
                    return menu;
                }
            }

            return null;
        }

        public Menu GetListByMealNumber(int mealNumber)
        {
            foreach (Menu menu in _listOfItems)
            {
                if (menu.MealNumber == mealNumber)
                {
                    return menu;
                }
            }

            return null;
        }

    }
}
