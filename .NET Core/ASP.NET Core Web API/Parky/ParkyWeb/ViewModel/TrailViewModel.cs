using ParkyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.ViewModel
{
    public class TrailViewModel
    {
        public Trail Trail { set; get; }
        public IEnumerable<NationalPark> NationalParks { set; get; }
    }
}
