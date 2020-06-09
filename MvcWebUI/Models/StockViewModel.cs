using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class StockViewModel
    {
        public Stock stock{ get; set; }

        public List<SelectListItem> selectLists { get; set; }
    }
}
