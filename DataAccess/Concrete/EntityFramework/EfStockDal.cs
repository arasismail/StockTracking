using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStockDal :  IStockDal
    {
        public void Add(Stock entity)
        {
            using (var context = new StockTrackingContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Stock entity)
        {
            using (var context = new StockTrackingContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Stock Get(Expression<Func<Stock, bool>> filter)
        {
            using (var context = new StockTrackingContext())
            {
                return context.Set<Stock>().SingleOrDefault(filter);
            }
        }


        public IList<Stock> GetList(Expression<Func<Stock, bool>> filter = null)
        {
            using (var context = new StockTrackingContext())
            {
                return filter == null
                    ? context.Set<Stock>().ToList()
                    : context.Set<Stock>().Where(filter).ToList();
            }
        }
        public IList<Stock> GetAllWithEagerLoading()
        {
            using (var context = new StockTrackingContext())
            {
                return context.Stocks.Include(i => i.warehouse).ToList();
            }
        }

        public void Update(Stock entity)
        {
            using (var context = new StockTrackingContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }

}
//public class EfStockDal : EfEntityRepositoryBase<Stock, StockTrackingContext>, IStockDal