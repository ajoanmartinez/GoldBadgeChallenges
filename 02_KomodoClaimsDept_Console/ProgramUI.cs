using _02_KomodoClaimsDept_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsDept_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display menu options to user
                Console.WriteLine("Select a menu option\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                // Get user's input
                string input = Console.ReadLine();
                // Evlauate user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // View all claims
                        DisplayAllClaims();
                        break;
                    case "2":
                        // Take care of next claim
                        ServiceNextClaim();
                        break;
                    case "3":
                        // Enter a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }        
        }
        // View all claims
        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimsQueue = _claimRepo.GetClaimQueue();
            // Display Header
            var header = String.Format("{0,-12}{1,-10}{2,-30}{3,-12}{4,-20}{5,-20}{6,-7}\n",
                "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            Console.WriteLine(header);
            // Display all claims in queue 
            foreach(Claim claim in claimsQueue)
            {
                Console.WriteLine(String.Format("{0,-12}{1,-10}{2,-30}{3,-12}{4,-20}{5,-20}{6,-7}\n",
                    $"{claim.ClaimID}", $"{claim.TypeOfClaim}", $"{claim.Description}",$"{claim.ClaimAmount.ToString("C2")}", $"{claim.DateOfIncident.Date.ToString("d")}",
                    $"{claim.DateOfClaim.Date.ToString("d")}", $"{claim.IsValid}"));
            }
            
        }
        // Take care of next claim
        private void ServiceNextClaim()
        {
            // Call helper method to get next claim in queueu
            Claim nextClaim = _claimRepo.GetNextClaimInQueue();
            Console.WriteLine($"ClaimId:{nextClaim.ClaimID}\n" +
                $"Type:{nextClaim.TypeOfClaim}\n" +
                $"Description:{nextClaim.Description}\n" +
                $"Amount:{nextClaim.ClaimAmount.ToString("C2")}\n" +
                $"DateOfAccident:{nextClaim.DateOfIncident.Date.ToString("d")}\n" +
                $"DateOfClaim:{nextClaim.DateOfClaim.Date.ToString("d")}\n" +
                $"IsValid:{nextClaim.IsValid}");
           
            // Ask user if they want to deal with claim now
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            // Capture user's input
            string dealWithClaim = Console.ReadLine().ToLower();
            // Evaluate user's response and accordingly
            if(dealWithClaim != "n")
            {
                // Call Dequeue method
                bool wasDequeued = _claimRepo.TakeCareOfNexClaim();
                if (wasDequeued)
                {
                    Console.WriteLine("Claim was removed from queue.");
                }
                else
                {
                    Console.WriteLine("Could not remove claim from queue.");
                }
            }
            else
            {
                // Return user to main menu
                Console.Clear();
                Menu();
            }
            
        }
        // Enter a claim
        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();
            // Claim ID
            Console.WriteLine("Enter the claim id:");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);
            // Claim Type Enum
            /*  
              Car = 1,
              Home,
              Theft
            */
            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.TypeOfClaim = (ClaimType)claimTypeAsInt;
            // Claim description
            Console.WriteLine("Enter a claim description (20 Characters Max)");
            newClaim.Description = Console.ReadLine();
            // Claim amount
            Console.WriteLine("Enter amount of damage:");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(claimAmountAsString);
            // Date of accident
            Console.WriteLine("Date of Accident: Format: MM/DD/YY");
            DateTime dateOfIncident = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfIncident = dateOfIncident;
            // Date of claim
            Console.WriteLine("Date of Claim: Format: MM/DD/YY");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfClaim = dateOfClaim;
            // Is valid            
            if((newClaim.DateOfClaim - newClaim.DateOfIncident).Days < 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }
            //Add claim to queueu
            _claimRepo.AddClaimToQueue(newClaim);
        }
        // Seed method
        private void SeedClaimList()
        {         
            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 18), new DateTime(2018, 4, 12), true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);
        }

    }
}
