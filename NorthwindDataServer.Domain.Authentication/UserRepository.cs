using NorthwindDataServer.Orm.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindDataServer.Domain.Authentication
{
    public class UserRepository : IUserRepository
    {
        public NorthwindDataServerCommonEntities NorthwindDataServerCommonEntities { get; private set; }

        public UserRepository(NorthwindDataServerCommonEntities northwindDataServerCommonEntities)
        {
            NorthwindDataServerCommonEntities = northwindDataServerCommonEntities;
        }


        public User Create(User entity)
        {
            NorthwindDataServerCommonEntities.Users.Add(entity);
            NorthwindDataServerCommonEntities.SaveChanges();
            return entity;
        }

        public void Create(IList<User> entities)
        {
            NorthwindDataServerCommonEntities.Users.AddRange(entities);
            NorthwindDataServerCommonEntities.SaveChanges();
        }

        public User Update(User entity)
        {
            NorthwindDataServerCommonEntities.Users.AddOrUpdate(entity);
            NorthwindDataServerCommonEntities.SaveChanges();
            return entity;
        }

        public User FirstOrDefault(Expression<Func<User, bool>> clause)
        {
            return NorthwindDataServerCommonEntities.Users.FirstOrDefault(clause);
        }

        public IEnumerable<User> Where(Expression<Func<User, bool>> clause)
        {
            return NorthwindDataServerCommonEntities.Users.Where(clause);
        }

        public IEnumerable<TResult> Select<TResult>(Expression<Func<User, TResult>> selector)
        {
            return NorthwindDataServerCommonEntities.Users.Select(selector);
        }

        public User First()
        {
            return NorthwindDataServerCommonEntities.Users.First();
        }

        public IEnumerable<User> All()
        {
            return NorthwindDataServerCommonEntities.Users.ToList();
        }

        public User CheckUser(string username, string password)
        {
            return
                NorthwindDataServerCommonEntities.Users.FirstOrDefault(
                    x => x.UserName == username && x.Password == password);
        }
    }
}
