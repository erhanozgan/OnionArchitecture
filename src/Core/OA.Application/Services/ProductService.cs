using AutoMapper;
using OA.Application.Dtos;
using OA.Application.Interfaces;
using OA.Application.Interfaces.Repositories;
using OA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IMapper mapper, IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductViewDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<ProductViewDto>>(products);
        }

        public async Task<ProductViewDto> GetProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewDto>(product);
        }

        public async Task<Guid> InsertProduct(ProductCreateOrUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var inserted = await _productRepository.InsertAsync(product);
            return inserted.Id;
        }

        public async Task<bool> UpdateProduct(ProductCreateOrUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var updated = await _productRepository.UpdateAsync(product);
            return updated;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);
            var deleted = await _productRepository.DeleteAsync(product);
            return deleted;
        }
    }
}
