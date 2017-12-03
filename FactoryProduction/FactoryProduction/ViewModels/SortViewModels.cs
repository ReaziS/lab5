using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryProduction.ViewModels
{
    public enum SortState
    {
        ProductNameAsc,
        ProductNameDesc,
        UnitOfProductAsc,
        UnitOfProductDesc,
        FactNameAsc,
        FactNameDesc,
        HeadAsc,
        HeadDesc,
        ProductTypeNameAsc,
        ProductTypeNameDesc,
        OutputPlanAsc,
        OutputPlanDesc,
        PriceAsc,
        PriceDesc,
        ImplePlanAsc,
        ImplePlanDesc,
        FactoryProductionidAsc
    };

    public class SortViewModels
    {

        public SortState ProductNameSort { get; set; }
        public SortState UnitOfProductSort { get; set; }
        public SortState FactNameSort { get; set; }
        public SortState HeadSort { get; set; }
        public SortState ProductTypeNameSort { get; set; }
        public SortState OutputPlanSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState ImplePlanSort { get; set; }
        public SortState Current { get; set; }

        public SortViewModels(SortState sortOrder)
        {
            ProductNameSort = sortOrder == SortState.ProductNameAsc ? SortState.ProductNameDesc : SortState.ProductNameAsc;
            UnitOfProductSort = sortOrder == SortState.UnitOfProductAsc ? SortState.UnitOfProductDesc : SortState.UnitOfProductAsc;
            FactNameSort = sortOrder == SortState.FactNameAsc ? SortState.FactNameDesc : SortState.FactNameAsc;
            HeadSort = sortOrder == SortState.HeadAsc ? SortState.HeadDesc : SortState.HeadAsc;
            ProductTypeNameSort = sortOrder == SortState.ProductTypeNameAsc ? SortState.ProductTypeNameDesc : SortState.ProductTypeNameAsc;
            OutputPlanSort = sortOrder == SortState.OutputPlanAsc ? SortState.OutputPlanDesc : SortState.OutputPlanAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            ImplePlanSort = sortOrder == SortState.ImplePlanAsc ? SortState.ImplePlanDesc : SortState.ImplePlanAsc;
            Current = sortOrder;
        }

    }
}