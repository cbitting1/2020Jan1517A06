﻿using System;
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
    //Restrict Access to this class to ONLY other classes within this library: access priviledge of internal
    //Secuity Measure

    //Connect to EntityFrameWork by inheriting DbContext
    internal class NorthwindSystemContext : DbContext
    {
        //You will need a constructor that passes the connection string name to EntityFrameWork via the inherited class DbContext
        public NorthwindSystemContext() :base("NWDB") //NorthwindSystemContext is the name of this class
        {

        }

        //Properties to interact with EntityFramework
        //These properties represent the whole table and all data of the SQL database
        public DbSet<Product> Products { get; set; } //one for each Entity
        //<Product> is the name of the Entitiy in the Entities folder
        //Products in plural because it's for all records not only for one record
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }


    }
}
