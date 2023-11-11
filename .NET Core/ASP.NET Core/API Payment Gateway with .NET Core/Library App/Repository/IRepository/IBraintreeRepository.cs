using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Repository.IRepository
{
    public interface IBraintreeRepository
    {
        IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }
}
