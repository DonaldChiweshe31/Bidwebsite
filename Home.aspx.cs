using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BidWebsite.bookService;

namespace BidWebsite
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false) // Not logged in -- redirected back to login page 
            {
                Response.Redirect("login.aspx");
            }

            BidWebsite.Service serv = new BidWebsite.Service();

            lblName.Text = serv.getName(Session["email"].ToString()); // Greet User using session variable when logging in 
            lblEmail.Text = Session["email"].ToString(); //Displaying email

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}