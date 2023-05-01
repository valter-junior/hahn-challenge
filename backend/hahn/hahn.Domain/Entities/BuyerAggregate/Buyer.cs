using hahn.Domain.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace hahn.Domain.Entities.BuyerAggregate
{
    public class Buyer : ApplicationUser
    {
        public DateTime Created { get; set; }
        public List<Order>? Orders { get; set; }
        public List<BuyerAddress> BuyerAddresses { get; set; }

 
    }
}
