using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class WarehouseOperationViewModel
    {
        public WarehouseOperation WarehouseOperation { get; set; }
        public List<SelectListItem> selectListItemsStock { get; set; }
        public List<SelectListItem> selectListItemsWarehouse { get; set; }
        public List<SelectListItem> selectListsOperationType { get; set; }
    }
}
