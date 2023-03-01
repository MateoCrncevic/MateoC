using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Town
    {
        public int IDGrad { get; set; }
        public string Naziv { get; set; }
        public int DrzavaID { get; set; }

        public Country Country { get; set; }

    }
}