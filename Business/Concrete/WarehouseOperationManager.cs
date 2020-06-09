using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WarehouseOperationManager:IWarehouseOperationService
    {
        private IWarehouseOperationDal _warehouseOperationDal;
        public WarehouseOperationManager(IWarehouseOperationDal warehouseOperationDal)
        {
            _warehouseOperationDal = warehouseOperationDal;
        }

        public void Add(WarehouseOperation warehouseOperation)
        {
            _warehouseOperationDal.Add(warehouseOperation);
        }

        public IList<WarehouseOperation> GetAll()
        {
            return _warehouseOperationDal.GetList();
        }
    }
}
