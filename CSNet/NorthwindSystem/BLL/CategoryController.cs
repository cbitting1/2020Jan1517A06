 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
using System.ComponentModel; //used by ODS wizard exposure 
#endregion


//Note: everything that we expose here for the wizard is to fill the drop down list on the MultiRecordODS webpage
namespace NorthwindSystem.BLL
{
    //expose the Class
    [DataObject] 
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)] //Exposure of the method
        public List<Category> Categories_List()
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Categories.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]//Exposure of the method
        public Category Categories_FindByID(int categoryid)
        {
            using (var context = new NorthwindSystemContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
    }
}
