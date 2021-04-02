using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_ChallengeTwo_Repository
{
   public class ClaimsRepository
    {
        public List<Claims> _claims = new List<Claims>();

        //Create
        public void AddClaimsToList(Claims claims)
        {
            _claims.Add(claims);
        }

        //Read
        public List<Claims> GetClaimsList()
            {
            return _claims;

        }

        public Claims GetClaimByID(int claimID)
        {
            foreach (Claims claims in _claims)
            {
                if (claims.ClaimID == claimID)
              
                    return claims;
            
            }

            return null;
        }


        //Update

        //Delete
    }
}
