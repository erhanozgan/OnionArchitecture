using MediatR;
using Microsoft.AspNetCore.Mvc;
using OA.Application.Features.Commands.CreateProduct;
using OA.Application.Features.Queries.GetAllProducts;
using OA.Application.Features.Queries.GetProductById;
using System;
using System.Threading.Tasks;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMediatRController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductMediatRController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}