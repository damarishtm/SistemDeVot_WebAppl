using System;

namespace SistemDeVot_WebAppl.Models
{
    public class Candidat
    {
        public Candidat(Guid id, string nume, string partid, int varsta)
        {
            this.CandidatId = id;
            this.Nume = nume;
            this.Varsta = varsta;
            this.Partid = partid;
        }

        public Guid CandidatId { get; }

        public string Nume { get; }
        //public string Prenume { get; }
        public string Partid { get;}
        public int Varsta { get;}
    }
}
