using GB_ChallengeTwo_Repository;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claimsrepo = new ClaimsRepository();

        public void Run()
        {
            SeedClaims();
            RunMenu();
        }

        public void RunMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("Welcome to Komodo Insurance Claims Dept.! " +
                    "Please choose items by number:\n" +

                    "1: See All Claims\n" +
                    "2: Take Care of Next Claim\n" +
                    "3: Enter a New Claim\n" +
                    "4: Exit");

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
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
        private void SeeAllClaims()
        {
            Console.Clear();

            List<Claims> listOfClaims = _claimsrepo.GetClaimsList();

            foreach (Claims claims in listOfClaims)
            {
                DisplayClaims(claims);

            }
            Console.WriteLine("Presss any key to continue...");
            Console.ReadLine();




        }
        private void ShowClaimByNumber()
        {
            Console.Clear();
            SeeAllClaims();
            // Console.WriteLine("Which claim would you like to deal with first? ");
            Console.WriteLine("Please enter a Claim Number:");
            int claimID = int.Parse(Console.ReadLine());
            Claims claims = _claimsrepo.GetClaimByID(claimID);
            if (claims != null)
            {
                DisplayClaims(claims);
            }
            else
            {
                Console.WriteLine("Invalid Claim ID. Could not find results");
            }
            // Console.WriteLine("Presss any key to continue...");
            Console.ReadKey();

        }

        private void NextClaim()
        {
            Queue<string> que = new Queue<string>();

            que.Enqueue("Claim 1");
            que.Enqueue("Claim 2");
            que.Enqueue("Claim 3");
            
            foreach (Object obj in que)
            {
                Console.WriteLine(obj);
            }
          
            Console.WriteLine("Do you want to deal with the next claim now(y/n)?");
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();
            if (userInput == "Y")
            {
                Console.WriteLine(que.Dequeue() + " has been processed");

                Console.WriteLine("Do you want to deal with the next one (y/n)?");
                string userInput2 = Console.ReadLine();
                userInput2 = userInput2.ToUpper();
                if (userInput2 == "Y")
                {
                    Console.WriteLine("No one has time for that today!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }

                Console.ReadLine();

            }
            else if (userInput == "N")
            {
               
                SeeAllClaims();
            }
            else { }

        }

        private void EnterNewClaim()
        {
            Console.Clear(); 
            Claims claims = new Claims();

            Console.WriteLine("Please enter a new claim.");

            Console.WriteLine("Please enter a claim ID:");
            claims.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter Type of Claim from the List:\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft");
            string claimTypeInput = Console.ReadLine();

            int claimTypeID = int.Parse(claimTypeInput);

            claims.ClaimType = (ClaimType)claimTypeID;

            Console.WriteLine("Please enter a description of the claim.");
            claims.Description = Console.ReadLine();

            Console.WriteLine("Please enter an amount of the claims.");
            claims.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Date of the Incident.");
            claims.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Date of the Claim.");
            claims.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this a valid claim");

            _claimsrepo.AddClaimsToList(claims);
        }

        private void DisplayClaims(Claims claims)
        {
            Console.WriteLine($"Claim Id: {claims.ClaimID}\n" +
                $"Claim Type: {claims.ClaimType}\n" +
                $"Description: {claims.Description}\n" +
                $"Amount of Damage: $ {claims.ClaimAmount}\n" +    
                $"Date of Incident: {claims.DateOfIncident}\n" +
                $"Date of Claim: {claims.DateOfClaim}\n" +
                $"This claim is {claims.IsValid}\n");

        }

        private void SeedClaims()
        {
            Claims caraccident = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00, DateTime.Parse("4/25/2018"), DateTime.Parse("4/27/2018"), true);


            Claims housefire = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00, DateTime.Parse("4/11/2018"), DateTime.Parse("4/12/2018"), true);

            Claims pancakes = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4.00, DateTime.Parse("4/27/2018"), DateTime.Parse("6/1/2018"), false);



            _claimsrepo.AddClaimsToList(caraccident);
            _claimsrepo.AddClaimsToList(housefire);
            _claimsrepo.AddClaimsToList(pancakes);
        }


    }

}
