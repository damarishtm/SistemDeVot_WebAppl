using SistemDeVot_WebAppl.Models;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SistemDeVot_WebAppl
{
    public partial class CreareCont : System.Web.UI.Page
    {
        //buton creaza cont
        protected void Button1_Click(object sender, EventArgs e)
        {
            {
                string email=TextBox1.Text;
                string connectionString = Login.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE AdresaMail = @Email";
                    SqlCommand command = new SqlCommand(query, connection);
                    //valoarea variabilei email este atașată la parametrul "@Email" în comanda SQL.
                    //--Această tehnică este utilizată pentru a preveni atacurile de tip SQL injection.
                    command.Parameters.AddWithValue("@Email", email);
                    //Executăm interogarea SQL si  stocăm numărul de rânduri returnate
                    int count = (int)command.ExecuteScalar();

                    // verificăm dacă numărul de rânduri returnate este mai mare decât zero, ceea ce înseamnă că adresa de email există deja în baza de date. 
                    if (count > 0)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Acest cont exista deja!";
                    }
                    else
                    {
                        // adăugare utilizator în baza de date

                        if (!Regex.IsMatch(TextBox1.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        {
                            Label1.Visible = true;
                            Label1.Text = "Adresă de email incorectă!";
                        }
                        if(!CheckBox18Ani.Checked)
                        {
                            Label1.Visible = true;
                            Label1.Text = "Doar persoanele majore pot fi inregistrate!";
                        }
                        else
                        {

                            try
                            {
                                if(TextBox2.Text.Trim()==TextBox3.Text.Trim())
                                {
                                    SqlCommand cmd = new SqlCommand("insert into Users (UserID, AdresaMail, Parola, Nume, UserRole ) " +
                                        "values(NEWID(), @AdresaMail, @Parola, @nume, @role) ", connection);

                                    // trimite valorile introduse în câmpurile de text din interfața utilizatorului în comanda SQL.
                                    cmd.Parameters.AddWithValue("@AdresaMail", TextBox1.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Parola", TextBox2.Text.Trim());
                                    cmd.Parameters.AddWithValue("@nume", TextBoxNume.Text.Trim());
                                    cmd.Parameters.AddWithValue("@role", Role.Alegator.ToString());


                                    //Aici se execută comanda SQL și se primește numărul de rânduri afectate de comandă.
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected == 1)//Dacă un singur rând a fost afectat de comanda SQL, atunci inserarea a reușit.
                                    {
                                        string url = "Candidati.aspx";
                                        Response.Redirect(url);
                                    }
                                    else
                                        Label1.Text = "Eroare inserare!";
                                }
                                else
                                {
                                    Label1.Text = "Parolele nu coincid!";
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                //log error 
                                Label1.Text = "Eroare la deschidere baza date " + ex.Message;
                            }
                            //adaugarea datelor
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
    