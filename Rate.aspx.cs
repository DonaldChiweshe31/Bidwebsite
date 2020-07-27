using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BidWebsite.bookService;


namespace BidWebsite
{
    public partial class Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false) // if user not logged in, redirect to login page 
            {
                Response.Redirect("login.aspx");
            }

            if (!Page.IsPostBack) // check if first time page being loaded 
            {
                BidWebsite.Service serv = new BidWebsite.Service();

                DataSet ds = new DataSet();
                ds = serv.getAllBooks(); // Loads books from database 
                DataTable dt = ds.Tables["Book"];

               

                //Databinds book to ddlBook - drop down list 
                ddlBook.DataSource = dt;
                ddlBook.DataValueField = "BookID";
                ddlBook.DataTextField = "BookName";
              
                ddlBook.DataBind();
                ddlBook.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rdbRate.SelectedItem == null) // no rating selected = error 
            {
                lblOutput.Text = "No rating selected";
            }
            else // proceeds with loading info. 
            {

                int bookID = Convert.ToInt32(ddlBook.SelectedValue);
                string bookName = ddlBook.SelectedItem.Text;
                int rating = Convert.ToInt32(rdbRate.SelectedItem.Value);

                BidWebsite.Service serv = new BidWebsite.Service();
                string resp = serv.ratingBook(Session["email"].ToString(), bookID, rating);

                if (resp == "Choose another book. Cant rate same Book more than once !") // Book already rated 
                {
                    lblOutput.Text = resp;

                }
                else
                {
                    lblOutput.Text = resp;
                    lblOutput.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

        protected void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                BidWebsite.Service serv = new BidWebsite.Service();

                lblOutput.Text = " ";

                if (ddlBook.SelectedItem.Text == "")
                {
                    //Nothing happens/nothing selected 
                }
                else
                {
                    lblRating.Text = "Average Rating : " + serv.avgRating(Convert.ToInt32(ddlBook.SelectedValue)); ;
                    lblName.Text = "Name : " + ddlBook.SelectedItem.Text;
                    lblAuthor.Text = "Author : " + serv.getAuthor(ddlBook.SelectedValue);
                }
            }
        }

        protected void rdbRate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}