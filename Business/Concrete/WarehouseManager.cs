using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        private IWarehouseDal _warehouseDal;
        public WarehouseManager(IWarehouseDal warehouseDal)
        {
            _warehouseDal = warehouseDal;
        }
        public void Add(Warehouse warehouse)
        {
            _warehouseDal.Add(warehouse);
        }

        public IList<Warehouse> GetAll()
        {
            return _warehouseDal.GetList();
        }

        public Warehouse GetByWarehouseCode(int warehouseCode)
        {
            return _warehouseDal.Get(u=>u.WarehouseCode==warehouseCode);
        }
    }
}
