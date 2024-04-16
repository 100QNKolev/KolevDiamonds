using KolevDiamonds.Data;
using KolevDiamonds.Infrastructure.Data.Common;
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Mock<ApplicationDbContext> _mockContext;
        private Repository _repository;

        [SetUp]
        public void SetUp()
        {
            // Mocking the DbContext
            _mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());

            // Creating the Repository with the mocked DbContext
            _repository = new Repository(_mockContext.Object);
        }

        [Test]
        public async Task All_Returns_All_Rings()
        {
            // Arrange
            var testData = new List<Ring> { new Ring(), new Ring() }.AsQueryable();
            var mockDbSet = testData.BuildMockDbSet();
            _mockContext.Setup(c => c.Set<Ring>()).Returns(mockDbSet.Object);

            // Act
            var result = await _repository.All<Ring>().ToListAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllReadOnly_Returns_All_Products_Without_Tracking()
        {
            // Arrange
            var testData = new List<Ring> { new Ring(), new Ring() }.AsQueryable();
            var mockDbSet = testData.BuildMockDbSet();
            _mockContext.Setup(c => c.Set<Ring>()).Returns(mockDbSet.Object);

            // Act
            var result = await _repository.AllReadOnly<Ring>().ToListAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task SaveChangesAsync_Saves_Changes()
        {
            // Arrange
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _repository.SaveChangesAsync();

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task AddAsync_Adds_Ring()
        {
            // Arrange
            var Ring = new Ring();
            var mockDbSet = new List<Ring>().AsQueryable().BuildMockDbSet();
            _mockContext.Setup(c => c.Set<Ring>()).Returns(mockDbSet.Object);

            // Act
            await _repository.AddAsync(Ring);

            // Assert
            mockDbSet.Verify(d => d.AddAsync(Ring, default), Times.Once);
        }
    }
}
