using SistemDeVot_WebAppl.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using VotingSystem.BlockChainSystem;

namespace SistemDeVot_WebAppl
{
    public partial class RezultateVot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // verificam daca utilizatorul este autentificat
            var user = Application["user"] as User;

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {


                var currentPeriod = Candidati.GetCurrentPeriod();
                // Verificam daca ne aflam in perioada alegerilor
                 if (DateTime.Now <= currentPeriod.PeriodEndDate)
                {
                    LabelTitlu.Text = "Perioada alegerilor nu s-a incheiat!";
                    return;
                }

                if (user.UserRole == Role.Admin)
                {
                    // Finalizam rezultatele, daca s-a incheiat perioada alegerilor
                    EditeazaListaCandidati.RemoveActivePeriods();
                    var blockchain = Session["blockchain"] as BlockChain;
                    if (blockchain != null && currentPeriod.PeriodID != Guid.Empty)
                    {
                        blockchain.AddBlock(currentPeriod.PeriodID);
                    }
                }

                // String de conexiune la baza de date
                string connectionString = Login.ConnectionString;

                // Interogare SQL pentru a prelua datele despre candidati din tabela 'Candidati'
                string query = "SELECT CandidatID, Nume, Varsta, Partid FROM Candidati WHERE PeriodID=@period";

                // Crearea conexiunii la baza de date
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Deschiderea conexiunii
                    connection.Open();

                    // Crearea obiectului de comanda si specificarea interogarii SQL si conexiunii
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@period", currentPeriod.PeriodID);
                        // Executarea interogarii SQL si citirea datelor
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            /*// Iterarea prin fiecare rand de date si afisarea acestuia in TextBox1
                            while (reader.Read())
                            {
                                string nume = reader.GetString(0);
                                int varsta = reader.GetInt32(1);
                                string partid = reader.GetString(2);
                                int nrVoturi = 0;

                                if (!reader.IsDBNull(3))
                                {
                                    nrVoturi = reader.GetInt32(3);
                                }

                                TextBox1.Text += $"Nume: {nume}, Varsta: {varsta}, Partid: {partid}, Nr_Voturi: {nrVoturi} \n";*/

                            //setarea datelor din SqldataReader ca sursa de date pt GridView
                            var resultTable = new DataTable();
                            resultTable.Load(reader);

                            resultTable.Columns.Add("Voturi", typeof(int));
                            var blockchain = Session["blockchain"] as BlockChain;
                            foreach (DataRow row in resultTable.Rows)
                            {
                                var candidatId = Guid.Parse(row["CandidatID"].ToString());
                                var voturi = blockchain.GetVotes(candidatId, currentPeriod.PeriodID);
                                row["Voturi"] = voturi;
                            }

                            resultTable.Columns.Remove("CandidatID");

                            // Sortam datele, primul candidat pe primul loc
                            var sortColumn = resultTable.Columns["Voturi"] + " DESC";
                            resultTable.DefaultView.Sort = sortColumn;

                            GridView1.DataSource = resultTable;
                            GridView1.DataBind();
                            if(GridView1.Rows.Count > 0)
                            {
                                GridView1.Rows[0].BackColor = System.Drawing.Color.Yellow;
                            }
                        }
                    }
                }
            }
        }
    

            //buton inapoi
            protected void Button1_Click(object sender, EventArgs e)
            { 
                var user = Application["user"] as User;
                string url = user.UserRole == Role.Admin? "AdministratorPage.aspx" : "Candidati.aspx";
                Response.Redirect(url);
            }
    }  
    
}