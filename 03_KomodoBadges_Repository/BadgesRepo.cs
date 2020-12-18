using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges_Repository
{
    public class BadgesRepo
    {
        private Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        private List<string> _listOfDoorNames = new List<string>();

        // Create new badge
        public void AddBadgeToDictionary(int badgeID, List<string> doorNamesList)
        {
            _badges.Add(badgeID, doorNamesList);
        }

        // Update doors on existing badge
        public void UpdateDoorsOnExistingBadge(int badgeID, List<string> listOfDoors)
        {
            if (_badges.ContainsKey(badgeID))
            {
                _badges[badgeID] = listOfDoors;
            }
        }

        // Delete doors from an existing badge
        public bool RemoveDoorsFromExistingBadge(int badgeID, List<string> listOfDoors)
        {
            if (_badges.ContainsKey(badgeID))
            {
                _listOfDoorNames.Except(listOfDoors);
                return true;
            }
            else
            {
                return false;
            }          

        }

        // Display all badge numbers and door access
        public Dictionary<int, List<string>> DisplayDictionary()
        {
            return _badges;
        }

        // Display all list of doors
        public List<string> DisplayListOfDoorNames()
        {
            return _listOfDoorNames;
        }



        // Helper Method 
        public List<string> GetListOfDoors(int badgeID)
        {
            if (_badges.TryGetValue(badgeID, out List<string> doors))
            {
                return doors;
            }
            return null;
        }


    }

}



