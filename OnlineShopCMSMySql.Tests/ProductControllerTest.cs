using System;
using Xunit;

namespace OnlineShopCMSMySql.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void AddProducts()
        {
            // Arrange (przygotuj test)
            ProductController.getId();
            
            int expected = 29;

            // Act (wykonaj dzia≥anie)
            int actual = ProductController.getId();

            // Assert (potwierdü test)
            Assert.Equal(expected, actual);
        }
    }
}
