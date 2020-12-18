using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsDept_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _Claims = new Queue<Claim>();
        // Display all claims
        public Queue<Claim> GetClaimQueue()
        {
            return _Claims;
        }
        // Take care of next claim
        public bool TakeCareOfNexClaim()
        {            
            if(_Claims.Count == 0)
            {
                return false;
            }
            int initialCount = _Claims.Count;
            _Claims.Dequeue();
            if (initialCount > _Claims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Enter a new claim
        public void AddClaimToQueue(Claim claim)
        {
            _Claims.Enqueue(claim);
        }

        // Helper Method
        public Claim GetNextClaimInQueue()
        {
            Claim claim = _Claims.Peek();
            return claim;
        }

    }
}
