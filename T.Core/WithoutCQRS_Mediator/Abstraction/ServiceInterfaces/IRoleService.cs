using T.Core.WithoutCQRS_Mediator.Common.Result;
using T.Core.WithoutCQRS_Mediator.Dtos.RoleServiceDto;
using T.Domain.Entities;

namespace T.Core.WithoutCQRS_Mediator.Abstraction.ServiceInterfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// InsertUpdateServiceAsync
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns>ServiceResult</returns>
		Task<ServiceResult> InsertUpdateServiceAsync(InsertUpdateServiceAsyncInputDto inputDto);

    }
}
