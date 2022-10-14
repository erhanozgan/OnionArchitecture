using Microsoft.EntityFrameworkCore;
using OA.Application.Interfaces.Repositories;
using OA.Domain.Common;
using OA.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<T> entities;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            var affected = await dbContext.SaveChangesAsync();
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            var affected = await dbContext.SaveChangesAsync();
            return affected > 0;
        }
    }
}