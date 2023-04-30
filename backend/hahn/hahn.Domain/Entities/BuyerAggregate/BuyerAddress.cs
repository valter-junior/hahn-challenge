using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hahn.Domain.Entities.OrderAggregate;

namespace hahn.Domain.Entities.BuyerAggregate
{
    public class BuyerAddress
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
