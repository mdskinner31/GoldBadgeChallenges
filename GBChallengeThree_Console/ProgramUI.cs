using GB_ChallengeThree_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBChallengeThree_Console
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void RunChallenge()
        {
            
          SeedBadgeItems();
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

                    "1: Add a new badge\n" +
                    "2: See All Badges and Door Access\n" +
                    "3: Update a badge\n" +
                    "4: Delete all door access from a badge.\n" +
                    "5: Exit");

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        ListBadge();
                        //BadgeAccessList();
                        break;
                    case "3":
                        UpdateBadge();
                        break;
                    case "4":
                        DeleteAllAccessFromBadge();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 5.\n" +
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
            badge.ListOfDoors= Console.ReadLine();

            Console.WriteLine("Any other doors (y/n) ?");
            string repeat = Console.ReadLine();
            repeat = repeat.ToUpper();
            if (repeat == "Y")
            {
                Console.WriteLine("Which Door(s) does badge access?");
                badge.ListOfDoors = Console.ReadLine();

            }
            else if (repeat == "N")
            {
                RunBadgeMenu();
            }
            else
            {
            }

            _badgeRepo.AddDoorAccess(badge);

        }
        private void ListBadge()
        {
            Console.Clear();
            List<Badge> listOfBadges = _badgeRepo.GetBadges();

            foreach (Badge badge in listOfBadges)
            {
                DisplayBadge(badge);
            }
            Console.WriteLine("Press any key to continue,,,");
            Console.ReadKey();
        }

        

        private void BadgeAccessList()
        {
           Dictionary<string, int> bid = new Dictionary<string,int >();
           
            Console.WriteLine("Badge List");
 
           foreach (KeyValuePair<string,int> badge in bid)
               // foreach (var badge in bid)
                {
                Console.WriteLine($"Badge ID: {0}, Door Access: {1}", badge.Key, badge.Value);
            }
            
            
            Console.WriteLine("Press any key to continue,,,");
            Console.ReadKey();

        }

        private void DeleteAllAccessFromBadge()
        {
            Console.Clear();
            ListBadge();
            Console.WriteLine("Which badge would you like to delete all door access?");
            
            Console.WriteLine("Please enter a Badge ID:");
            int badgeID = int.Parse(Console.ReadLine());
            Badge badge = _badgeRepo.GetBadgeById(badgeID);
            if (badge != null)
            {
                DisplayBadge(badge);
                
            }
            else
            {
                Console.WriteLine("Invalid Badge ID.");
            }
            
        }
        private void UpdateBadge()
        {
            //Display all
            //ListBadge();
            BadgeAccessList();
            //What to update
            Console.WriteLine("What badge number do you want to update?");

            //Get item to update
            int oldBadgeId = int.Parse(Console.ReadLine());

            //Build new object
            Console.Clear();

            Badge newBadge = new Badge();

            Console.WriteLine("Please enter a new badge ID number");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Which Door(s) does badge access?");
            newBadge.ListOfDoors = Console.ReadLine();

            Console.WriteLine("Any other doors (y/n) ?");
            string repeat = Console.ReadLine();
            repeat = repeat.ToUpper();
            if (repeat == "Y")
            {
                Console.WriteLine("Which Door(s) does badge access?");
                newBadge.ListOfDoors = Console.ReadLine();

            }
            else if (repeat == "N")
            {
                RunBadgeMenu();
            }
            else
            {
            }

          // Console.WriteLine($"{badge.BadgeID} has access to door(s) {badge.ListOfDoors}");
         //   Console.WriteLine("What would you like to do?\n" +
         //       "1. Remove a door\n" +
         //       "2. Add a door");

            //switch ();

            bool wasUpdated = _badgeRepo.UpdateBadgeAccess(oldBadgeId, newBadge);

            if (wasUpdated)
            {
                Console.WriteLine("Badge was updated.");
            }
            else
            {
                Console.WriteLine("Could not update Badge.");
            }
        }
        private void DisplayBadge(Badge badge) 
        {
            Console.WriteLine($"Badge ID: {badge.BadgeID}\n" +
                $"Door ID: {badge.ListOfDoors}");
        
        }

        private void GetBadgeById()
        {
            Console.Clear();
            ListBadge();
            Console.WriteLine("Please enter a Badge ID:");
            int badgeID = int.Parse(Console.ReadLine());
            Badge badge = _badgeRepo.GetBadgeById(badgeID);
            if ( badge != null)
            {
                DisplayBadge(badge);
            }
            else
            {
                Console.WriteLine("Invalid Badge ID.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        private void SeedBadgeItems()
        {
            Badge one = new Badge(12345,"A7");
            Badge two = new Badge(22345,"A1");
            Badge three = new Badge(32345, "Where Do Lists Go?");

            _badgeRepo.AddDoorAccess(one);
            _badgeRepo.AddDoorAccess(two);
            _badgeRepo.AddDoorAccess(three);
        }
    }
}
