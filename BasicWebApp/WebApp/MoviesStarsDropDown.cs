using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class MoviesStarsDropDown
    {


        public int valueField { get; set; }

        public string displayField { get; set; }


        //Constructor (wenn user nix eingibt dann wird dieser Constructor gerufen und macht nix heisst also der setzt valueField und displayField packt der nicht an)
        public MoviesStarsDropDown() //beide Constructor haben den selben namen wie die class name
        {

        }



        //Constructor wird gerufen wenn ein neues object created wird
        public MoviesStarsDropDown(int valuefield, string displayfield) //beide Constructor haben den selben namen wie die class name
        {
            valueField = valuefield;
            displayField = displayfield;
        }
    }


}