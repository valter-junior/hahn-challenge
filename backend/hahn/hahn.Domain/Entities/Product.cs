using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hahn.Domain.Entities.OrderAggregate;

namespace hahn.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public string ManagerId { get; set; }
        public Manager? Manager { get; set; }
        public List<OrderItems>? OrdersItem { get; set; }
    }
}
