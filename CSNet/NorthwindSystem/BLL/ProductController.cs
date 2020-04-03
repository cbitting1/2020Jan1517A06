using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
using System.ComponentModel;  //ODS
using System.Data.SqlClient;    //SqlParameter()
#endregion


namespace NorthwindSystem.BLL
{
    [DataObject]
    public class ProductController
    {
        public List<Product> Products_List()
        {
            //ensure the sql connection is closed at the end of the query process
            using (var context = new NorthwindSystemContext())
            {
                //Use an extension method of EntityFrame to get
                //All of the data from the sql table Region
                //Use the property DbSet that maps the Region sql table to the application
                //The dbset T type is Region which describes a single record
                //The actual collection type that is returned from EntityFramework is either IEnumerable or IQuerable
                //Change the collection type to a List<T> using .ToList()
                return context.Products.ToList();
            }
        }
        public Product Products_FindByID(int productid)
        {
            using (var context = new NorthwindSystemContext())
            {
                //the .Find() method does a primary key lookup of the sql table
                return context.Products.Find(productid);
            }
        }

        //this query will use a NON_PRIMARY key field off the Product record to lookup data from the database table
        [DataObjectMethod(DataObjectMethodType.Select, false)] //Expose it so we can use it with the ODS
        public List<Product> Products_FindByCategory(int categoryid) //We pass in an int categoryid
        {
            using (var context = new NorthwindSystemContext()) //connect to context class which conntects us to the entity framework which is responsible to look up the data
            {
                //call to an Sql Procedure
                //the call returns a datatype of IEnumerable<T>
                //.SqlQuery<T>(execution string[, list of SqlParameter instances])
                //execution string >>   "procedurename parameterlist"
                //a parameter is specified using SqlParameter("parametername", value)
                //SqlParameter() requires using System.Data.SqlClient; namespace  --> siehe on top of the page the using namespace
                IEnumerable<Product> results = context.Database.SqlQuery<Product>("Products_GetByCategories @CategoryID", //IEnumerable is the datatype; //Interprete the data coming in as a Product record
                    new SqlParameter("CategoryID", categoryid)); //"CategoryID" is the name of the parameter from the stored procedure  //the name of the int categoryid that we passed in in the () when creating this method.
                //Products_GetByCategories is the procedure name
                //@CategoryID is the parameter that is to be found in the database stored procedure under the name that we provided in the () and when we expand it we find the @parameter that we have to provide in the ()
                //Don't forget to add the Using clause on the SqlParameter

                //convert the IEnumerable<T> to a List<T>
                return results.ToList();

                //This way we look up anything on a table that is not a primary key
          
            }
        }




        public List<Product> Products_GetByPartialProductName(string productname)
        {
            using (var context = new NorthwindSystemContext())
            {
                IEnumerable<Product> results = context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                    new SqlParameter("PartialName", productname));
                return results.ToList();
            }
        }
    }
}