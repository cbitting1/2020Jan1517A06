using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        static List<Entry> entries = new List<Entry>(); //is a List<T> We have just created a List with the class of Entry (created by us) and the name of it is entries
                                            //List is to store what the user enters to store it in this list
                                            //Do not need a constructor because we do not require a name when creating the instance of the object
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Re-execute the validation Controls on the server side.
            if(Page.IsValid) //Wrap the if(Page.IsValid around the submit button since we want the validation when the user pressed the submit button.)
            {
            if(Terms.Checked) //makes sure that they have agreed to the terms and conditions (when the checkbox is checked) then we can store the information
            {                                                   //That's when we create an instance of the object 
                //Created an instance of the data class (object)
                Entry theEntry = new Entry(); //Wir brauchen hierfuer kein constructor weil wir nix direkt angeben in den klammern wenn wir n object createn
                //Entry is the name of our class (the datatype of the instance)
                //theEntry is the name of the instance


                //loaded the instance with data from the form
                theEntry.FirstName = FirstName.Text;
                theEntry.LastName = LastName.Text;
                theEntry.StreetAdress1 = StreetAddress1.Text;
                theEntry.StreetAddress2 = string.IsNullOrEmpty(StreetAddress2.Text) ? null : StreetAddress2.Text;
                theEntry.City = City.Text;
                theEntry.Province = Province.SelectedValue;
                theEntry.PostalCode = PostalCode.Text;
                theEntry.EmailAddress = EmailAddress.Text;

                //Add the new instance to the collection (entries is the name of the list we created up on top of page) theEntry is the name of the instance that we created
                entries.Add(theEntry);


                //Display the collection (List)
                //Use a collection display control: GridView
                //Requirements: a) Data source (collection)
                //b) bind the data to the control
                EntryList.DataSource = entries; //EntryList is the name of our GridView on the previous page (with the controls on it); entries is the name of the list we created
                EntryList.DataBind();
                //Difference: GriedView can have any number of columns while the DropDownList has ValueField and DataTtextField (2 fields)
            }
            else
            {
                Message.Text = "You did not agree to the contest terms. Entry rejected.";
            }
          }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            CheckAnswer.Text = "";
            Province.SelectedIndex = 0; //We could also do Province.SelectedValue = "xxx";
            Terms.Checked = false;
        }
    }
}