using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Entity
{
    public class ProductAttirubute
    {
        public int ProductAttirubuteId { get; set; }
        public string AttirubuteName { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
