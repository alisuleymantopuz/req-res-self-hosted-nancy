using NorthwindDataServer.Orm.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindDataServer.Domain.Common
{
    public class ResponseCodeRepository : IResponseCodeRepository
    {
        public NorthwindDataServerCommonEntities NorthwindDataServerCommonEntities { get; private set; }

        public ResponseCodeRepository(NorthwindDataServerCommonEntities northwindDataServerCommonEntities)
        {
            NorthwindDataServerCommonEntities = northwindDataServerCommonEntities;
        }

        public ResponseCode Create(ResponseCode entity)
        {
            NorthwindDataServerCommonEntities.ResponseCodes.Add(entity);
            NorthwindDataServerCommonEntities.SaveChanges();
            return entity;
        }

        public void Create(IList<ResponseCode> entities)
        {
            NorthwindDataServerCommonEntities.ResponseCodes.AddRange(entities);
            NorthwindDataServerCommonEntities.SaveChanges();
        }

        public ResponseCode Update(ResponseCode entity)
        {
            NorthwindDataServerCommonEntities.ResponseCodes.AddOrUpdate(entity);
            NorthwindDataServerCommonEntities.SaveChanges();
            return entity;
        }

        public ResponseCode FirstOrDefault(Expression<Func<ResponseCode, bool>> clause)
        {
            return NorthwindDataServerCommonEntities.ResponseCodes.FirstOrDefault(clause);
        }

        public IEnumerable<ResponseCode> Where(Expression<Func<ResponseCode, bool>> clause)
        {
            return NorthwindDataServerCommonEntities.ResponseCodes.Where(clause);
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<ResponseCode, TResult>> selector)
        {
            return NorthwindDataServerCommonEntities.ResponseCodes.Select(selector);
        }

        public ResponseCode First()
        {
            return NorthwindDataServerCommonEntities.ResponseCodes.First();
        }

        public IEnumerable<ResponseCode> All()
        {
            return NorthwindDataServerCommonEntities.ResponseCodes.ToList();
        }

        public Language LanguageGetByCode(string code)
        {
            return this.NorthwindDataServerCommonEntities.Languages.FirstOrDefault(x => x.Code == code);
        }
    }
}
