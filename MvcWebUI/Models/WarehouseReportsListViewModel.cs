using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class WarehouseReportsListViewModel
    {
        public IList<WarehouseOperation> WarehouseOperations { get; set; }
        public IList<Stock> Stocks { get; set; }

    }
}
