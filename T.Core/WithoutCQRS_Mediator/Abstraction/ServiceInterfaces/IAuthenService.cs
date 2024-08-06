using Google.Apis.Auth;
using T.Core.WithoutCQRS_Mediator.Common.Result;
using T.Core.WithoutCQRS_Mediator.Dtos.AuthenServiceDto;

namespace T.Core.WithoutCQRS_Mediator.Abstraction.ServiceInterfaces
{
    public interface IAuthenService
    {
        /// <summary>
        /// Register a new account
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ServiceResult> RegisterAsync(RegisterAsyncInputDto inputDto);

        /// <summary>
        /// Login by UserName and Password
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ServiceResult> LoginByUsernamePasswordAsync(LoginByUsernamePasswordAsyncInputDto inputDto);

        /// <summary>
        /// Using Google account to login
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ServiceResult> ExternalLoginByGoogleAccountAsync(ExternalLoginByGoogleAccountAsyncInputDto inputDto);
    }
}
