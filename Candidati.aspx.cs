using SistemDeVot_WebAppl.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using VotingSystem.BlockChainSystem;

namespace SistemDeVot_WebAppl
{



    public partial class Candidati : System.Web.UI.Page
    {
        //*******************************************************
        public static List<Candidat> GetCandidati(Guid periodId)
        {
            var candidati = new List<Candidat>();

            //Conexiunea la baza de date
            string connectionString = Login.ConnectionString;

            using (SqlConnection connnection = new SqlConnection(connectionString))
            {
                //deschidere conexiune
                connnection.Open();

                //Interogare pentru a obtine candidatii din baza de date
                string query = "SELECT CandidatID, Nume, Varsta, Partid FROM Candidati WHERE PeriodID = @periodId";

                //Obtineti un obiect SqlCommand pentru a executa interogarea
                using (SqlCommand command = new SqlCommand(query, connnection))
                {
                    command.Parameters.AddWithValue("periodId", periodId);

                    //executa interogarea si obtineti un cititor SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Citim randurile si adaugam fiecare candidat
                        while (reader.Read())
                        {
                            var candidatId = reader.GetGuid(0);
                            var nume = reader.GetString(1);
                            var varsta = reader.GetInt32(2);
                            var partid = reader.GetString(3);

                            var candidat = new Candidat(candidatId, nume, partid, varsta);
                            candidati.Add(candidat);
                        }
                    }

                }

            }

            return candidati;

        }
        //**************************************************************************


        public static Perioada GetCurrentPeriod()
        {
            using (SqlConnection connnection = new SqlConnection(Login.ConnectionString))
            {
                //deschidere conexiune
                connnection.Open();

                //Interogare pentru a obtine candidatii din baza de date
                string query = "SELECT PeriodID, StartDate, EndDate FROM Perioade WHERE Active = 1";

                //Obtineti un obiect SqlCommand pentru a executa interogarea
                using (SqlCommand command = new SqlCommand(query, connnection))
                {
                    //executa interogarea si obtineti un cititor SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //Citim randurile si adaugam fiecare candidat
                        if (reader.Read())
                        {
                            var periodId = reader.GetGuid(0);
                            var startDate = reader.GetDateTime(1);
                            var endDate = reader.GetDateTime(2);

                            var perioada = new Perioada(periodId, startDate, endDate, true);
                            return perioada;
                        }
                    }

                }

            }

            return new Perioada() { IsActive = false };
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // verificam daca utilizatorul este autentificat
            var user = Application["user"] as User;

            if(user == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                // selectam perioada curenta
                var currentPeriod = GetCurrentPeriod();
                var periodId = currentPeriod.IsActive? currentPeriod.PeriodID : Guid.Empty;

                //se obțin toți candidații din baza de date care sunt stocati in lista
                var candidati = Candidati.GetCandidati(periodId);
                foreach (Candidat candidat in candidati)
                {
                    //fiecare element din această listă este adăugat în controlul RadioButtonList1 ca element nou în listă
                    var text = $"{candidat.Nume}, {candidat.Varsta} ani, partidul {candidat.Partid}";
                    var value = candidat.CandidatId.ToString();
                    RadioButtonList1.Items.Add(new ListItem(text, value));
                }

                // Verificam daca ne aflam in perioada alegerilor
                if(DateTime.Now < currentPeriod.PeriodStartDate ||  DateTime.Now > currentPeriod.PeriodEndDate)
                {
                    Button1.Visible = false;
                    Label.Text = "Astazi nu puteti efectua votul. Perioada alegerilor este:" +
                        currentPeriod.PeriodStartDate.ToShortDateString() + " - " +
                        currentPeriod.PeriodEndDate.ToShortDateString();
                    return;
                }

                // Verificam daca utilizatorul a mai efectuat un vot pentru perioada curenta
                if(!this.CheckCurrentPeriod(periodId, user.UserID))
                {
                    Button1.Visible = false;
                    Label.Text = "Nu puteti efectua un al doilea vot!";
                }
            }
        }

        private bool CheckCurrentPeriod(Guid periodId, Guid userId)
        {
            using (SqlConnection connnection = new SqlConnection(Login.ConnectionString))
            {
                connnection.Open();

                string query = "SELECT COUNT(*) FROM Istoric WHERE PeriodID = @period AND UserID = @user";

                using (SqlCommand command = new SqlCommand(query, connnection))
                {
                    command.Parameters.AddWithValue("period", periodId);
                    command.Parameters.AddWithValue("user", userId);

                    var rows = (int)command.ExecuteScalar();

                    return rows == 0;
                }
            }
        }

        //butonul Trimite
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem == null)
            {
                // nici o opțiune nu este selectată
                Label.Text = "Vă rugăm să selectați un candidat!";
                Label.Visible = true;
            }
            else
            {
                // selectam ID-ul candidatului ales
                var selectedCandidatId = Guid.Parse(RadioButtonList1.SelectedValue);

                // Salvam in istoric
                var user = Application["user"] as User;
                var currentPeriod = GetCurrentPeriod();
                using (var con = new SqlConnection(Login.ConnectionString))
                {
                    con.Open();

                    string query = "INSERT INTO Istoric (UserID, PeriodID, NumeUtilizator, Perioada) VALUES (@userId, @periodId, @nume, @period)";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@userId", user.UserID);
                        command.Parameters.AddWithValue("@periodId", currentPeriod.PeriodID);
                        command.Parameters.AddWithValue("@nume", user.Nume);
                        command.Parameters.AddWithValue("@period", $"{currentPeriod.PeriodStartDate.ToShortDateString()} - {currentPeriod.PeriodEndDate.ToShortDateString()}");
                        try
                        {
                            var blockchain = Session["blockchain"] as BlockChain ?? new BlockChain();

                            var vote = new VoteTransaction(selectedCandidatId);
                            blockchain.CreateTransaction(vote);

                            command.ExecuteNonQuery();

                            Session["blockchain"] = blockchain;

                            //mesaj de succes
                            Label.Text = "Votul s-a efectuat cu succes!";
                            
                        }
                        catch (Exception ex)
                        {
                            //Daca apare o exceptie in blocul "try", mesajul de eroare este afisat in obiectul Label1.
                            Label.Text = "Nu s-a putut actualiza baza de date!";
                        }
                    }
                }

               

                // dezactivex controlul RadioButtonList
                RadioButtonList1.Enabled = false;
            }
        }

        //butonul Logout
        protected void Button2_Click(object sender, EventArgs e)
        {
            Application["user"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void ButtonRezultate_Click(object sender, EventArgs e)
        {
            Response.Redirect("RezultateVot.aspx");
        }
    }
}