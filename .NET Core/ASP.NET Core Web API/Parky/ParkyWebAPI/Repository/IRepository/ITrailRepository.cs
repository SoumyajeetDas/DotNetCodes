using ParkyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Repository.IRepository
{
    public interface ITrailRepository
    {
        bool CreateTrail(Trail trail);
        bool DeleteTrail(Trail trail);
        Trail GetTrail(int nationalparkId);
        ICollection<Trail> GetTrails();
        ICollection<Trail> GetTrailsNationalPark(int npid);
        bool Save();
        bool TrailExists(int id);
        bool TrailExists(string name);
        bool UpdateTrail(Trail trail);
    }
    
}
