using System;
using System.Collections.Generic;

namespace FactoryProduction.Models
{
    public partial class Factories
    {
        public Factories()
        {
            Products = new HashSet<Products>();
        }
       
        public int FactoriesId { get; set; }
        public string FactName { get; set; }
        public string Head { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
