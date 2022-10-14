using AutoMapper;
using MediatR;
using OA.Application.Dtos;
using OA.Application.Interfaces.Repositories;
using OA.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAll();

                var viewModel = _mapper.Map<List<ProductViewDto>>(products);

                return new ServiceResponse<List<ProductViewDto>>(viewModel);
            }
        }
    }
}