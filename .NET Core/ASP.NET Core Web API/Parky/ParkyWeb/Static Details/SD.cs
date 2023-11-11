using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Static_Details
{
    public static class SD
    {
        public static string APIBaseUrl = "http://localhost:32691/";
        public static string NationalParkAPIPath = APIBaseUrl+"api/NationalParks/";
        public static string TrailAPIPath = APIBaseUrl+"api/Trails/";
        public static string AccountAPIPath = APIBaseUrl+ "api/User/";

    }
}
