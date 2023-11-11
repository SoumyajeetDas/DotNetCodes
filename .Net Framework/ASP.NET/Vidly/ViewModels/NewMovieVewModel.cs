using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieVewModel
    {
        public IEnumerable<Genre> Genres { set; get; }
        public Movie Movie { set; get; }
    }
}