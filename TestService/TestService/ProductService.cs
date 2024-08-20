using T.Core.WithoutCQRS_Mediator.Abstraction.ServiceInterfaces;
using T.Domain.Entities;

namespace TestService.TestService
{
    public class ProductService
    {
        private readonly IProductService _productService;

        public ProductService(IProductService productService)
        {
            _productService = productService;
        }

        [Fact]
        public async Task Test_InsertServiceAsync()
        {
            // Arrange
            var p = new Product()
            {
                ProductName = "Trana",
                Code = "1234",
                Description = "131asd",
                Price = 123,
            };

            //// Setup the mock to return true when InsertAsync is called with any Product    
            // Act
            var result = await _productService.InsertServiceAsync(p);

            // Assert
            Assert.NotNull(result);
            //_productService.Verify(service => service.InsertServiceAsync(It.IsAny<Product>()), Times.Once);

        }

    }
}
