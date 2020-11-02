using System.Collections.Generic;

namespace SalesDiego.Api.Entities
{
    public class StateOrder
    {
        public int IdStateOrder { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
