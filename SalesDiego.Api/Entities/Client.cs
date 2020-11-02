using System.Collections.Generic;

namespace SalesDiego.Api.Entities
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; }
    }
}
