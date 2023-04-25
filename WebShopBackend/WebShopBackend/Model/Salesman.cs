using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopBackend.Model
{
    public enum Verification {PROCESSING, DECLINED, ACCEPTED}
    public class Salesman : User
    {
        public Verification Ver { get; set; }
        public List<Item> Items { get; set; }
    }
}
