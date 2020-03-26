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

            //on the first presentation of this page, load the dropdownlist with Region data
            if (!Page.IsPostBack)  // has to be there 
            {
                BindProductList(); //is there to load the dropdown list (the actual code for the dropdown list ist to be found in the BindProductList method right underneath)
            }
        }

        protected void BindProductList() //if info (the name of our list) is null we do not display it on the dropdown list
        {
            //any time you leave the web page to access another project, place your code within a try catch
            try
            {
                //create an instance of the interface class that exists in your BLL
                //you will need to have declared the namespace of the class at the top of this file
                //(Connect to the Controller Class)
                ProductController sysmger = new ProductController();

                //call the method in the controller that will return the data that you wish
                //you will need to have declared the namespace of the entity class at the top of this file
                List<Product> info = sysmger.Products_List();

                //sort the returned data
                info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));

                //load the dropdownlist
                ProductList.DataSource = info; //info is the name of the list ProductList is the name of the Dropdown
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();

                //add a prompt line to the list
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




        //use this method to discover the inner most error message.
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }





        protected void Fetch_Click(object sender, EventArgs e)
        {
            //test for data presents is against the dropdownlist
            //test for the .SelectedIndex
            //if the index value is 0, then I am on the prompt line
            if (ProductList.SelectedIndex == 0) //To find the physical position (for the prompt line)
            {
                MessageLabel.Text = "Select a product to view.";
            }
            else  
            {
                try
                {
                    //connect to our controller (in this case the ProductController)
                    ProductController sysmgr = new ProductController(); //create a new instance of that class calles sysmgr


                    Product info = sysmgr.Products_FindByID(int.Parse(ProductList.SelectedValue)); //Take the value because we sorted the name!!! --> value and index might do not match up
                                                                                                   //Product is the class in the ProductController class

                    if (info == null)
                    {
                        MessageLabel.Text = "Selected product does not exists on the file";
                        BindProductList(); //will refresh the dropdown list
                    }
                    else
                    {
                        //move your data from info to the cooresponding controls on the web page.
                        ProductID.Text = info.ProductID.ToString();
                        ProductName.Text = info.ProductName;
                        SupplierID.Text = info.SupplierID.ToString();
                        CategoryID.Text = info.CategoryID.ToString();
                        QuantityPerUnit.Text = info.QuantityPerUnit;
                        UnitPrice.Text = info.UnitPrice.ToString(); ;
                        UnitsInStock.Text = info.UnitsInStock.ToString();
                        UnitsOnOrder.Text = info.UnitsOnOrder.ToString();
                        ReorderLevel.Text = info.ReorderLevel.ToString();

                        //Checkbox
                        if(info.Discontinued == false)
                        {
                            Discontinued.Checked = false;
                        }
                        else
                        {
                            Discontinued.Checked = true;

                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = GetInnerException(ex).Message;
                }
            }
        }
    }
}