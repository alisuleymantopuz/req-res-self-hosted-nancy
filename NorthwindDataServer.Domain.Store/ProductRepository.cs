using NorthwindDataServer.Domain.Common;
using NorthwindDataServer.Orm.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindDataServer.Domain.Store
{
    public class ProductRepository : IProductRepository
    {
        public NorthwindDataServerCommonEntities NorthwindDataServerCommonEntities { get; private set; }

        public ProductRepository(NorthwindDataServerCommonEntities northwindDataServerCommonEntities)
        {
            NorthwindDataServerCommonEntities = northwindDataServerCommonEntities;
        }

        public Product Create(Product entity)
        {
            NorthwindDataServerCommonEntities.Products.Add(entity);
            NorthwindDataServerCommonEntities.SaveChanges();
            return entity;
        }

        public void Create(IList<Product> entities)
        {
            NorthwindDataServerCommonEntities.Products.AddRange(entities);
            NorthwindDataServerCommonEntities.SaveChanges();
        }

        public Product Update(Product entity)
        {
            NorthwindDataServerCommonEntities.Products.AddOrUpdate(entity);
            NorthwindDataServerCommonEntities.SaveChanges();
            return entity;
        }

        public Product FirstOrDefault(Expression<Func<Product, bool>> clause)
        {
            return NorthwindDataServerCommonEntities.Products.FirstOrDefault(clause);        
        }

        public IEnumerable<Product> Where(Expression<Func<Product, bool>> clause)
        {
            return NorthwindDataServerCommonEntities.Products.Where(clause);
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<Product, TResult>> selector)
        {
            return NorthwindDataServerCommonEntities.Products.Select(selector);        
        }

        public Product First()
        {
            return NorthwindDataServerCommonEntities.Products.First();
        }

        public IEnumerable<Product> All()
        {
            return NorthwindDataServerCommonEntities.Products.ToList();
        }
    }
}
