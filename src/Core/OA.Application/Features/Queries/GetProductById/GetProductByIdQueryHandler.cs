using AutoMapper;
using MediatR;
using OA.Application.Interfaces.Repositories;
using OA.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdViewModel>>
    {
        private IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(request.Id);
            var dto = mapper.Map<GetProductByIdViewModel>(product);

            return new ServiceResponse<GetProductByIdViewModel>(dto);
        }
    }
}