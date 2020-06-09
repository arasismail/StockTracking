using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StockManager:IStockService
    {
        internal IStockDal _stockDal;
        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public void Add(Stock stock)
        {
            _stockDal.Add(stock);
            
        }

        public void Delete(Stock stock)
        {
            _stockDal.Delete(stock);
        }
        /// <summary>
        /// Verilen stok koduna göre filtrelenmiş stok listesi oluşturmaktadır.
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public IList<Stock> GetAllByStockCode(int stockCode)
        {
            return _stockDal.GetList(x=>x.StockCode==stockCode);
        }
        /// <summary>
        /// Elde edilecek stok listesinde eager loading yöntemi ile depolistesindeki verilere ulaşılmaktadır.
        /// </summary>
        /// <returns></returns>
        public IList<Stock> GetAllWithEagerLoading()
        {
            return _stockDal.GetAllWithEagerLoading();
        }

        public Stock GetByStockId(int stockId)
        {
            return _stockDal.Get(u=>u.StockId==stockId);
        }

        public void Update(Stock stock)
        {
            _stockDal.Update(stock);
        }
    }
}
