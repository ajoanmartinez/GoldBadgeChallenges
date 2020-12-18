using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges_Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoorNames { get; set; } = new List<string>();
        public Badges() { }
        public Badges(int badgeID, List<string> doorNamesList)
        {
            BadgeID = badgeID;
            ListOfDoorNames = doorNamesList;
        }
    }
}
