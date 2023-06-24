using SistemDeVot_WebAppl.Models;
using System;
using System.Data.SqlClient;
using VotingSystem.BlockChainSystem;

namespace SistemDeVot_WebAppl
{
    public partial class EditeazaListaCandidati : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // verificam daca utilizatorul este autentificat
            var user = Application["user"] as User;

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (user.UserRole != Role.Admin)
            {
                this.Page.Show("Nu aveti permisiunea sa accesati aceasta pagina!");
                Response.Redirect("Candidati.aspx");
                return;
            }


            this.SeteazaPerioadaActiva();
        }

        private void SeteazaPerioadaActiva()
        {
            var currentPeriod = Candidati.GetCurrentPeriod();
            LabelCurrentPeriod.Text = currentPeriod.IsActive
                ? $"Perioada activa: \n{currentPeriod.PeriodStartDate.ToShortDateString()} - {currentPeriod.PeriodEndDate.ToShortDateString()}"
                : "Nu exista perioada activa";
        }

        //buton editeaza lista candidati
        protected void Button2_Click(object sender, EventArgs e)
        {
            string url = "EditeazaListaCandidati.aspx";
            Response.Redirect(url);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string url = "Login.aspx";
            Application["user"] = null;
            Response.Redirect(url);
        }

        //buton rezultate vot
        protected void Button3_Click(object sender, EventArgs e)
        {

            string url = "RezultateVot.aspx";
            Response.Redirect(url);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CalendarStart.Visible = true;
            CalendarEnd.Visible = true;
            LabelCurrentPeriod.Visible = true;
            ButtonAddPeriod.Visible = true;
            ButtonRemoveActivePeriod.Visible = true;
        }

        //buton adauga perioada
        protected void ButtonAddPeriod_Click(object sender, EventArgs e)
        {
            //extrage data selectată de utilizator în calendarul "CalendarStart" și o stochează în variabila "startDate".
            var startDate = CalendarStart.SelectedDate;
            var endDate = CalendarEnd.SelectedDate.AddHours(23).AddMinutes(59);



            if (startDate < DateTime.Now.AddDays(-1) || endDate < startDate)
            {
                // Afisare mesaj date invalide
                Label2.Text = "Introduceti date valide!";
                return;
            }

            RemoveActivePeriods(); // Eliminam orice perioada care a marcata ca fiind activa si adaugam una noua
            var query = $"INSERT INTO Perioade (PeriodID, StartDate, EndDate, Active) VALUES (NEWID(), @start, @end, 1)";

            using (SqlConnection connnection = new SqlConnection(Login.ConnectionString))
            {
                connnection.Open();

                using (SqlCommand command = new SqlCommand(query, connnection))
                {
                    //adaugă o valoare parametrizată "@start"/@end în interogare, utilizând valoarea din variabila "startDate".
                    command.Parameters.AddWithValue("@start", startDate);
                    command.Parameters.AddWithValue("@end", endDate);
                    command.ExecuteNonQuery();
                }
            }

            this.SeteazaPerioadaActiva();

            // Cream block-chain-ul daca nu este creat
            var blockchain = Session["blockchain"] as BlockChain;
            if(blockchain == null)//daca "blockchain" nu este in sesiune
            {
                //creează un nou obiect "BlockChain" și îl atribuie variabilei "blockchain".
                blockchain = new BlockChain();
                //stochează obiectul "blockchain" în sesiune, astfel încât să poată fi accesat ulterior în alte părți ale aplicației.
                Session["blockchain"] = blockchain;
            }
        }

        protected void ButtonRemoveActivePeriod_Click(object sender, EventArgs e)
        {
            RemoveActivePeriods();
            this.SeteazaPerioadaActiva();
        }

        public static void RemoveActivePeriods()
        {
            var query = "UPDATE Perioade SET Active = 0 WHERE Active = 1";

            using (SqlConnection connnection = new SqlConnection(Login.ConnectionString))
            {
                connnection.Open();

                using (SqlCommand command = new SqlCommand(query, connnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}