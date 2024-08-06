using System.Runtime.CompilerServices;
using T.Core.WithoutCQRS_Mediator.Dtos.SendMailServiceDto;

namespace T.Core.WithoutCQRS_Mediator.Abstraction.ServiceInterfaces
{
    public interface ISendMailService
    {
        /// <summary>
        /// SendMailWelcomAsync
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<bool> SendMailWelcomAsync(SendMailWelcomAsyncInputDto inputDto);
    }
}
