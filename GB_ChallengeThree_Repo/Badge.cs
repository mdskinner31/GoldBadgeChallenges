using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeThree_Repo
{
   
    public class Badge
    {
        public int BadgeID { get; set; }
        public string DoorName { get; set; }
        public string DoorNameTwo { get; set; }
        public string DoorNameThree { get; set; }
        public string DoorNameFour { get; set; }



        public Badge() { }

        public Badge(int badgeID, string doorName, string doorNameTwo, string doorNameThree, string doorNameFour) 
        {
            BadgeID = badgeID;
            DoorName = doorName;
            DoorNameTwo = doorNameTwo;
            DoorNameThree = doorNameThree;
            DoorNameFour = doorNameFour;

        }

        public static Dictionary<int, Badge> GetBadges()
        {
            var badges = new Dictionary<int, Badge>();
            var theBadge = new Badge("A1", "A4", "B1", "B2");
            badges.Add(22345, theBadge);
            theBadge = new Badge("A4", "A5");
            badges.Add(32345, theBadge);

            return badges;
        }

    }
}
