using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Room
    {
        public string Name { get; set; }
        public List<Wall> Walls { get; set; }
        public List<Window> Windows { get; set; }
        public List<Door> Doors { get; set; }
        //if we don't put any constructors here it will use the default constructor






    }
}
