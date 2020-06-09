using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWarehouseService
    {
        void Add(Warehouse warehouse);
        Warehouse GetByWarehouseCode(int warehouseCode);
        IList<Warehouse> GetAll();
    }
}
