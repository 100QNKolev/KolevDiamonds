using KolevDiamonds.Core.Contracts;
using KolevDiamonds.Core.Extensions;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class ModelExtensionsTests
    {
        [Test]
        public void GetInformation_ReturnsCorrectInformation()
        {
            // Arrange
            var model = new MockProductModel { Name = "Test Product", Price = 50.99m };

            // Act
            string information = model.GetInformation();

            // Assert
            Assert.That(information, Is.EqualTo("Test-Product5099"));
        }

        [Test]
        public void GetInformation_ReplacesSpacesWithHyphens()
        {
            // Arrange
            var model = new MockProductModel { Name = "Product Name With Spaces", Price = 100 };

            // Act
            string information = model.GetInformation();

            // Assert
            Assert.That(information, Is.EqualTo("Product-Name-With-Spaces100"));
        }

        [Test]
        public void GetInformation_RemovesSpecialCharacters()
        {
            // Arrange
            var model = new MockProductModel { Name = "Product# With @Special$ Characters!", Price = 150.75m };

            // Act
            string information = model.GetInformation();

            // Assert
            Assert.That(information, Is.EqualTo("Product-With-Special-Characters15075"));
        }
    }

    public class MockProductModel : IProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
