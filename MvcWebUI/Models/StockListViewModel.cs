using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class StockListViewModel
    {
        public IList<Stock> stocks { get; set; }
    }
}
