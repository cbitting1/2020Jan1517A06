using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class CDLibrary_Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";

        }
       

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) //has to be there to make sure the validation eintritt
            {
                string msg = "";

                msg += "CD ISBN: " + CDISBN.Text + ", ";
                msg += " Title: " + CDTitle.Text + ", ";
                msg += " Artist(s): " + CDArtists.Text + ", ";
                msg += " Year: " + ReleaseYear.Text + ", ";
                msg += " Tracks: " + Tracks.Text;


                MessageLabel.Text = msg;
            }  
        }    
    }
}