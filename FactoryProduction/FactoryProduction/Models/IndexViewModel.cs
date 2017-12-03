using FactoryProduction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryProduction.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Factories> Factories { get; set; }
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<ProductTypes> ProductTypes { get; set; }
        public IEnumerable<ReleacePlan> ReleacePlan { get; set; }
        public IEnumerable<PlanOfImplement> PlanOfImplement { get; set; }
        public PageViewModel PageViewModel { get; set; }


        public SortViewModels SortViewModels { get; set; }
        public FilterViewModels FilterViewModels { get; set; }


    }
}