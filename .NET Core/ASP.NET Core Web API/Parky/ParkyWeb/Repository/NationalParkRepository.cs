using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkyWeb.Repository
{
    // if we only inherit INationalParkRepository then it will show error and will tell to implement all its functions
    // but after inheriting Repository the error is gone since Repository implements all the functions of INatinalRepository
    // so basicaly indirectly NationalParkRepository implements all the functions of INationalParkRepository since it 
    // inherits the implemented Repository

    public class NationalParkRepository : Repository<NationalPark>, INationalParkRepository
    {
        private readonly IHttpClientFactory clientFactory;
        public NationalParkRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            this.clientFactory = clientFactory;
        }
    }
}
