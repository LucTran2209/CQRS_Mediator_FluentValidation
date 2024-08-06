using AutoMapper;
using T.Core.WithoutCQRS_Mediator.Abstraction;
using T.Core.WithoutCQRS_Mediator.Abstraction.ServiceInterfaces;
using T.Core.WithoutCQRS_Mediator.Common.Constants;
using T.Core.WithoutCQRS_Mediator.Common.Result;
using T.Domain.Abstractions;
using T.Domain.Entities;
using T.Infastructure.Common;
using T.Persistence.RepositoryInterface;

namespace T.Core.WithoutCQRS_Mediator.Services
{
    public class ProductService : BaseService, IProductService
    {


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper
                             ) : base(unitOfWork, mapper)
        {

        }

        public Task<ServiceResult> DeleteServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> FindByIdServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> InsertServiceAsync(Product entity)
        {
            try
            {
                entity.Id = new Guid();
                _unitOfWork.ProductRepository.Insert(entity);
                await _unitOfWork.SaveChangeAsync(CancellationToken.None);

                return new ServiceResult
                {
                    StatusCode = HttpCodeConstant.Success,
                    Data = null,
                    DevMsg = "Insert Success",
                    UserMsg = "Thanh Cong"
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ServiceResult> UpdateServiceAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
