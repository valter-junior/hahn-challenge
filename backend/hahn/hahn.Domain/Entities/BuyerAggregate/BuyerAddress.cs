using hahn.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities.BuyerAggregate
{
    public class BuyerAddress
    {
        public Guid Id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
