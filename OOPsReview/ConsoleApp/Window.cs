using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //a class represents the defined characteristics of an item
    // an item can be a physical thing (cell phone), concept (student), 
        // collection of data
    // Visual Studio creates your class without a specific access type
    // the default type for a class is private
    // code outside of a private class cannot use the contents of the private class
    // For the class to be used by an outside user it must be public
    public class Window
    {
        //the class can have data that is open to the user by defining it as a public datatype variablename
        //the class can have data that is restrict from the user by defining it as a private datatype variablename
        //the class can create a Property that can be used to interface between the user and the private data 
        //the Property will have public access

        //Private data member
        private string _Manufacturer;
        private decimal _Height;
        //Properties 
        //Properties can be implemented in two ways
            //a) Fully Implemented property
                //used because there is additional code/logic used in processing the data
            //b) Auto Implemented Property
                //used when there is no need for additional code/logic, when the data is simply saved

            //example of a Fully implemented property
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

                //internal to the property, incoming data willnbe placed in a common variable called value
                //a property is associated with a signle data member.
                //a property has no parameter list
                if (string.IsNullOrEmpty(value))
                {
                    _Manufacturer = null;
                }
                else
                {
                    _Manufacturer = value;
                }

                //alternate code
                _Manufacturer = string.IsNullOrEmpty(value) ? null : value;
            }

        }



        //example of an Auto Impemented Property
        //Auto Implemented properties can be used when there is NO NEED for additional processing against the incoming data
        //NO internal private data member is required for this property
        //the system will internally generate a data area for the data 
        //access to the stored data (getting or setting) CAN ONLY be done via the property
        public decimal Width { get; set; }

        //lets fully implement Height with a criteria of being > 0
        public decimal lHeight
        {
            get
            {
                return _Height;
            }
            set
            {
                //the m indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height can not be 0 or less than 0.")
                }
                else
                {

                }
            }
        }

        public decimal Height { get; set; }

        //WHY do we NOT need to fully implement a nullable numeric?
        //Numerics have a default of zero.
        //Numerics can only store a numeric (unless nullable)
        //Numerica can be null if declared as nullable
        //IF the numeric has additional criteria (e.g has to be greater than zero) THEN you can code the property as a Fully Implemented property
        public int? NumberOfPanes { get; set; } //? bedeuted nullable


    }
}
