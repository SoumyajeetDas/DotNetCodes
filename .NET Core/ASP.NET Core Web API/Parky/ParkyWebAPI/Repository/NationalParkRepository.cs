using ParkyWebAPI.Data;
using ParkyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Repository.IRepository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext context;

        public NationalParkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            context.nationalparks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            context.nationalparks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalparkId)
        {
            return context.nationalparks.FirstOrDefault(x => x.Id == nationalparkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return context.nationalparks.OrderBy(x => x.Name).ToList();
        }

        public bool NationalParkExists(int id)
        {
            bool value = context.nationalparks.Any(x => x.Id == id);
            return value;
        }

        public bool NationalParkExists(string name)
        {
            bool value = context.nationalparks.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            context.nationalparks.Update(nationalPark);
            return Save();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0 ? true : false; //SaveChanges() returns no of entries written to the DB.
        }

        
    }
}
