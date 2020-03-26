using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
#endregion

namespace NorthwindSystem.BLL
{
    public class RegionController
    {
        public List<Region> Regions_List()  //it returns a List of all records on the Region Table 
        {
            //ensure the sql connection is closed at the end
            //   of the query process
            using (var context = new NorthwindSystemContext())
            {
                //use an extension method of EntityFramework to get
                //    all of the data from the sql table Region
                //use the property DbSet that maps the Region sql table to 
                //    the application
                //the dbset T type is Region which describes a single record
                //the actual collection type that is returned from
                //    EntityFramework is either IEnumerable or IQuerable
                //Change the collection type to a List<T> using .ToList()
                return context.Regions.ToList(); //context is the new instance of the class that we created on the page (on the top)
                                //it will take the property "Regions" and change it to a list and will than return it 
            }
        }

        public Region Regions_FindByID(int regionid)
        {
            using (var context = new NorthwindSystemContext())
            {
                //the .Find() method does a primary key lookup of the
                //    sql table
                return context.Regions.Find(regionid); //Finds a specific record on the Region table
                        //it finds a specific record on the region table 
                        //the specific record we are looking for is done by the primary key
                        //pu the primary key in the ()
                        //it will return the primary record; if not it will return null  
            }
        }
    }
}
