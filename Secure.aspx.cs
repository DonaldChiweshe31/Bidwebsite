using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BidWebsite.bookService;



namespace BidWebsite
{
    public partial class Secure1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BidWebsite.Service serv = new BidWebsite.Service();
            string resp = serv.getQuestion(txtEmail.Text);

            if (resp == "UNF") // checks if user is found 
            {
                lblQuestion.Text = "User not found";
                lblQuestion.ForeColor = System.Drawing.Color.Red;
            }
            else // user was found 
            {
                lblQuestion.Text = resp;

                lblAnswer.Visible = true;
                txtAns.Enabled = true;
                txtAns.Visible = true;

                lblNewPass.Visible = true;
                txtNPass.Visible = true;
                txtNPass.Enabled = true;

                lblPass2.Visible = true;
                txtRPass.Visible = true;
                txtRPass.Enabled = true;

               

                btnOk.Enabled = true;
            }
        }



        protected void txtRPass_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            {
                BidWebsite.Service serv = new BidWebsite.Service();

                string resp = serv.getAnswer(txtEmail.Text, txtAns.Text); // getting answer

                if (resp == "true") // back to homepage if correct 
                {
                    serv.resetPass(txtEmail.Text, txtRPass.Text); // resets users password 
                    Session["LoggedIn"] = true;
                    Session["email"] = txtEmail.Text;
                    Response.Redirect("Home.aspx"); // redirected back to home page 


                }
                else if (resp == "false") // error message outputed if incorrect 
                {
                    lblOutput.Text = "Incorrect Answer provided !!";
                    lblOutput.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void txtNPass_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
}