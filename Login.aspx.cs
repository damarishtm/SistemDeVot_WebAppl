using System;
using System.Web.UI;
using System.Data.SqlClient;
using SistemDeVot_WebAppl.Models;
using System.Security.Policy;

namespace SistemDeVot_WebAppl
{
    public partial class Login : System.Web.UI.Page
    {
        
        public static string ConnectionString = "Data Source=DESKTOP-ITOM3NS;Initial Catalog=HTMDAM;Integrated Security=True";

        private SqlConnection con = new SqlConnection(ConnectionString);
        private SqlCommand cmd;
        private SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica daca pagina a fost incarcata pentru prima data sau nu
            //Daca pagina este incarcata pentru prima data, codul din interiorul blocului "if" se va executa.
            if (!Page.IsPostBack)
            {
                try
                {
                    // se deschide o conexiune cu baza de date
                    con.Open(); 
                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    //Daca apare o exceptie in blocul "try", mesajul de eroare este afisat in obiectul Label1. 
                    Label1.Text = "Nu se poate realiza conexiunea " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }


        }

        //buton Autentificare
        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "";
            try
            {
                //se deschide o conexiune cu baza de date folosind obiectul "con" de tip SqlConnection

                con.Open();
                // Daca conexiunea se poate realiza,
                // se creeaza un obiect de tip SqlCommand cu interogarea SQL "select Parola from Users where AdresaMail='" + TextBox2.Text +"'",
                // care selecteaza parola utilizatorului selectat din obiectul TextBox2.

                cmd = new SqlCommand("select * from Users where AdresaMail='" + TextBox2.Text + "'", con);

                //Interogarea este executata cu ajutorul metodei "ExecuteReader()"-- Aceasta metoda returneaza un obiect SqlDataReader, stocat in variabila "dr".

                dr = cmd.ExecuteReader();

                //Daca nu se poate citi niciun rand din rezultatul interogarii 

                if (!dr.Read())
                {
                    //afiseaza un mesaj de eroare in obiectul Label1.

                    Label1.Text = "Utilizatorul nu exista!";
                }
                else//Daca se poate citi cel putin un rand din rezultatul interogarii
                {
                    var userId = (Guid)dr["UserID"];
                    var email = dr["AdresaMail"].ToString();
                    var parola = dr["Parola"].ToString();
                    var nume = dr["Nume"].ToString();
                    var role = (Role) Enum.Parse(typeof(Role), dr["UserRole"].ToString());

                    var user = new User(userId, email, nume, role);

                    //se compara parola din baza de date cu cea introdusa de utilizator in obiectul TextBox1.
                    //Daca cele doua parole coincid,

                    if (parola == TextBox1.Text.Trim())
                    {
                        Application["user"] = user; // daca variabila globala user este setata, consideram utilizatorul autentificat. 

                        //se verifica daca utilizatorul autentificat este administratorul

                        if (user.UserRole == Role.Admin)
                        {
                            //daca da, se redirectioneaza catre pagina AdministratorPage.aspx

                            url = "AdministratorPage.aspx";
                        }
                        else
                        {
                            // se redirecționează utilizatorul către pagina Candidati.aspx și se afiseaza continutul acesteia.

                            url = "Candidati.aspx";
                        }
                    }
                    else//In caz contrar
                    {
                        // afiseaza un mesaj de eroare in obiectul Label1.
                        Label1.Text = "Parola gresita!";
                    }
                }
            }
            catch (Exception ex)
            {
                //Daca apare o exceptie in blocul "try", mesajul de eroare este afisat in obiectul Label1.
                Label1.Text = "Nu se poate realiza conexiunea " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            if(!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url);
            }
        }

        //buton Creati un cont
        protected void Button2_Click(object sender, EventArgs e)
        {
            string url;
            url = "CreareCont.aspx";
            Response.Redirect(url);
        }
    }
}