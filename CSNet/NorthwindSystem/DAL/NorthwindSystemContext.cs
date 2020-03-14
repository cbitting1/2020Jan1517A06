using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Entities;
using System.Data.Entity;
#endregion


namespace NorthwindSystem.DAL
{
    //Restrict Access to this classto ONLY other classes within this library: access priviledge of internal
    //Secuity Measure

    //Connect to EntityFrameWork by inheriting DbContext
    internal class NorthwindSystemContext : DbContext
    {
        //You will need a constructor that passes the connection string name to EntityFrameWork via the inherited class DbContext
        public NorthwindSystemContext() :base("NWDB")
        {

        }

        //Properties to interact with EntityFramework
        //These properties represent the whole table and all data of the SQL database
        public DbSet<Product> Products { get; set; } //one for each Entity

    }
}
