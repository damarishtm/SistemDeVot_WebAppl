using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using SistemDeVot_WebAppl.Models;

namespace SistemDeVot_WebAppl
{
    public partial class AdaugaCandidati : System.Web.UI.Page
    {
        private Guid _periodId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // verificam daca utilizatorul este autentificat
            var user = Application["user"] as User;

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

            if(user.UserRole != Role.Admin)
            {
                this.Page.Show("Nu aveti permisiunea sa accesati aceasta pagina!");
                Response.Redirect("Candidati.aspx");
                return;
            }

            this._periodId = Guid.Parse(Request.QueryString["period"].ToString());
        }

        //buton adauga
        protected void Button1_Click(object sender, EventArgs e)
        {



            /*
             * **********************************Explicatie regEx*********************************************
             * 
             * [a-zA-Z\s] definește un set de caractere permise. În acest caz, litera mică a-z, litera mare A-Z și \s care reprezintă un spațiu alb (inclusiv spațiu, tab și linie nouă).
             * '+ ' indică că șirul trebuie să conțină una sau mai multe astfel de caractere.
             * $ semnifică sfârșitul șirului.
             * \d reprezintă o cifră (0-9).
             */

            var nume = TextBox1.Text;
            var partid = TextBox3.Text;

            //validarea numelui utilizand expresie regulata
            if (!Regex.IsMatch(nume, @"^[a-zA-Z\s]+$"))
            {
                Label6.Text = "Numele candidatului trebuie sa conțină doar litere și spații!";
                return;
            }
            else
            {
                //validarea varstei
                try
                {
                    var varsta = int.Parse(TextBox2.Text);
                    if (!Regex.IsMatch(varsta.ToString(), @"^\d+$") || varsta < 20 || varsta > 99)
                    {
                        Label6.Text = "Varsta trebuie sa fie un numar intre 20 si 99!";
                        return;
                    }
                    else
                    {
                        // Creează conexiunea cu baza de date
                        SqlConnection conn = new SqlConnection(Login.ConnectionString);

                        // Definește comanda SQL pentru inserarea datelor
                        string insertQuery = "INSERT INTO Candidati (CandidatID, PeriodID, Nume, Varsta, Partid) VALUES (NEWID(), @period, @Nume, @Varsta, @Partid)";
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);

                        // Adaugă parametrii pentru valorile din TextBox-uri
                        cmd.Parameters.AddWithValue("@Nume", nume);
                        cmd.Parameters.AddWithValue("@period", this._periodId);
                        cmd.Parameters.AddWithValue("@Varsta", varsta);
                        cmd.Parameters.AddWithValue("@Partid", partid);

                        try
                        {
                            // Deschide conexiunea și execută comanda SQL
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            // Redirecționează utilizatorul către o altă pagină dacă inserarea s-a efectuat cu succes
                            Response.Redirect("EditeazaListaCandidati.aspx");
                        }
                        catch (Exception ex)
                        {
                            // Afișează mesajul de eroare într-un Label
                            Label6.Text = "Eroare la inserare: " + ex.Message;
                        }
                        finally
                        {
                            // Închide conexiunea cu baza de date
                            conn.Close();
                        }
                    }
                }
                catch
                {
                    Label6.Text = "Varsta trebuie sa fie un numar intre 20 si 99!";
                    return;
                }
            }
        }
    }
}