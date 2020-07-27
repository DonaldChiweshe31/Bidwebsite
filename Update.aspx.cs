using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BidWebsite.bookService;


namespace BidWebsite
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            BidWebsite.Service serv = new BidWebsite.Service();

            if (serv.updateInfo(Session["email"].ToString(), txtName.Text, txtPass.Text, txtQues.Text, txtAnswer.Text) == "true") // Updating user information if connected
            {
                lblOutput.Text = "Account has been Updated Succesfully";

            }
            else
            {
                lblOutput.Text = "Problem while updating X_X";
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
    
