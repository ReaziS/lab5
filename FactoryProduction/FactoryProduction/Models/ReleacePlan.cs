using System;
using System.Collections.Generic;

namespace FactoryProduction.Models
{
    public partial class ReleacePlan
    {
        public int ReleacePlanId { get; set; }
        public int? ProductId { get; set; }
        public int? OutputPlan { get; set; }
        public int? Price { get; set; }

        public Products Product { get; set; }
    }
}
