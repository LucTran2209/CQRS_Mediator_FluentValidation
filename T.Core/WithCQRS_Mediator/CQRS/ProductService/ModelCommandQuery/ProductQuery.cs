using MediatR;
using T.Domain.Entities;

namespace T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery
{
    public class ProductFindByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }


}