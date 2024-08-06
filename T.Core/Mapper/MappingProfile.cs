using AutoMapper;
using T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery;
using T.Core.WithoutCQRS_Mediator.Dtos.AuthenServiceDto;
using T.Core.WithoutCQRS_Mediator.Dtos.RoleServiceDto;
using T.Domain.Entities;

namespace T.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping RoleService
            CreateMap<InsertUpdateServiceAsyncInputDto, Role>();

            // Mapping AuthenService
            CreateMap<RegisterAsyncInputDto, User>();

            // Mapper ProdcutService
            CreateMap<ProductInsertCommand, Product>();

        }
    }
}
