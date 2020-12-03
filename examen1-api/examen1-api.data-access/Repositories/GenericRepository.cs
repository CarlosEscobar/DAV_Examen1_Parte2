using examen1_api.data_access.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace examen1_api.data_access.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly Examen1DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(Examen1DbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}