using System;

namespace SistemDeVot_WebAppl.Models
{
    public enum Role
    {
        Admin = 0,
        Alegator = 1
    }

    public class User
    {
        public User(Guid userId, string email, string nume, Role role)
        {
            this.UserID = userId;
            this.AdresaMail = email;
            this.Nume = nume;
            this.UserRole = role;
        }

        public Guid UserID { get; }
        public string AdresaMail { get; }
	    public string Nume { get; }
	    public Role UserRole { get; }
    }
}
