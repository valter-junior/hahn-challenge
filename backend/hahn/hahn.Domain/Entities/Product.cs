using hahn.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
        public List<OrderItems>? Orders { get; set; }
    }
}
