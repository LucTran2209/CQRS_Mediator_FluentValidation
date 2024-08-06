using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Core.WithoutCQRS_Mediator.Dtos.AuthenServiceDto
{
    internal class AuthenServiceOutputDto
    {
    }

    public class ExternalLoginByGoogleAccountAsyncOuputDto
    {
        public string AccessToken { get; set; } = string.Empty;
    }
}
