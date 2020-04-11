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




        public int Products_Add(Product item) //We are returning an integer
        {
            //At some point in time you need to create an instance of your entity class
            //This can be done either on the web page OR within this method
            //In this example the instance was created and loaded on the web page

            using (var context = new NorthwindSystemContext())
            {
                //Step ONE 

                //Staging
                //During stagin the entity will be loaded with the instance to add to the database
                //Staging is done in current memory
                //Record is NOT yet physically added to the database
                context.Products.Add(item);


                //Step TWO
                //Cause the physically addition of the staged record to the databse
                //If this statement fails, any changes attempted against the database are ROLLEDBACK and appropriate error mesasge is issued by the system
                //If this statement is successfull, THEN the NEW primary key will be available for your within the entity instance

                //During this statement executin ANY validation in the entity class definition are executed
                context.SaveChanges(); //Data has been physically send to database and it is trying to add it


                //Optionally 
                return item.ProductID;


                //NOTE: public int indicates the returntype.... If it would say public void that means NO return type
            }
        } 
                             
        
          
        public int Products_Update(Product item)
            {
                using (var context = new NorthwindSystemContext())
                {
                    //Stage 
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                    //Commit and return of the number rows affected
                    return context.SaveChanges();
                }
            }



        public int Products_Delete(int productid)
        {
            using (var context = new NorthwindSystemContext())
            {

                //Two types of deletes

                //1) Physical: physically removal of the record from the database
                //Get the record from the database by the PK
                //var exists = context.Products.Find(productid);

                //    //Stage the removal 
                //context.Products.Remove(exists);

                //    //Commit
                //return context.SaveChanges();




                //Logical Delete: One sets a property of the class to a specified value to indicate tbe record "logically" does not 
                    //"exist" on the database anymore.            
                var exists = context.Products.Find(productid);


                //The setting of the propery should be done within this method and NOT dependent on the user 
                    //remembering to do the action
                exists.Discontinued = true;
                
                
                //Stage  
                context.Entry(exists).State = System.Data.Entity.EntityState.Modified;

                //Commit and return of the number rows affected
                return context.SaveChanges();

            }
        }
    }
}