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
        public MoviesStarsDropDown()
        {

        }



        //Constructor wird gerufen wenn ein neues object created wird
        public MoviesStarsDropDown(int valuefield, string displayfield)
        {
            valueField = valuefield;
            displayField = displayfield;
        }
    }


}