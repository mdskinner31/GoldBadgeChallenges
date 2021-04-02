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
        public List<string> listOfDoors = new List<string>();
        public string ListOfDoors;
        



        public Badge() { }

        public Badge(int badgeID, string listOfDoors) 
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
            

        }

        
        

    }
}
