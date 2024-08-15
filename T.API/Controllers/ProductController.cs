using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using T.Core.WithCQRS_Mediator.CQRS.Products.Commands;
using T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery;

namespace T.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<ProductInsertCommand> _validator;
        public ProductController(IMediator mediator, IValidator<ProductInsertCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                ProductFindByIdQuery query = new ProductFindByIdQuery()
                {
                    Id = id
                };

                var output = await _mediator.Send(query);
                if (output != null)
                {
                    return Ok(output);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody]ProductInsertCommand command)
        {
            try
            {
                ValidationResult check = await _validator.ValidateAsync(command);

                if (!check.IsValid)
                {
                    var Errors = check.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                    return BadRequest(Errors);
                }

                var isSussess = await _mediator.Send(command);
                if (isSussess)
                {
                    return Ok("Thanh Cong");
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("ExcelFile")]
        public async Task<IActionResult> InsertProductByExcelFile([FromForm] CreateProductExcelCommand command)
        {
            try
            {       
                var isSussess = await _mediator.Send(command);
                
                return Ok(isSussess);

            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }


        // Test
        [HttpPost("Search")]
        public async Task<IActionResult> TestFluentValidator(Person command)
        {
            try
            {
                PersonValidator valid = new PersonValidator();
                ValidationResult check = await valid.ValidateAsync(command);

                if (!check.IsValid)
                {
                    var Errors = check.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                    return BadRequest(Errors);
                }

                return Ok("Ko Sao");

            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        // Class Test
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }    
        }
        // Validator test
        public class PersonValidator : AbstractValidator<Person>
        {
            public PersonValidator()
            {
                RuleFor(person => person.Name)
                    .NotEmpty().WithMessage("Name must not be empty")
                    .NotNull().WithMessage("Name must not be null");

                RuleFor(person => person.Age)
                    .InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120");

                RuleFor(person => person.Email)
                    .NotEmpty().WithMessage("Email must not be empty")
                    .EmailAddress().WithMessage("Email must be a valid email address");
            }
        }

    }
}
