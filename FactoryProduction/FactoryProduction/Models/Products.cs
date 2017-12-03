using System;
using System.Collections.Generic;

namespace FactoryProduction.Models
{
    public partial class Products
    {
        public Products()
        {
            PlanOfImplement = new HashSet<PlanOfImplement>();
            ReleacePlan = new HashSet<ReleacePlan>();
        }

        public int ProductsId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? FactoryId { get; set; }
        public string ProductName { get; set; }
        public string UnitOfProduct { get; set; }

        public Factories Factory { get; set; }
        public ProductTypes ProductType { get; set; }
        public ICollection<PlanOfImplement> PlanOfImplement { get; set; }
        public ICollection<ReleacePlan> ReleacePlan { get; set; }
    }
}
