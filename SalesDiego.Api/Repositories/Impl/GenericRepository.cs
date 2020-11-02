using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using SalesDiego.Api.Context;
using SalesDiego.Api.Repositories.Intefaces;

namespace SalesDiego.Api.Repositories.Impl
{
    public class GenericRepository : IGenericRepository
    {
        private ContextDB _context;
        public GenericRepository(ContextDB context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Add<T>(T entidad) where T : class
        {
            _context.Set<T>().Add(entidad);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
