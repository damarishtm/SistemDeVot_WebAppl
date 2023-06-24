using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingSystem.BlockChainSystem
{
    public class BlockChain
    {
        private List<VoteTransaction> _pendingTransactions;//listă de tranzacții de vot în așteptare
        public List<Block> Chain { get; set; }

        //constructor
        public BlockChain()
        {
            // Inițializăm lista de tranzacții în așteptare și lanțul blockchain cu un bloc de geneză.

            _pendingTransactions = new List<VoteTransaction>();

            Chain = new List<Block> { CreateGenesisBlock() };
        }


        public void CreateTransaction(VoteTransaction transaction)
        {
            // Adăugăm o tranzacție în lista de tranzacții în așteptare.

            _pendingTransactions.Add(transaction);
        }

        public void AddBlock(Guid periodId)
        {
            // Adăugăm un nou bloc în lanțul blockchain.

            Block block = new Block(DateTime.Now, periodId, _pendingTransactions);

            // Realizăm minarea blocului pentru a obține hash-ul valid.

            block.MineBlock();

            //leagăm hash-ul blocului curent de hash-ul blocului anterior

            block.PreviousHash = Chain.Last().Hash;

            // Adăugăm blocul nou creat în lanțul blockchain.

            Chain.Add(block);

            // Resetează lista de tranzacții în așteptare pentru a permite noi tranzacții în viitor.

            _pendingTransactions = new List<VoteTransaction>();
        }

        public bool IsValidChain()//verificăm integritatea lanțului blockchain:
        {
            //iteram printre blocurile lantului
            for (int i = 1; i < Chain.Count; i++)
            {

                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];

                // Verificăm dacă hash-ul blocului curent corespunde cu hash-ul generat pe baza datelor din bloc.

                if (currentBlock.Hash != currentBlock.CreateHash())
                    return false;

                // Verificăm dacă hash-ul blocului anterior corespunde cu hash-ul anteriorului bloc din lanț.

                if (currentBlock.PreviousHash != previousBlock.Hash)

                    return false;
            }

            // Dacă toate blocurile au fost verificate și nu au apărut discrepanțe, returnăm true.

            return true;
        }

        public int GetVotes(Guid candidatId, Guid periodId) //obține numărul de voturi pentru un candidat într-un anumit interval de timp
        {
           
            var nrVoturi = 0;

            // Căutăm blocul corespunzător intervalului de timp specificat.

            var block = this.Chain.FirstOrDefault(b => b.PeriodID == periodId);

            if (block != null)
            {
                // Iterăm prin tranzacțiile din bloc și numărăm voturile pentru candidatul specificat.

                foreach (VoteTransaction transaction in block.Transactions)
                {
                    if (transaction.CandidatID == candidatId)
                    {
                        nrVoturi++;
                    }
                }
            }

            // Returnăm numărul de voturi pentru candidatul specificat.

            return nrVoturi;
        }

        private Block CreateGenesisBlock()
        {
            // Creăm blocul de geneză, care este primul bloc din lanțul blockchain și conține o tranzacție golă.

            var transactions = new List<VoteTransaction> { new VoteTransaction(Guid.Empty) };
            return new Block(DateTime.Now, Guid.Empty, transactions, "0");
        }
    }
}
