using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class CommonControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Every time the page is processed (submitted to the web server) this method is the FIRST event that is processedthat you can easily see and interact with

            //This is a great place to do common code that is required on each process of the page 
            //Example: empty out old messages

            //Every Control on your web form is a class instance
            //Every control has an ID property
            //Every control must have a unique name
            //The ID value is used to reference the control in your code behind
            //Since controls are instances of a class, all rules of OOP apply
            MessageLabel.Text = "";


            //The web page has a flag that can be checked to see if the web page is posting back
            if(!Page.IsPostBack)
            {
                //If the page is NOT PostBack, it means that this is the first time the page has been displayed
                //You can do page initialization by testing the IsPostBack
                //Create a List<T> where T is a class that has 2 columns: a value and a text display


                //List<DDLData> DataCollection = new List<DDLData> < DDLData > ();
                //DataCollection.Add(new DDLData(1, "COMP1008"));
                //DataCollection.Add(new DDLData(3, "DMIT1508"));
                //DataCollection.Add(new DDLData(4, "DMIT2018"));
                //DataCollection.Add(new DDLData(2, "CPSC1517"));

                
                //Sorting a List<T>
                //(x,y) are placeholders for 2 records at any given time in the sort
                // => (lamda symbol) is part of the delegate syntax, read as "do the following"
                //Comparing x to y is ascending
                //Comparing y to x is descending

                //DataCollection.Sort((x, y) => x.displayField.CompareTo(y.displayField));


                //place the data into the dropdownlist control
                    //a) assign the data collection to the "list" Control
                
                //CollectionList.DataSource = DataCollection;



                
            }
        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //This event will execute ONLY if you press the submit button on your form
            //This event CAN be called from any method within your code behind
            //This event will execute AFTER the Page_Load event

            int numberchoice = 0;

            if(string.IsNullOrEmpty(TextBoxNumberChoice.Text))
            {
                MessageLabel.Text = "Enter a number between 1 and 4";
            }
            else if(!int.TryParse(TextBoxNumberChoice.Text, out numberchoice))
            {
                MessageLabel.Text = "Invalid number. Enter a number between 1 and 4";
            }
            else if(numberchoice < 1 || numberchoice > 4)
            {
                MessageLabel.Text = "Number is out of range. Enter a number between 1 and 4";
            }
            else
            {
                //Assign a value to the RadioButton list to indicate the list item selected
                //This can be done using either .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the argument
                //.SelectedIndex selects the control item based on it's physical index position
                //The best policy is to use .SelectedValue 
                RadioButtonListChoice.SelectedValue = numberchoice.ToString();

                //Set the checkbox
                if(numberchoice == 2 || numberchoice == 4)
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //Position the dropdownlist
                //This can be done using either .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the argument
                //.SelectedIndex selects the control item based on it's physical index position
                //The best policy is to use .SelectedValue 
                CollectionList.SelectedValue = numberchoice.ToString();


                //Access data from your dropdownlist
                //This can be done using either .SelectedValue or .SelectedIndex or .SelectedItem
                //.SelectedValue will return the value portion of your selected line of the control
                //.SelectedIndex will return the selected line of the control physical index position
                //.SelectedItem will return the displayed text of your selected line of the control
                //The best policy is to use .SelectedValue 
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            }
        }
    }
}