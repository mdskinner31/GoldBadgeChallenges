using GB_ChallengeThree_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Challenge_Three_Console
{
   public class ProgramUI
    {
        public void RunChallenge()
        {
            // SeedMenuItems();
            RunBadgeMenu();
        }

        public void RunBadgeMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("Welcome to Komodo Insurance Security Dept. " +
                    "Please choose items by number:\n" +

                    "1: Add a new badge\n." +
                    "2: See All Badges and Door Access\n" +
                    "3: Update a badge.\n" +
                    //  "4: Delete all door access from a badge.\n" +
                    "4: Exit");

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        ListBadge();
                        break;
                    case "3":
                        UpdateBadge();
                        break;
                    case "4":


                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Console.Clear();

            Badge badge = new Badge();

            Console.WriteLine("Please enter a new badge ID number");
            badge.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Which Door(s) does badge access?");
            badge.DoorID = Console.ReadLine();

            Console.WriteLine("Any other doors (y/n) ?");
            string repeat = Console.ReadLine();
            repeat = repeat.ToUpper();
            if (repeat == "Y")
            {
                Console.WriteLine("Which Door(s) does badge access?");
                badge.DoorID = Console.ReadLine();
            }
            else if (repeat == "N")
            {
                RunBadgeMenu();
            }
            else
            {
            }


        }
        private void ListBadge()
        {

        }
        private void UpdateBadge()
        {

        }
    }
}

