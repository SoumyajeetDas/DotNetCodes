using Braintree;
using Library_App.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Repository
{
    public class BraintreeRepository : IBraintreeRepository
    {
        private readonly IConfiguration config;

        public BraintreeRepository(IConfiguration config)
        {
            this.config = config;
        }
        public IBraintreeGateway CreateGateway()
        {
            var newGateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = config.GetValue<string>("BraintreeGateway:MerchantId"),
                PublicKey = config.GetValue<string>("BraintreeGateway:PublicKey"),
                PrivateKey = config.GetValue<string>("BraintreeGateway:PrivateKey")
            };
            return newGateway;
        }

        public IBraintreeGateway GetGateway()
        {
            return CreateGateway();
        }
    }
}
