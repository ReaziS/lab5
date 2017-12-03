using System;
using System.Collections.Generic;

namespace FactoryProduction.Models
{
    public partial class ProductTypes
    {
        public ProductTypes()
        {
            Products = new HashSet<Products>();
        }

        public int ProductTypesId { get; set; }
        public string ProductTypeName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
