using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of the window class using the default constructor
            //The program NEVER calls a constructor directly
            //The new will use the suggested constructor
            //The actual call to the constructor is done by new

            //Using the Default Constructor
            Window theWindowD = new Window();

            Console.WriteLine($"Width {theWindowD.Width}; height {theWindowD.Height}; " + $"Panes {theWindowD.NumberOfPanes}; Manufacturer >{theWindowD.Manufacturer}<");


            //To place data within the new instance of teh class (object) use the properties
            //To reference a property within an instance use the dot operator
            theWindowD.Manufacturer = "All Weather";
            theWindowD.Width = .9m;
            theWindowD.NumberOfPanes = 2;

            Console.WriteLine($"Width {theWindowD.Width}; height {theWindowD.Height}; " + $"Panes {theWindowD.NumberOfPanes}; Manufacturer >{theWindowD.Manufacturer}<");


            //Using the Greedy Constructor
            Window theWindowG = new Window(2.6m, 1.75m, 12, "Fancy Windows");
            Console.WriteLine($"Width {theWindowG.Width}; height {theWindowG.Height}; " + $"Panes {theWindowG.NumberOfPanes}; Manufacturer >{theWindowG.Manufacturer}<");


            Console.WriteLine("\n\n");


            //using Default Constructor for Door
            Door theDoorD = new Door();
            Console.WriteLine($"Width {theDoorD.Width}; height {theDoorD.Height}; " + $"Direction {theDoorD.RightOrLeft}; Material >{theDoorD.Material}<");


            //using Greedy Constructor for Door
            Door theDoorG = new Door(1.2m, 1.9m, "L", "Wood");
            Console.WriteLine($"Width {theDoorG.Width}; height {theDoorG.Height}; " + $"Direction {theDoorG.RightOrLeft}; Material >{theDoorG.Material}<");


            //Falscher Buchstabe bei LeftOrRight
                //theDoorG.RightOrLeft = "M";
                //Console.WriteLine($"Width {theDoorG.Width}; height {theDoorG.Height}; " + $"Direction {theDoorG.RightOrLeft}; Material >{theDoorG.Material}<");


            Console.WriteLine("\n\n");


            //Default Window
            Console.WriteLine($"Default Window Area {theWindowD.WindowArea()};" + 
                $"Default Window Perimeter {theWindowD.WindowPerimeter()}");

            //Greedy Window
            Console.WriteLine($"Default Window Area {theWindowG.WindowArea()};" +
               $"Default Window Perimeter {theWindowG.WindowPerimeter()}");



            //Default Door
            Console.WriteLine($"Default Door Area {theDoorD.DoorArea()};" +
              $"Default Window Perimeter {theDoorD.DoorPerimeter()}");

            //Greedy Door
            Console.WriteLine($"Default Window Area {theDoorG.DoorArea()};" +
              $"Default Window Perimeter {theDoorG.DoorPerimeter()}");
        }
    }
}
