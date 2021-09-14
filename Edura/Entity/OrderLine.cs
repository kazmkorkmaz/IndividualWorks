using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Entity
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int OrderId { get; set; }
        virtual public Order Order { get; set; }
        public int ProductID { get; set; }
        virtual public Product Product { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
