using MediatR;
using OA.Application.Wrappers;
using System;

namespace OA.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<GetProductByIdViewModel>>
    {
        public Guid Id { get; set; }
    }
}