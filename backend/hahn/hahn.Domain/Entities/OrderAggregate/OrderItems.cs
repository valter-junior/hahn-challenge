using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities.OrderAggregate
{
    public class OrderItems
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
