using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryProduction.ViewModels
{
    public class FilterViewModels
    {
        public FilterViewModels(string ProductName, string UnitOfProduct, string FactName, string Head, string ProductTypeName, int? ImplePlan, int? Price, int? OutputPlan)
        {
            SelectedProductName = ProductName;
            SelectedUnitOfProduct = UnitOfProduct;
            SelectedFactName = FactName;
            SelectedHead = Head;
            SelectedProductTypeName = ProductTypeName;
            SelectedImplePlan = ImplePlan;
            SelectedPrice = Price;
            SelectedOutputPlan = OutputPlan;
        }

        public string SelectedProductName { get; set; }
        public string SelectedUnitOfProduct { get; set; }
        public string SelectedFactName { get; set; }
        public string SelectedHead { get; set; }
        public string SelectedProductTypeName { get; set; }
        public int? SelectedImplePlan { get; set; }
        public int? SelectedPrice { get; set; }
        public int? SelectedOutputPlan { get; set; }
    }
}

