using ClosedXML.Excel;
using MediatR;
using T.Core.WithCQRS_Mediator.CQRS.Products.Commands;
using T.Core.WithCQRS_Mediator.CQRS.Products.Responses;
using T.Domain.Entities;
using T.Persistence;

namespace T.Core.WithCQRS_Mediator.CQRS.Products
{
    public class CreateProductExcelCommandHandler : IRequestHandler<CreateProductExcelCommand, CreateProductExcelResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductExcelCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<CreateProductExcelResponse> Handle(CreateProductExcelCommand request, CancellationToken cancellationToken)
        {
            if (request.ExcelProducts == null || request.ExcelProducts.Length == 0)
            {

            }

            if (!request.ExcelProducts.FileName.EndsWith(".xlsx"))
            {

            }

            try
            {
                using (var stream = request.ExcelProducts.OpenReadStream())
                {
                    var workbook = new XLWorkbook(stream);
                    var worksheet = workbook.Worksheets.First();

                    // Assuming data starts from row 2 (skip header)
                    var products = new List<Product>();
                    for (var row = 1; row <= worksheet.LastRowUsed().RowNumber(); row++)
                    {
                        var product = new Product();
                        product.Code = worksheet.Cell(row, 1).Value.ToString();
                        product.ProductName = worksheet.Cell(row, 2).Value.ToString();
                        product.Description = worksheet.Cell(row, 3).Value.ToString();
                        product.Price = decimal.Parse(worksheet.Cell(row, 4).Value.ToString());

                        products.Add(product);
                    }

                    _context.Products.AddRange(products);
                    await _context.SaveChangesAsync();


                }
            }
            catch (Exception)
            {
                throw;
            }

            return new CreateProductExcelResponse()
            {
                Message = "luc"
            };
        }
    }
}
