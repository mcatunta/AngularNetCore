using System;
using System.Collections.Generic;

namespace SalesDiego.Api.Entities
{
    public class Order
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public int IdStateOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public Client Client { get; set; }
        public StateOrder StateOrder { get; set; }
        public List<DetailOrder> DetailOrders { get; set; }
    }
}
