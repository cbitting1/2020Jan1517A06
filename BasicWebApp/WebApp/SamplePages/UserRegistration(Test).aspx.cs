using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class UserRegistration_Test_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutputMessage.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) //has to be there to make sure das validation eintritt
            {
                if(Terms.Checked)
                {
                    string msg = "";

                    msg += "First Name: " + FName.Text + ", ";
                    msg += " Last Name: " + LName.Text + ", ";
                    msg += " User Name: " + User.Text + ", ";
                    msg += " Email Address: " + Email.Text + ", ";
                    msg += " Password: " + EnteredPassword.Text;


                    OutputMessage.Text = msg;
                }
               else
                {
                    OutputMessage.Text = "You did not agree to the terms of this page";
                    OutputMessage.ForeColor = System.Drawing.Color.Red;
                }

            }
        }
    }
}