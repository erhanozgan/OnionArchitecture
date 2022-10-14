using AutoMapper;
using OA.Application.Dtos;
using OA.Application.Features.Commands.CreateProduct;
using OA.Application.Features.Queries.GetProductById;
using OA.Domain.Entities;

namespace OA.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<Product, ProductCreateOrUpdateDto>();
            CreateMap<ProductCreateOrUpdateDto, Product>()
                .ForMember(d => d.Price, s => s.ConvertUsing(new CurrencyFormatter()));

            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<Product, GetProductByIdViewModel>().ReverseMap();
        }
    }

    public class CurrencyFormatter : IValueConverter<string, decimal>
    {
        public decimal Convert(string source, ResolutionContext context)
            => System.Convert.ToDecimal(source.Replace(".", ","));
    }
}