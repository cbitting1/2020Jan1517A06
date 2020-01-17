﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Room
    {
        public string Name { get; set; } //the name of the Room
        public List<Wall> Walls { get; set; } //a list in which we put all the sizes of the walls
        public List<Window> Windows { get; set; } //a list in which we put all the sizes of the windows
        public List<Door> Doors { get; set; } //a list in which we put all the sizes of the doors
        //if we don't put any constructors here it will use the default constructor






    }
}
