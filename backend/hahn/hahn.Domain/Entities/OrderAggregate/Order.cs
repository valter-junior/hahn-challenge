using hahn.Domain.Entities.BuyerAggregate;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities.OrderAggregate
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public float Price { get; set; }
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public Guid BuyerAddressId { get; set; }
        public BuyerAddress BuyerAddress { get; set; }
        public List<OrderItems> Items { get; set; }

    }
}
