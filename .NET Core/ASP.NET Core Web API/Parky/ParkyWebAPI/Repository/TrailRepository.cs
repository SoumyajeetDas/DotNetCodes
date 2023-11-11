using Microsoft.EntityFrameworkCore;
using ParkyWebAPI.Data;
using ParkyWebAPI.Models;
using ParkyWebAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Repository
{
    

    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext context;

        public TrailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateTrail(Trail trail)
        {
            context.trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            context.trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return context.trails.Include(obj => obj.NationalPark).FirstOrDefault(x => x.Id == trailId);
        }

        public ICollection<Trail> GetTrails()
        {
            return context.trails.Include(obj => obj.NationalPark).OrderBy(x => x.Name).ToList();
        }

        public bool TrailExists(int id)
        {
            bool value = context.trails.Any(x => x.Id == id);
            return value;
        }

        public bool TrailExists(string name)
        {
            bool value = context.trails.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool UpdateTrail(Trail trail)
        {
            context.trails.Update(trail);
            return Save();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0 ? true : false;
        }

        public ICollection<Trail> GetTrailsNationalPark(int npid)
        {
            return context.trails.Include(obj => obj.NationalPark).Where(obj => obj.NationalParkId == npid).ToList();
        }
    }
}
