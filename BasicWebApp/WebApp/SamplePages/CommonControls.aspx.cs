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
            //Every time the page is processed (submitted to the web server) this method is the FIRST event that is processed that you can easily see and interact with

            //This is a great place to do common code that is required on each process of the page 
            //Example: empty out old messages

            //Every Control on your web form is a class instance
            //Every control has an ID property
            //Every control must have a unique name
            //The ID value is used to reference the control in your code behind
            //Since controls are instances of a class, all rules of OOP apply
            MessageLabel.Text = ""; //is the ID of the field that is shown on the bottom of the page (our output field)


            //The web page has a flag that can be checked to see if the web page is posting back
            if (!Page.IsPostBack)
            {
                //If the page is NOT PostBack, it means that this is the first time the page has been displayed
                //You can do page initialization by testing the IsPostBack
                //Create a List<T> where T is a class that has 2 columns: a value and a text display
                //In die Klammer kommt die Type of objects (wo jetzt das T steht --> zb int oder float)
                //Das T ist der Type of object, in diesem Fall ist der Type of object eine class die wir programmmiert haben ist oder build in ist

                //int x
                //List DataCollection
                List<DDLData> DataCollection = new List<DDLData>(); //DataCollection is the name of the property in the Class Page called "DDL Data
                DataCollection.Add(new DDLData(1, "COMP1008")); // new DDLData --> ist ein Object createn
                DataCollection.Add(new DDLData(3, "DMIT1508"));
                DataCollection.Add(new DDLData(4, "DMIT2018"));
                DataCollection.Add(new DDLData(2, "CPSC1517"));
                //Wir brauchen hierfuer einen Constructor weil wenn wir eine instance von ner object createn dann ist die Zahl und der Name required 
                //Wenn wir nix eingeben wuerden wuerde der leere constructor geurfen (nix in der Klammer)


                //Sorting a List<T>
                //(x,y) are placeholders for 2 records at any given time in the sort
                // => (lamda symbol) is part of the delegate syntax, read as "do the following"
                //Comparing x to y is ascending
                //Comparing y to x is descending
                DataCollection.Sort((x, y) => x.displayField.CompareTo(y.displayField));


                //Place the data into the dropdownlist control
                //a) assign the data collection to the "list" Control
                CollectionList.DataSource = DataCollection;   //CollectionList is the ID of the DROPDOWN and DataCollection of the List we created


                //b) This step is required for specific "list" controls
                //Indicate which data value is to be assigned to the Value field and the Display text field
                //There are different styles in assigning this information
                CollectionList.DataValueField = "valueField";
                CollectionList.DataTextField = nameof(DDLData.displayField);  //don's preference
                //Other controls that handle lists we don't need B; we only need A and C

                //c)Bind your data to the actual control
                CollectionList.DataBind(); //CollectionList is the name of the Dropdown

                //d)OPTIONALLY you can place a prompt line on your control
                CollectionList.Items.Insert(0, new ListItem("Select...", "0")); //Die erste 0 ist die Stelle des Indexes (in diesem Falle an "1." Stelle)
                                                                                //("Select...", "0") --> is a String and the Value (NOTE: we could also just put in the "Select..." without the Value)
            }
        }




        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //This event will execute ONLY if you press the submit button on your form
            //This event CAN be called from any method within your code behind
            //This event will execute AFTER the Page_Load event

            int numberchoice = 0;

            if (string.IsNullOrEmpty(TextBoxNumberChoice.Text))
            {
                MessageLabel.Text = "Enter a number between 1 and 4";
            }
            else if (!int.TryParse(TextBoxNumberChoice.Text, out numberchoice)) //if not  an int try to parse (!int.TryParse...)
            {                                               //out numberchoice to get out the number that the user put in
                MessageLabel.Text = "Invalid number. Enter a number between 1 and 4";
            }
            else if (numberchoice < 1 || numberchoice > 4)
            {
                MessageLabel.Text = "Number is out of range. Enter a number between 1 and 4";
            }
            else
            {
                //Assign a value to the RadioButton list to indicate the list item selected
                //This can be done using either .SelectedValue or .SelectedIndex
                //.SelectedValue will match the control item value to the argument
                //.SelectedIndex selects the control item based on it's physical index position
                //The best policy is to use .SelectedValue (IndexPosition and Value that we are trying to find do not neccessarely match up)
                RadioButtonListChoice.SelectedValue = numberchoice.ToString(); // .SelectedValue = because than we have a value to match up
                                                                               //The Index does not neccessarly match up with the Value
                                                                               //The above RadioButtonListChoice.SelectedValue = numberchoice.ToString(); will make sure that the checkbox will be selected after the
                                                                               //user has entered a number and pressed the submit button
                //numberchoice.ToString will turn on the RadioButtonListChoice (the number that the user entered)
                //numbers 1-4 are also the "Value" numbers in the RadioButtons

                //Set the checkbox
                if (numberchoice == 2 || numberchoice == 4)
                {
                    CheckBoxChoice.Checked = true; //checked will turn on the checkbox (if we say "true" or off when we say "false")
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
                CollectionList.SelectedValue = numberchoice.ToString(); //Will change the dropdownlist to what the user selected with the number he entered
                //NOTE: Every ListControl that we have is gonna have the same type of behaviours (.SelectedValue/.SelectedIndex)!!!!!!!!!!

                //Accessing data from your dropdownlist
                //This can be done using either .SelectedValue or .SelectedIndex or .SelectedItem
                //.SelectedValue will return the value portion of your selected line of the control
                //.SelectedIndex will return the selected line of the control physical index position
                //.SelectedItem will return the displayed text of your selected line of the control
                //The best policy is to use .SelectedValue 
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            }
        }

        protected void LinkButtonCollection_Click(object sender, EventArgs e)
        {

            //Meine Loesung:


            //RadioButtonListChoice.SelectedValue = CollectionList.SelectedValue;

            //if (CollectionList.SelectedValue == "0")
            //{
            //    MessageLabel.Text = "No Selection was made. Please make a selection from the dropdown list.";
            //}
            //else if (CollectionList.SelectedValue == "1")
            //{
            //    DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            //    CheckBoxChoice.Checked = false; //checked will turn on the checkbox (if we say "true" or off when we say "false")
            //    TextBoxNumberChoice.Text = CollectionList.SelectedIndex.ToString();

            //    //RadioButtonListChoice.SelectedValue = CollectionList.SelectedValue;
            //}
            //else if (CollectionList.SelectedValue == "2")
            //{
            //    DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            //    CheckBoxChoice.Checked = true; //checked will turn on the checkbox (if we say "true" or off when we say "false")
            //    TextBoxNumberChoice.Text = CollectionList.SelectedIndex.ToString();

            //    //RadioButtonListChoice.SelectedValue = CollectionList.SelectedValue;
            //}
            //else if (CollectionList.SelectedValue == "3")
            //{
            //    DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            //    CheckBoxChoice.Checked = false; //checked will turn on the checkbox (if we say "true" or off when we say "false")
            //    TextBoxNumberChoice.Text = CollectionList.SelectedIndex.ToString();

            //    //RadioButtonListChoice.SelectedValue = CollectionList.SelectedValue;
            //}
            //else if (CollectionList.SelectedValue == "4")
            //{
            //    DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            //    CheckBoxChoice.Checked = true; //checked will turn on the checkbox (if we say "true" or off when we say "false")
            //    TextBoxNumberChoice.Text = CollectionList.SelectedIndex.ToString();

            //    //RadioButtonListChoice.SelectedValue = CollectionList.SelectedValue;
            //}



            //Seine Loesung:
            int numberchoice = 0;

            if (CollectionList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a course from the list";
            }

            else
            {
                numberchoice = int.Parse(CollectionList.SelectedValue);
                TextBoxNumberChoice.Text = CollectionList.SelectedValue;
                //TextBoxNumberChoice.Text = numberchoice.ToString();
                RadioButtonListChoice.SelectedValue = numberchoice.ToString();

                //set the checkbox
                if (numberchoice == 2 || numberchoice == 4)
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                DisplayReadOnly.Text = CollectionList.SelectedItem.Text + " at index " + CollectionList.SelectedIndex + " having a value of " + CollectionList.SelectedValue;
            }
        }
    }
}