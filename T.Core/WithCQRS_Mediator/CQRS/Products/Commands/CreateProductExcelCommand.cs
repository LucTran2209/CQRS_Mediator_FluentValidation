using MediatR;
using Microsoft.AspNetCore.Http;
using T.Core.WithCQRS_Mediator.CQRS.Products.Responses;

namespace T.Core.WithCQRS_Mediator.CQRS.Products.Commands
{
    public class CreateProductExcelCommand : IRequest<CreateProductExcelResponse>
    {
        public IFormFile? ExcelProducts { get; set; }
    }
}
