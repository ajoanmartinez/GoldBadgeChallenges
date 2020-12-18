using _03_KomodoBadges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges_Console
{
    class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            SeedDictionary();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display menu options to user
                Console.WriteLine("Select a menu option\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                // Get user's input 
                string input = Console.ReadLine();

                // Evaluate user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Add a badge
                        AddNewBadge();
                        break;
                    case "2":
                        // Edit a badge
                        EditExistingBadge();
                        break;
                    case "3":
                        // List all badges
                        DisplayAllBadges();
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
                Console.ReadLine();
                Console.Clear();
            }
        }
        // Add a badge
        private void AddNewBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();

            // Badge ID
            Console.WriteLine("Enter new badge ID:");
            string badgeIDAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDAsString);

            // Add door name from list
            Console.WriteLine("Add a door to new badge");
            newBadge.ListOfDoorNames.Add(Console.ReadLine());

            // Add another door name from list
            Console.WriteLine("Add another door to new badge (y/n)");
            string addAnotherDoor = Console.ReadLine().ToLower();
            while (addAnotherDoor != "n")
            {
                // Add door name from list
                Console.WriteLine("Add a door to new badge");
                newBadge.ListOfDoorNames.Add(Console.ReadLine());
                Console.WriteLine("Add another door to new badge (y/n)");
                addAnotherDoor = Console.ReadLine().ToLower();
            }

            _badgesRepo.AddBadgeToDictionary(newBadge.BadgeID, newBadge.ListOfDoorNames);

            // Return user to main menu
            Console.Clear();
            Menu();
        }

        // Edit a badge
        private void EditExistingBadge()
        {
            // Display all badges method here?


            Badges updateBadge = new Badges();

            // Prompt user for badge number
            Console.WriteLine("Enter the badge ID to update:");
            string badgeIDAsString = Console.ReadLine();
            updateBadge.BadgeID = int.Parse(badgeIDAsString);

            // Tell user what doors badge has access to through helper method
            List<string> doors = _badgesRepo.GetListOfDoors(updateBadge.BadgeID);
            string doorAccess = String.Join(",", doors);
            Console.WriteLine($"{updateBadge.BadgeID} has access to {doorAccess}");

            // Ask user what they would like to do 
            Console.WriteLine("What would you like to do?\n" +
                "1. Update doors\n" +
                "2. Remove all doors");

            string input = Console.ReadLine();

            // Evaluate user's input and act accordingly
            switch (input)
            {
                case "1":
                    //Update All Doors
                    Badges newDoors = new Badges();
                    Console.WriteLine("Enter the new list of doors.");
                    newDoors.ListOfDoorNames.Add(Console.ReadLine());
                    _badgesRepo.UpdateDoorsOnExistingBadge(updateBadge.BadgeID, newDoors.ListOfDoorNames);

                    // Tell user what doors badge has access to through helper method
                    List<string> newListOfDoors = _badgesRepo.GetListOfDoors(updateBadge.BadgeID);
                    string newDoorAccess = String.Join(",", newListOfDoors);


                    Console.WriteLine($"{updateBadge.BadgeID} has access to {newDoorAccess}");
                    break;
                case"2":
                    // Remove All doors
                    Console.WriteLine("Are you sure you want to remove all doors (y/n)?");
                    string removeDoors = Console.ReadLine().ToLower();
                    if (removeDoors == "y")
                    {
                        _badgesRepo.RemoveDoorsFromExistingBadge(updateBadge.BadgeID, updateBadge.ListOfDoorNames);
                        Console.WriteLine($"All doors removed from {updateBadge.BadgeID}.");
                        Console.WriteLine("Press any key to continue....");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    Menu();                                     
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;

   
            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadLine();
            Console.Clear();
          
        }

        // Dispaly all badges
        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgesDic = _badgesRepo.DisplayDictionary();

            // Display header
            var header = string.Format("{0,-9}{1,-9}\n",
                $"Badge #", "Door Access");
            Console.WriteLine(header);

            // Display list of doors
            //List<string> newListOfDoors = _badgesRepo.GetListOfDoors(int badgeID);
            //string newDoorAccess = String.Join(",", newListOfDoors);

            // Display dictionary
            foreach (KeyValuePair<int, List<string>> badges in badgesDic)
            {
                List<string> doors = _badgesRepo.GetListOfDoors(badges.Key);
                string doorAccess = String.Join(",", doors);
                Console.WriteLine($"{badges.Key,-9} {doorAccess}");

            }
            Console.ReadLine();
        }


        // Seed Dictionary
        private void SeedDictionary()
        {
            int badge1 = 1234;
            int badge2 = 9876;
            int badge3 = 5678;
            
            List<string> list1 = new List<string> { "A1", "B4" };
            List<string> list2 = new List<string> { "R5", "Y2", "K3" };
            List<string> list3 = new List<string> { "A7", "A5", "A6" };

            _badgesRepo.AddBadgeToDictionary(badge1, list1);
            _badgesRepo.AddBadgeToDictionary(badge2, list2);
            _badgesRepo.AddBadgeToDictionary(badge3, list3);
        }

      

    }
}
