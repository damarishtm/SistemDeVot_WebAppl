using System;

namespace VotingSystem.BlockChainSystem
{
    public class VoteTransaction
    {
        public VoteTransaction(Guid candidatId)
        {
            this.VoteID = Guid.NewGuid();
            this.CandidatID = candidatId;
            this.Date = DateTime.Now;
        }

        /// <summary>
        /// Identificatorul unic al votului
        /// </summary>
        public Guid VoteID { get; }   

        /// <summary>
        /// Identificatorul unic al optiunii alese
        /// </summary>
        public Guid CandidatID { get; }

        /// <summary>
        /// Data votului efectuat
        /// </summary>
        public DateTime Date { get; }
    }
}
