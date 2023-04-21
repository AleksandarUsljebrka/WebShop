using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopBackend.Model
{
    public class ItemOrder
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }
        public double Price{ get; set; }

    }
}
