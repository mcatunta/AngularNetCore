using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalesDiego.Api.Repositories.Intefaces
{
    public interface IGenericRepository
    {
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Add<T>(T entidad) where T : class;
        void SaveChanges();
    }
}
