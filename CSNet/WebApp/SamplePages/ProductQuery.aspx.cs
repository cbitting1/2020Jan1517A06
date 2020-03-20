using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
#endregion

namespace WebApp.SamplePages
{
    public partial class ProductQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";

            //On the first presentation of this page, load the dropdownlist with Region data
            if (!Page.IsPostBack)
            {
                BindProductList();
            }
        }

        protected void BindProductList()
        {
            //any time you leave the web page to access another project, place your code within a try catch
            try
            {
                //Create an instance of the interface class that exists in your BLL
                //You will need to have declared the namespace of the class at the top of this file
                ProductController sysmger = new ProductController();
                //Call the method in the controller that will return the data that you wish
                //You will need to have declared the namespace of the entity class at the top of this file
                List<Product> info = sysmger.Products_List();

                //Sort the returned data
                info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));

                //Load the dropdownlist
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();

                //Add a prompt line to the list
                ProductList.Items.Insert(0, new ListItem("select..", "0"));
            }
            catch (Exception ex)
            {
                //Sometimes, depending on the exception you will simply get a message pointing you to the Inner Exception which will hold the true error
                //Pass the exception to the GetInnerException() method we have supplied.
                //This GetInnerException() returns the most inner error message
                MessageLabel.Text = GetInnerException(ex).Message;
            }
        }
        //Use this method to discover the inner most error message.
        protected Exception GetInnerException(Exception ex)
        {
            //Drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            //Test for data presents is against the dropdownlist
            //Test for the .SelectedIndex
            //If the index value is 0, then I am on the prompt line
            if (ProductList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a product to view.";
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    Product info = sysmgr.Products_FindByID(int.Parse(ProductList.SelectedValue));
                    if (info == null)
                    {
                        MessageLabel.Text = "Selected product does not exists on the file";
                        BindProductList();
                    }
                    else
                    {
                        //Move your data from info to the cooresponding controls on the web page.
                    }
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = GetInnerException(ex).Message;
                }
            }
        }
    }
}