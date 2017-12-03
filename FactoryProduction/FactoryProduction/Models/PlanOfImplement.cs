using System;
using System.Collections.Generic;

namespace FactoryProduction.Models
{
    public partial class PlanOfImplement
    {
        public int PlanOfImplementId { get; set; }
        public int? ProductId { get; set; }
        public int? ImplePlan { get; set; }
        public int? Price { get; set; }

        public Products Product { get; set; }
    }
}
