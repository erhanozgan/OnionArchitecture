using OA.Application.Interfaces.Repositories;
using OA.Domain.Entities;
using OA.Persistence.Context;

namespace OA.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}