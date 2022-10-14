using OA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}