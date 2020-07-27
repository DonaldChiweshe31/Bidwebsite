using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BidWebsite.bookService;


namespace BidWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"] == true)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            BidWebsite.Service serv = new BidWebsite.Service();

            string logInWeb = serv.login(txtUmail.Text, txtPass.Text);

            if (logInWeb == "true")
            {
                Session["LoggedIn"] = true;
                Session["email"] = txtUmail.Text;
                Response.Redirect("Home.aspx");

            }
            else if (logInWeb == "false")
            {
                lblErr.Text = "Password Does not match";
            }
            else if (logInWeb == "UNF")
            {
                lblErr.Text = "User not found";
            }

        }



    }

}
    

