using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Stock:IEntity
    {
        public int StockId { get; set; }
        public int StockCode { get; set; }
        public string StockName { get; set; }
        public int Kdv { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        [ForeignKey("warehouse")]
        public int WarehouseCode { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public virtual Warehouse warehouse { get; set; }

    }
}
