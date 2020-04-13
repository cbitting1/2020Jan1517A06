using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//These are necessary for the expanded  error handling code
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;


namespace WebApp.NorthwindPages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            OutputMessage.Text = "";

            //execute when page is first displayed
            if (!Page.IsPostBack)
            {
                BindProductList();
            }

        }

        //use this method to discover the inner most error message.
        //this rotuing has been created by the user
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        //use this method to load a DataList with a variable
        //number of message lines.
        //each line is a string
        //the strings (lines) are passed to this routine in a List<string>
        //second parameter is the bootstrap cssclass
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void BindProductList()
        {
            try
            {
                ProductController sysmgr = new ProductController();
                List<Product> info = sysmgr.Products_List();
                info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                ProductList.DataSource = info;
                ProductList.DataTextField = nameof(Product.ProductName);
                ProductList.DataValueField = nameof(Product.ProductID);
                ProductList.DataBind();
                ProductList.Items.Insert(0, new ListItem("select ...", "0"));
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //standard lookup
            if (ProductList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a product to look up.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();

                    Product info = sysmgr.Products_FindByID(int.Parse(ProductList.SelectedValue));
                    if (info == null)
                    {
                        errormsgs.Add("Selected product no longer on file. Select a different product.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        BindProductList();
                    }
                    else
                    {
                        //load the co-responding individual field
                        ProductID.Text = info.ProductID.ToString();
                        ProductName.Text = info.ProductName;
                        if (info.SupplierID.HasValue)
                        {
                            SupplierList.SelectedIndex = 0;
                        }
                        else
                        {
                            SupplierList.SelectedValue = info.SupplierID.ToString();
                        }
                        if (info.CategoryID == null)
                        {
                            CategoryList.SelectedIndex = 0;
                        }
                        else
                        {
                            CategoryList.SelectedValue = info.CategoryID.ToString();
                        }
                        QuantityPerUnit.Text = string.IsNullOrEmpty(info.QuantityPerUnit) ? "" : info.QuantityPerUnit;
                        UnitPrice.Text = info.UnitPrice == null ? "" : string.Format("{0:0.00}", info.UnitPrice);
                        UnitsInStock.Text = info.UnitsInStock == null ? "" : info.UnitsInStock.ToString();
                        UnitsOnOrder.Text = info.UnitsOnOrder == null ? "" : info.UnitsOnOrder.ToString();
                        ReorderLevel.Text = info.ReorderLevel == null ? "" : info.ReorderLevel.ToString();
                        Discontinued.Checked = info.Discontinued;
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).Message);
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductID.Text = "";
            ProductName.Text = "";
            QuantityPerUnit.Text = "";
            UnitPrice.Text = "";
            UnitsInStock.Text = "";
            UnitsOnOrder.Text = "";
            ReorderLevel.Text = "";
            Discontinued.Checked = false;
            SupplierList.ClearSelection(); //DropDown List
            CategoryList.ClearSelection(); //DropDown List
            //optionally
            ProductList.ClearSelection(); //Where the user selects a product 
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //Check the web page validation controls
            //Only required if there is web page validation controls
            if(Page.IsValid)
            {
                //Page validation controls are good
                //You could possibly have additional validation within your code bedhind
                //Do that validation BEFORE calling your constoller to do the addition of the new database record

                //Assume for this example that a Supplier and Category are required (DropdownList)

                //We are not gonna print them yet but later on we print them all together (or those ones of it that are required  for the user to see)
                if(CategoryList.SelectedIndex == 0) //For DropDownList
                {
                    errormsgs.Add("Category is required.");
                }

                if (SupplierList.SelectedIndex == 0) //For DropDownList
                {
                    errormsgs.Add("Category is required.");
                }

                //The following could have been done as a Validation Control on the web form

                //Price can not be negative
                decimal price = 0.0m;
                if(!decimal.TryParse(UnitPrice.Text, out price))
                {
                    errormsgs.Add("Unit Price needs to be a number");
                }
                else if(price < 0.0m)
                {
                    errormsgs.Add("Unit Price must be 0.00 or greater.");
                }


                //With the error handle example in this program one tests to see if the List<string> errormsgs has any content
                //If so, display all the errors and stop processing for this event
                    //Otherwise, continue with the processing to add the new product to the database

            if(errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info"); // We collect all errormessages and display them at once
                }
            else
                {
                    //All validation has passed
                    //Assume data is good to this point

                    //The addition of the record to the database must be done using user-friendly error handling
                    try
                    {
                        //Standard Add

                        //Create a new instance of the Entity class that hte data will be added to 
                                //In this cases we are adding an product
                        Product theItem = new Product();


                        //In this case we do not need the Product ID because it is an Identity Key (Will be auto generated by the database)
                        //Think about your PK; Needed (Non-Identity) or not (Identity)
                        //Non-Identity: You will need to load your value
                        //Identity: You DO NOT to load your value
                        //Product ID is an identity key
                        theItem.ProductName = ProductName.Text;
                        theItem.QuantityPerUnit = QuantityPerUnit.Text;
                        //theItem.UnitPrice = decimal.Parse(UnitPrice.Text); //not nullable
                        theItem.UnitPrice = string.IsNullOrEmpty(UnitPrice.Text) ? (decimal?)null : decimal.Parse(UnitPrice.Text); //If it can be nullable when user enters it
                        theItem.UnitsInStock = string.IsNullOrEmpty(UnitsInStock.Text) ? (Int16?)null : Int16.Parse(UnitsInStock.Text); //If it can be nullable when user enters it
                        theItem.UnitsOnOrder = string.IsNullOrEmpty(UnitsOnOrder.Text) ? (Int16?)null : Int16.Parse(UnitsOnOrder.Text); //If it can be nullable when user enters it
                        theItem.ReorderLevel = string.IsNullOrEmpty(ReorderLevel.Text) ? (Int16?)null : Int16.Parse(ReorderLevel.Text); //If it can be nullable when user enters it

                        //For the DropDown for Supplier if they can be null
                        if(SupplierList.SelectedIndex == 0)
                        {
                            theItem.SupplierID = null;
                        }
                        else
                        {
                            theItem.SupplierID = int.Parse(SupplierList.SelectedValue);
                        }


                        //For the Category DropDown if they can be null
                        if (CategoryList.SelectedIndex == 0)
                        {
                            theItem.CategoryID = null;
                        }
                        else
                        {
                            theItem.CategoryID = int.Parse(CategoryList.SelectedValue);
                        }


                        //What about discontinued?
                        //Since this is an add, would you add a NEW product that is discontinued? --> NO
                        //In this case, you may decide to simply hard code the value for Discontinued
                        theItem.Discontinued = false;




                        //Connect to the contoller class that handles adding a prouct to the database (NOTE: add to the Product Controller and "Add Class")
                        ProductController sysmgr = new ProductController();


                        //Call the appropriate method in the controller and receive any feedback
                        //In this example, the controller will return the new PK value if the records was successfully added to the database
                        //If there is an error while adding, the catch() will handle the message
                        //NOTE: if we are not receiving anything back we do not need to worry about it 
                        int newProductID = sysmgr.Products_Add(theItem);


                        //Successfull add
                        ProductID.Text = newProductID.ToString(); //We're displaying the new ProductID that was generated by the database in the textfield so user can see it

                        //refresh the dropdownlist for products
                        BindProductList();
                        //Position in the list
                        ProductList.SelectedValue = newProductID.ToString(); //So the Products DropDownList is gonna repositioned 


                        OutputMessage.Text = "Add was successfull";

                    }
                    catch (DbUpdateException ex) //Error when trying to change the database (fields)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex) //we wanna handle the exception that come from my entity
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex) //the regular exception
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }

                }


            }
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            //executes your web page validation controls
            if (Page.IsValid)
            {
                //Any other required validation in code-behind that was not done with the web page validation controls

                //Check to see if the pkey value is present
                if (string.IsNullOrEmpty(ProductID.Text))
                {
                    errormsgs.Add("Look up a product to update.");
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    Product item = LoadProductInstance();

                    //In addition to the basic load of the Product instance for an update one also must include the identity PK value
                    item.ProductID = int.Parse(ProductID.Text);

                    //Deal with a "Logical" delete property if one exists
                    item.Discontinued = Discontinued.Checked;

                    try
                    {
                        ProductController sysmgr = new ProductController();
                        int rowsaffected = sysmgr.Products_Update(item);

                        //Check for success with or without actual changes to the database
                        if (rowsaffected == 0)
                        {
                            //No abort BUT no rows changed
                            //This means that the record no longer is on the database
                            errormsgs.Add("Product has been removed from the file.");
                            LoadMessageDisplay(errormsgs, "alert alert-warning");
                            ProductID.Text = "";
                            BindProductList();  //Make sure your select list is up to date

                        }
                        else
                        {
                            //Record was updated
                            errormsgs.Add("Product has been updated");
                            LoadMessageDisplay(errormsgs, "alert alert-info");
                            Discontinued.Checked = true;
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }



        protected void RemoveProduct_Click(object sender, EventArgs e)
        {
            //check to see if the pkey value is present
            if (string.IsNullOrEmpty(ProductID.Text))
            {
                errormsgs.Add("Look up a product to discontinue.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ProductController sysmgr = new ProductController();
                    int rowsaffected = sysmgr.Products_Delete(int.Parse(ProductID.Text));

                    //Check for success with or without actual changes to the database
                    if (rowsaffected == 0)
                    {
                        //No abort BUT no rows changed
                        //This means that the record no longer is on the database
                        errormsgs.Add("Product has been removed from the file.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        ProductID.Text = "";
                        BindProductList();  //Make sure your select list is up to date

                    }
                    else
                    {
                        //Record was updated
                        errormsgs.Add("Product has been discontinued");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Discontinued.Checked = true;
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }

        }


        protected Product LoadProductInstance()
        {
            Product item = new Product();
            item.ProductName = ProductName.Text;
            item.ProductName = string.IsNullOrEmpty(QuantityPerUnit.Text) ? null : QuantityPerUnit.Text;
            item.SupplierID = SupplierList.SelectedIndex == 0 ? (int?)null : int.Parse(SupplierList.SelectedValue);
            item.CategoryID = CategoryList.SelectedIndex == 0 ? (int?)null : int.Parse(CategoryList.SelectedValue);
            item.UnitPrice = string.IsNullOrEmpty(UnitPrice.Text) ? (decimal?)null : decimal.Parse(UnitPrice.Text);
            item.UnitsInStock = string.IsNullOrEmpty(UnitsInStock.Text) ? (Int16?)null : Int16.Parse(UnitsInStock.Text);
            item.UnitsOnOrder = string.IsNullOrEmpty(UnitsOnOrder.Text) ? (Int16?)null : Int16.Parse(UnitsOnOrder.Text);
            item.ReorderLevel = string.IsNullOrEmpty(ReorderLevel.Text) ? (Int16?)null : Int16.Parse(ReorderLevel.Text);

            //optionally you could handle the Discontinue in this method (or we could handle it in the other one (that's what we do))
            return item;
        }

    }
}