using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopBackend.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public byte[] ItemImg { get; set; }
        public int SalesmanId { get; set; }
        public Salesman Salesman{ get; set; }
    }
}
