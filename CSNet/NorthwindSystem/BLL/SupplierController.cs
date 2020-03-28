
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
using System.ComponentModel;  //ODS
#endregion

namespace NorthwindSystem.BLL
{
    [DataObject] //Exposure of the Class
    public class SupplierController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)] //Exposure of the Method
        public List<Supplier> Suppliers_List()
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Suppliers.ToList();
            }
        }
        public Supplier Suppliers_FindByID(int supplierid)
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Suppliers.Find(supplierid);
            }
        }
    }
}