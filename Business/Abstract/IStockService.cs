using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStockService
    {
        void Add(Stock stock);
        void Update(Stock stock);
        void Delete(Stock stock);
        Stock GetByStockId(int stockId);
        IList<Stock> GetAllWithEagerLoading();
        IList<Stock> GetAllByStockCode(int stockCode);
    }
}
