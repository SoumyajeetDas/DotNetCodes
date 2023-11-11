using ParkyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<NationalPark> NationalParks { set; get; }
        public IEnumerable<Trail> Trails { set; get; }
    }
}
