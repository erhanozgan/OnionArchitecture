using OA.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewDto>> GetAllProducts();
        Task<ProductViewDto> GetProduct(Guid id);
        Task<Guid> InsertProduct(ProductCreateOrUpdateDto productDto);
        Task<bool> UpdateProduct(ProductCreateOrUpdateDto productDto);
        Task<bool> DeleteProduct(Guid id);
    }
}