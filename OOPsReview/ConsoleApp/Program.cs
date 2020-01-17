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
            theWindowD.PrintThis("hello");
            Console.WriteLine($"Width {theWindowD.Width}; height {theWindowD.Height}; " + $"Panes {theWindowD.NumberOfPanes}; Manufacturer >{theWindowD.Manufacturer}<");


            //To place data within the new instance of the class (object) use the properties
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


            //Falscher Buchstabe bei LeftOrRight bekommt man die error message die wir created haben
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




            
            UsingClasses();
        }

        static void UsingClasses()
        {
            //declare the needed Lists<T> for estimating paint job
            List<Wall> walls = new List<Wall>(); //List is an object
                                                //Wall is the name of the Class
                                                //walls is the name of the list
                                                //new List<Wall>() --> we take the things that were declared from 
            List<Door> doors = new List<Door>();
            List<Window> windows = new List<Window>();
            Room room = new Room(); //clearing out the previous entry to make "new room" for another entry; otherwise it will always
                                                                        //keep entering the same numbers into the list


            //loop of prompt/input/validate for walls
            Wall wall = new Wall(); //declaring "wall" as a local variable
            //prompt, read, validate
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            walls.Add(wall);   //adding a wall to the wall list
                               //walls is the name of the list in which we are putting the data that user entered
                               //Add.(wall) we add it to the walls list the data that is stored in everything that is 
                                                    //associated with wall. ....
            wall = new Wall();//clearing out the previous entry to make "new room" for another entry; otherwise it will always
                                    //keep entering the same numbers into the list



            wall.Width = 6.6m;
            wall.Height = 3.1m;
            walls.Add(wall);  //adding a wall to the wall list
            wall = new Wall();



            wall.Width = 5.6m;
            wall.Height = 3.1m;
            walls.Add(wall);  //adding a wall to the wall list
            wall = new Wall();


            wall.Width = 5.6m;
            wall.Height = 3.1m;
            walls.Add(wall);  //adding a wall to the wall list




            // loop of prompt/input/validate for windows
            Window window = new Window();
            window.Height = 1.2m;
            window.Width = 1.5m;
            window.Manufacturer = "All Weather";
            window.NumberOfPanes = 3;
            windows.Add(window);


            // loop of prompt/input/validate for doors
            Door door = new Door();
            door.Width = .85m;
            door.Height = 2.0m;
            door.Material = "Wood";
            door.RightOrLeft = "R";
            doors.Add(door);

            //add a second door to the list
            door = new Door();
            door.Width = .85m;
            door.Height = 2.0m;
            door.Material = "Wood";
            door.RightOrLeft = "L";
            doors.Add(door);

            //add third door to the list 
            door = new Door();
            door.Width = .85m;
            door.Height = 2.0m;
            door.Material = "Wood";
            door.RightOrLeft = "R";
            doors.Add(door);


            //store all characteristics of Room 
            room.Name = "Master Bedroom";
            room.Walls = walls; //walls is a list inside room
            room.Doors = doors;
            room.Windows = windows;


            //Paint Can coverage: 27.87 square meters

            //How many cans of paint do I need to cover the walls?
            //Calculate the area of the walls
            decimal wallarea = 0.0m;

            //foreach Loop when we have a collection and we don't know how many we have in the collection (List)
            foreach(Wall item in room.Walls) //Item is a placeholder    //can also say wall item in walls (same thing)
            {
                wallarea += item.WallArea();
            }

            //Calculate the area of the doors
            decimal doorarea = 0.0m;

            for (int i = 0; i < room.Doors.Count; i++)
            {
                doorarea += room.Doors[i].DoorArea();
            }


            //Calculate the are of the windows
            decimal windowarea = 0.0m;
            foreach (var item in room.Windows) //Item is a placeholder    //can also say wall item in walls (same thing)
            {
                windowarea += item.WindowArea();
            }


            //Calculate new area of walls
            decimal netWallArea = wallarea - (doorarea + windowarea);


            //Calculate the number of required paint cans
            decimal cansOfPaint = netWallArea / 27.87m;


            //Output the results
            Console.WriteLine($"Wall area is: \t{wallarea:0.00}");
            Console.WriteLine($"Door area is: \t{doorarea:0.00}");
            Console.WriteLine($"Window area is: \t{windowarea:0.00}");
            Console.WriteLine($"Net Wall area is: \t{netWallArea:0.00}");
            Console.WriteLine($"Required number of paint cans is: \t{cansOfPaint:0.00}");
        }
    }
}
