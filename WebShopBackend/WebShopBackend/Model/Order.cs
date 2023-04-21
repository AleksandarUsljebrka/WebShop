using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopBackend.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public User Costumer{ get; set; }
        public string OrderAddress { get; set; }
        public string Comment { get; set; }
        public List<ItemOrder> Items { get; set; }
    }
}
