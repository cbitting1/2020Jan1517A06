using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
           
            MessageLabel.Text = "";
            
                if (!Page.IsPostBack)
                {

                    List<MoviesStarsDropDown> DataCollectionStars = new List<MoviesStarsDropDown>(); //MovieStarsDropDown is the name of the class (List of type that class name) 
                                                                                                    //DataCollectionStars is the name of our new created List 
                    DataCollectionStars.Add(new MoviesStarsDropDown(1, "1 Star")); // new MovieStarsDropDown (name of the class that we created) --> ist ein Object createn
                    DataCollectionStars.Add(new MoviesStarsDropDown(3, "2 Stars"));
                    DataCollectionStars.Add(new MoviesStarsDropDown(4, "3 Stars"));
                    DataCollectionStars.Add(new MoviesStarsDropDown(2, "4 Stars"));
                    DataCollectionStars.Add(new MoviesStarsDropDown(500, "5 Stars"));

                    
                    //Namen werden in der Liste gesorted
                    DataCollectionStars.Sort((x, y) => x.displayField.CompareTo(y.displayField));


                    StarList.DataSource = DataCollectionStars;  //StarList is the ID (name) of the DropDownList in the webpage where we created the form that the user can see
                                                                //DataCollectionStars is the name of our created list in which the entries are listed and we sorted
                                                                //The DropDown (StarList) is getting the data from our list (DataCollectionStars)

                    //The DropDown (StarList); we make sure which of the two fields (displayField, valueField) we wanna have displayed in the dropdown
                    StarList.DataTextField = nameof(MoviesStarsDropDown.displayField);

                    //We bind the data to the DropDown 
                    StarList.DataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) //has to be there to make sure the validation eintritt
            {
                string msg = "";


                msg += "Movie: " + MovieTitle.Text + ", ";
                msg += "Year: " + YearMovie.Text + ", ";
                msg += "Stars: " + StarList.Text + ", ";
                msg += "ISBN: " + MovieISBN.Text + ", ";

                bool found = false;
                foreach (ListItem movieratingrow in MovieRatings.Items) //MovieRatings is the ID (name) of the Checkbox on the Movie-Webpage with the form on it
                        //ListItem is just what we use because Checkboxes are "ListItem"
                        //movieratingrow is our variable that we created for the foreach                     
                {
                    if (movieratingrow.Selected)
                    {
                        msg += "Movie Rating: " + movieratingrow.Text + " ";
                        found = true;
                    }
                }
                if (!found) //if nothing was found in the foreach loop dann geht er hier rein
                { //NOTE: not within the loop
                    msg += "Movie Rating: You did not select a Movie Rating. ";
                }


                //Put out message for media depending on what media they have selected
                if (MediaSelection.SelectedValue == "1") //MediaSelection is the name of the RadioButton(List)
                {
                    msg += "Media: " + MediaSelection.SelectedItem;
                }
                else if (MediaSelection.SelectedValue == "2")
                {
                    msg += "Media: " + MediaSelection.SelectedItem;
                }
                else if (MediaSelection.SelectedValue == "3")
                {
                    msg += "Media: " + MediaSelection.SelectedItem;
                }
                else
                {
                    msg += "Media: You did not select a Media Rating. ";
                }



                MessageLabel.Text = msg; //output of the text to display it to the user
            }
        }
    }
}