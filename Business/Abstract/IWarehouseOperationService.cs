using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWarehouseOperationService
    {
        void Add(WarehouseOperation warehouseOperation);
        IList<WarehouseOperation> GetAll();
    }
}
