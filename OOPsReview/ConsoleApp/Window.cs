﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //a class represents the defined characteristics of an item
    // an item can be a physical thing (cell phone), conept (student), 
        // collection of data
    // Visual Studio creates your class without a specific access type
    // the default type for a class is private
    // code outside of a private class cannot use the contents of the private class
    // FOr the class to be used by an outside user it must be public
    public class Window
    {
        //the class can have data that is open to the user by defining it as a public datatype variablename
        //the class can have data that is restrict from the user by defining it as a private datatype variablename
        //the class can create a Property that can be used to interface between the user and the private data 
        //the Property will have public access

        //Private data member
        private string _Manufacturer;

        //Properties 
        //Properties can be implemented in two ways
            //a) Fully Implemented property
                //used because there is additional code/logic used in processing the data
            //b) Auto Implemented Property
                //used when there is no need for additional code/logic, when the data is simply saved
        public string Manufacturer
        {
            //der code wird an _Manufacturer geschickt

            //assume the Manufacturer is a nullable string
            // 3 possibilities
                //a) there are characters
                //b) string has no data (null)
                //c) there is a physical string BUT no characters
                
            //there will be additional code to ensure ONLY a and b exists for the data 
            //this requires a private data  member to hold the data and a property to manage the data content 
            get
            {
                //returns data via the property to the outside user of the property
                return _Manufacturer;
            }
            set
            {
                //the set takes incoming data and places that data into the private data member
            }

        }
    }
}
