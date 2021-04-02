using GB_ChallengeOne_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeOne_Console
{
    class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedMenuItems();
            RunOrderMenu();
        }
        public void RunOrderMenu()
        {
            bool keepOnMoving = true;
            //bool keepOnMoving2 = true;
            while (keepOnMoving)
            {
                Console.Clear();

                Console.WriteLine("Welcome to Happy Burger! Please choose items by number:\n" +
                    "Please Note All Meals Come with Fries and Drink unless indicated\n\n" +
                    "1: Single Burger Meal\n" +
                    "2: Cheese Burger Meal\n" +
                    "3: Burger with Bacon Meal\n" +
                    "4: Burger Meal w/ Cookie (instead of fries)\n" +
                    "5: See all Menu Items\n" +
                    "6: Show Menu Item By Meal Number\n" +
                    "7: Add Menu Items\n" +
                    "8: Delete Menu Items\n" +
                    "9: Exit");

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1": //"(Single Burger Meal)";
                        SBMeal();
                        break;
                    case "2": //Cheese Burger Meal":
                        CBMeal();
                        break;
                    case "3": //Burger w/ Bacon Meal":
                        BWBMeal();
                        break;
                    case "4": //Burger w/ Coookie Meal":
                        BWCMeal();
                        break;
                    case "5":
                        SeeAllMenuItems();
                        break;
                    case "6":
                        ShowMenuItemByMealNumber();
                        break;
                    case "7": 
                        AddMenuItems();
                        break;
                    case "8":
                        DeleteMenuItems();
                        break;
                    case "9":
                        keepOnMoving = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 9.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }


            }

        }

        private void SBMeal()
        {
            Console.WriteLine("Meal Number: 1\n" +
               " Meal Name: Single Burger Meal\n" +
               " Meal Description: A single patty burger with ketchup, fries and a drink.\n" +
               " Meal Price: $6.99\n" +
               " Meal Ingredients: single burger\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void CBMeal()
        {
            Console.WriteLine("Meal Number: 2\n" +
               " Meal Name:Cheese Burger Meal \n" +
               " Meal Description: A cheese burger with ketchup, fries and a drink. \n" +
               " Meal Price: $7.99\n" +
               " Meal Ingredients: bacon burger\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        private void BWBMeal()
        {
            Console.WriteLine("Meal Number: 3\n" +
               " Meal Name: Burger w/ Bacon Meal\n" +
               " Meal Description: A single patty burger with bacon ,ketchup, fries and a drink.\n" +
               " Meal Price: $8.99\n" +
               " Meal Ingredients: burger with bacon\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        private void BWCMeal()
        {
            Console.WriteLine("Meal Number: 4\n" +
               " Meal Name: Burger Meal w/ Cookie\n" +
               " Meal Description: A single patty burger with bacon ,ketchup, cookie and a drink.\n" +
               " Meal Price: $7.49\n" +
               " Meal Ingredients: cookie\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        private void SeeAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenu = _menuRepo.ShowAllMenuItems();

            foreach (Menu menu in listOfMenu)
            {
                DisplayMenu(menu);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeeAllMenuItems2()
        {
            Console.Clear();
            List<Menu> listOfMenu = _menuRepo.ShowAllMenuItems();

            foreach (Menu menu in listOfMenu)
            {
                DisplayMenu(menu);
            }
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
        }


        private void ShowMenuItemByMealNumber()
        {
            Console.Clear();
            Console.WriteLine("Please enter a Meal Number:");
            int mealNumber = int.Parse(Console.ReadLine());
            Menu menu = _menuRepo.GetListByMealNumber(mealNumber);
            if (menu != null)
            {
                DisplayMenu(menu);
            }
            else
            {
                Console.WriteLine("Invalid Meal Number. Could not find results");
            }
            Console.WriteLine("Presss any key to continue...");
            Console.ReadKey();

        }

        private void AddMenuItems()
        {
            Console.Clear();
            Menu menu = new Menu();

            Console.WriteLine("This is where you add to the menu.");



            Console.WriteLine("Please enter a Meal Name:");
            menu.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a Description of the Meal:");
            menu.MealDescription = Console.ReadLine();

            Console.WriteLine("Please enter the Price of the Meal:");
            menu.MealPrice = double.Parse(Console.ReadLine());

            Console.WriteLine($"Your meal number will be {menu.MealNumber = menu.MealNumber + 5}");

            _menuRepo.AddItemsToMenu(menu);

        }

        private void DeleteMenuItems()
        {
            Console.Clear();
            SeeAllMenuItems2();
            Console.WriteLine("Which menu item would you like to delete (Enter by Name)?");
            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.DeleteMenuItems(input);

            if (wasDeleted)
            {
                Console.WriteLine("The menu item was deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }

            List<Menu> listOfMenuItems = _menuRepo.ShowAllMenuItems();
            int count = 0;
            foreach (Menu menu in listOfMenuItems)
            {
                count++;
                Console.WriteLine($"{count}. {menu.MealName}");

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
//
//            int targetContentID = int.Parse(Console.ReadLine());
//            int targetIndex = targetContentID - 1;
//
//            if (targetIndex >= 0 && targetIndex < listOfMenuItems.Count)
//            {
//                Menu menu = listOfMenuItems[targetIndex];
//
//                if (_menuRepo.DeleteMenuItems(input))
//                {
//                    Console.WriteLine(" The content was successfully removed.");
 //               }
 //               else
 //               {
 //                   Console.WriteLine("I'm Sorry.");
 //               }

 //           }
 //           else
//            {
 //               Console.WriteLine("No menu item has that name.");
  //          }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();


        }

        private void DisplayMenu(Menu menu)
        {
            Console.WriteLine($"Meal Number: {menu.MealNumber}\n" +
                $"Meal Name: {menu.MealName}\n" +
                $"Meal Description: {menu.MealDescription}\n" +
                $"Meal Price: ${menu.MealPrice}\n");
            // $"Meal Ingredients: {menu.IngredientsOfMeal}\n");
        }

        private void SeedMenuItems()
        {
            Menu singleb = new Menu(1, "Single Burger Meal", "A single patty burger with ketchup, fries and a drink.", 6.99, MealIngredients.single_burger);
            Menu cheeseb = new Menu(2, "Cheese Burger Meal", "A cheese burger with ketchup, fries and a drink.", 7.99, MealIngredients.cheese_burger);
            Menu baconb = new Menu(3, "Burger w/ Bacon Meal", "A single patty burger with bacon ,ketchup, fries and a drink.", 8.99, MealIngredients.burger_with_bacon);
            Menu burgerc = new Menu(4, "Burger Meal w/ cookie", "A single patty burger with ketchup, cookie and a drink.", 7.49, MealIngredients.cookie);

            _menuRepo.AddItemsToMenu(singleb);
            _menuRepo.AddItemsToMenu(cheeseb);
            _menuRepo.AddItemsToMenu(baconb);
            _menuRepo.AddItemsToMenu(burgerc);

        }

    }
}
