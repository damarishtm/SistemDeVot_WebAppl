using System.Web.UI;

namespace SistemDeVot_WebAppl.Models
{
    public static class MessageBox
    {
        public static void Show(this Page Page, string message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + message + "');</script>"
            );
        }
    }
}
