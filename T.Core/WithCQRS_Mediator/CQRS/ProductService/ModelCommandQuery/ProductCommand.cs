using FluentValidation;
using MediatR;

namespace T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery
{
    public class ProductInsertCommand : IRequest<bool>
    {
        public string? ProductName { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }

    public class ProductInsertCommandValidator : AbstractValidator<ProductInsertCommand>
    {
        public ProductInsertCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotNull()
                .MaximumLength(6);
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("Product Name is not Null")
                .NotEmpty().WithMessage("Product Name is not empty")
                .MaximumLength(50).WithMessage("Product Name have length less than 50");
            RuleFor(x => x.Description).NotNull().WithMessage("Description is not Null");
            RuleFor(x => x.Price).LessThan(10).WithMessage("Price must be less than 10");
        }
    }

}