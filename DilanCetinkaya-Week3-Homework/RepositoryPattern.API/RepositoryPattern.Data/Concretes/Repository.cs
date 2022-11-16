using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Abstract;
using RepositoryPattern.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _context;
        private DbSet<T> _entity;
        public Repository(EmployeeDbContext context)
        {

            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {

            await _entity.AddAsync(entity);
            var result = _context.SaveChanges();
            return result > 0;

        }

        public bool Delete(T entity)
        {

            _entity.Remove(entity);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _entity.Where(filter).FirstOrDefaultAsync();
        }


        public bool Update(T entity)
        {
            _entity.Update(entity);
            var result = _context.SaveChanges();
            return result > 0;
        }
    }
}
