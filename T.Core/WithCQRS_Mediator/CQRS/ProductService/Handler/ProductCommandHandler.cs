using AutoMapper;
using MediatR;
using T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery;
using T.Domain.Entities;
using T.Infastructure.Common;

namespace T.Core.WithCQRS_Mediator.CQRS.ProductService.Handler
{
    // Tại sao khi đỏi thành kiểu Generic thì lại lỗi
    public class ProductCommandHandler : IRequestHandler<ProductInsertCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = _mapper.Map<Product>(request);
                product.Id = new Guid();
                bool isStatus = _unitOfWork.ProductRepository.Insert(product);
                await _unitOfWork.SaveChangeAsync(cancellationToken);
                return isStatus;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
