using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeThree_Repo
{
    public class BadgeRepo
    {
        public List<Badge> _listOfBadges = new List<Badge>();
        Dictionary<int, string> bid = new Dictionary<int, string>();
       // Dictionary<int, string> bid = new Dictionary<int, string>();
        //Create
        public void AddDoorAccess(Badge badge)
        {
            _listOfBadges.Add(badge);
            // bid.Add( badge.BadgeID, badge.ListOfDoors);
        }

        //Read
        public List<Badge> GetBadges()
        {
            return _listOfBadges;
        }
        
 

        //Update
        public bool UpdateBadgeAccess(int originalBadgeID, Badge newBadge)
        {
            Badge oldBadge = GetBadgeById(originalBadgeID);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.ListOfDoors = newBadge.ListOfDoors;

                return true;

            }
            else
            {
                return false;
            }

        }





        //Delete
        public bool RemoveDoorAccessFromBadge(int badgeID)
        {
            Badge badge = GetBadgeById(badgeID);

            if (badge == null)
            {
                return false;
            }
            int initialCount = _listOfBadges.Count;
            _listOfBadges.Remove(badge);

            if (initialCount > _listOfBadges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Badge GetBadgeById(int badgeId)
        {
            foreach (Badge badge in _listOfBadges)
            {
                if (badge.BadgeID == badgeId)
                {
                    return badge;
                }

            }
            return null;
        }
        public void CreateDictionary()
        {
            Dictionary<int, string> bid = new Dictionary<int, string>();

           

            bid.Add(12345, "A7");
            bid.Add(22345, "A1");
            bid.Add(22345, "A4");
            bid.Add(22345, "B1");
            bid.Add(22345, "B2");
            bid.Add(32345, "A4");
            bid.Add(32345, "A5");

          //  bid.Add(12345, _listOfBadges);
            
            Console.WriteLine("Badge List");
            
               foreach (KeyValuePair<int, string> badge in bid)
               {
                   Console.WriteLine($"Badge ID: {0}, Door Access: {1}", badge.Key, badge.Value); 
              }
        }

       
        
    }
}
