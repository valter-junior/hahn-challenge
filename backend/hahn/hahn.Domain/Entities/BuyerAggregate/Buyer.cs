using hahn.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities.BuyerAggregate
{
    public class Buyer : ApplicationUser
    {
        public DateTime Created { get; set; }
        public List<Order>? Orders { get; set; }
        public List<BuyerAddress>? BuyerAddresses { get; set; }
    }
}
