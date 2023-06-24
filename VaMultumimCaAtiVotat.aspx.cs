using SistemDeVot_WebAppl.Models;
using System;

namespace SistemDeVot_WebAppl
{
    public partial class VaMultumimCaAtiVotat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // verificam daca utilizatorul este autentificat
            var user = Application["user"] as User;

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}