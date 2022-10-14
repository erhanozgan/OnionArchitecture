using AutoMapper;
using MediatR;
using OA.Application.Interfaces.Repositories;
using OA.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }

        public decimal Value { get; set; }

        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private IProductRepository productRepository;
            private readonly IMapper mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Domain.Entities.Product>(request);
                await productRepository.InsertAsync(product);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}