using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace VotingSystem.BlockChainSystem
{
    // clasa Block care reprezintă un bloc într-un lanț de blockchain
    public class Block
    {
        private readonly DateTime _timeStamp;// stochează data și ora creării blocului.
        private long _nonce; //variabilă utilizată pentru a efectua operații de proof-of-work în minarea blocului.

        public string PreviousHash { get; set; }// reprezintă hash-ul blocului anterior în lanțul blockchain.
        public List<VoteTransaction> Transactions { get; set; }// listă de obiecte VoteTransaction care reprezintă tranzacțiile în bloc.
        public string Hash { get; private set; }//hash-ul blocului curent.

        public Guid PeriodID { get; }//identificator unic asociat perioadei în care este efectuat votul.

        //constructor
        public Block(DateTime timeStamp, Guid periodId, List<VoteTransaction> transactions, string previousHash = "")
        {
            _timeStamp = timeStamp;
            _nonce = 0;

            PeriodID = periodId;
            Transactions = transactions;
            PreviousHash = previousHash;
            Hash = CreateHash();//genereaza hash-ul blocului curent
        }

        //utilizată pentru a efectua proof-of-work și pentru a mina blocul.
        public void MineBlock()
        {
            var proofOfWorkDifficulty = 3;//nivel de dificultate pentru proof-of-work
            string hashValidationTemplate = new string('0', proofOfWorkDifficulty);// șablon de validare a hash-ului, in cazul nostru va fi '000'

            //În timp ce primele proofOfWorkDifficulty caractere ale hash-ului blocului nu corespund șablonului de validare
            while (Hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                _nonce++;
                Hash = CreateHash();//e recalculează hash-ul blocului
            }

            Console.WriteLine("Blocked with HASH={0} successfully mined!", Hash);
        }

        // utilizată pentru a crea hash-ul blocului
        // pe baza hash-ului blocului anterior, timestamp-ului, listei de tranzacții și nonce-ului.
        public string CreateHash()
        {
            //Se utilizează algoritmul SHA256 pentru a calcula hash-ul
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = PreviousHash + _timeStamp + Transactions + _nonce;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Encoding.Default.GetString(bytes);
            }
        }
    }
}
