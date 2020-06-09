using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WarehouseOperation:IEntity
    {
        public int Id { get; set; }
        public int VoucherNumber { get; set; }
        public int WarehouseCode { get; set; }
        public int Quantity { get; set; }
        public bool OperationType { get; set; }  // True ise ürün giriş yapılmıştır. & False ise ürün çıkışı yapılmıştır. 
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int StockCode { get; set; }

    }
}
