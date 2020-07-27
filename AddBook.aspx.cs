using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BidWebsite
{
    public partial class Secure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BidWebsite.Service serv = new BidWebsite.Service();
            string resp = serv.addBook(txtName.Text, txtAuthor.Text);

            if (resp == "true")
            {
                lblOutput.Text = "Book Added sucesfully";
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblOutput.Text = "Problem ocurred try again later";
            }
        }
    }
}