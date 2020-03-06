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

                List<MoviesStarsDropDown> DataCollectionStars = new List<MoviesStarsDropDown>(); //DataCollection is the name of the property in the Class Page called "DDL Data
                DataCollectionStars.Add(new MoviesStarsDropDown(1, "1 Star")); // new DDLData --> ist ein Object createn
                DataCollectionStars.Add(new MoviesStarsDropDown(3, "2 Stars"));
                DataCollectionStars.Add(new MoviesStarsDropDown(4, "3 Stars"));
                DataCollectionStars.Add(new MoviesStarsDropDown(2, "4 Stars"));
                DataCollectionStars.Add(new MoviesStarsDropDown(5, "5 Stars"));


                DataCollectionStars.Sort((x, y) => x.displayField.CompareTo(y.displayField));


                StarList.DataSource = DataCollectionStars;


                StarList.DataTextField = nameof(DDLData.displayField);

                StarList.DataBind();
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Submit Button was pressed.";
        }
    }
}