using SistemDeVot_WebAppl.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace SistemDeVot_WebAppl
{
    public partial class AdministratorPage : System.Web.UI.Page
    {
        private List<Perioada> _allPeriods;

        private List<Perioada> GetPeriods()
        {
            var periods = new List<Perioada>();
            using (SqlConnection connection = new SqlConnection(Login.ConnectionString))
            {
                connection.Open();

                string query = "SELECT PeriodID, StartDate, EndDate, Active FROM Perioade";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetGuid(0);
                            var start = reader.GetDateTime(1);
                            var end = reader.GetDateTime(2);
                            var isActive = reader.GetBoolean(3);

                            var perioada = new Perioada(id, start, end, isActive);
                            periods.Add(perioada);
                        }
                    }

                }
                connection.Close();
            }

            _allPeriods = periods;
            return periods;
        }

        //**********************************************************************************************tot ce e aici
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


            // Incarcam lista de perioade
            var periods = this.GetPeriods();

            if (!IsPostBack)
            {
                var items = periods
                    .OrderBy(p => !p.IsActive)
                    .Select(p => new ListItem($"{p.PeriodStartDate.ToShortDateString()} - {p.PeriodEndDate.ToShortDateString()}{(p.IsActive? ", activa" : string.Empty)}", p.PeriodID.ToString()))
                    .ToArray();
                this.DropDownPeriodList.Items.AddRange(items);

                this.DropDownList1_SelectedIndexChanged(null, e);
            }
            
        }

        //butonul Sterge
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem != null)
            {
                //obținem textul elementului selectat din controlul "RadioButtonList1" și îl atribuie variabilei "candidatSelectat".
                Guid candidatSelectatId = Guid.Parse(RadioButtonList1.SelectedItem.Value);
               
                string connectionString = Login.ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //comanda SQL pe care o vom executa. Ea va șterge toate datele candidatului cu numele specificat din tabela "Candidati".
                    string query = "DELETE FROM Candidati WHERE CandidatID = @id";
                    //definim comanda și conexiunea cu care va fi executată comanda.
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", candidatSelectatId);
                        //execută efectiv comanda SQL pe baza de date.
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Reîncarcă lista cu candidați pentru a afișa schimbările
                var selectedPeriodId = this.GetSelectedPeriodId();
                this.RefreshCandidati(selectedPeriodId);
            }
        }

        private void RefreshCandidati(Guid selectedPeriodId)
        {
            List<Candidat> candidati = Candidati.GetCandidati(selectedPeriodId);
            RadioButtonList1.Items.Clear();
            foreach (var candidat in candidati)
            {
                //fiecare element din această listă este adăugat în controlul RadioButtonList1 ca element nou în listă
                var text = $"{candidat.Nume}, {candidat.Varsta} ani, partidul {candidat.Partid}";
                var value = candidat.CandidatId.ToString();
                RadioButtonList1.Items.Add(new ListItem(text, value));
            }
        }


        //buton adauga
        protected void Button1_Click(object sender, EventArgs e)
        {
            var selectedPeriodId = this.GetSelectedPeriodId();
            string url = $"AdaugaCandidati.aspx?period={selectedPeriodId}";
            Response.Redirect(url);
        }

        //buton log out
        protected void Button5_Click(object sender, EventArgs e)
        {
            string url = "Login.aspx";
            Application["user"] = null;
            Response.Redirect(url);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string url = "AdministratorPage.aspx";
            Response.Redirect(url);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPeriodId = this.GetSelectedPeriodId();
            var perioada = this._allPeriods.FirstOrDefault(p => p.PeriodID == selectedPeriodId);

            var editable = perioada != null && perioada.IsActive;

            Button1.Visible = editable;
            Button4.Visible = editable;

            this.RefreshCandidati(selectedPeriodId);
        }

        private Guid GetSelectedPeriodId()
        {
            return Guid.Parse(this.DropDownPeriodList.SelectedValue);
        }
    }
}