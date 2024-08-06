using AutoMapper;
using MediatR;
using T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery;
using T.Domain.Entities;
using T.Infastructure.Common;

namespace T.Core.WithCQRS_Mediator.CQRS.ProductService.Handler
{
    public class ProductQueryHandler : IRequestHandler<ProductFindByIdQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Product> Handle(ProductFindByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = await _unitOfWork.ProductRepository.FindByIdAsync(request.Id);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
