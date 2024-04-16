using KolevDiamonds.Controllers;
using KolevDiamonds.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamondsUnitTests
{
    [TestFixture]
    public class CartControllerTests
    {
        private CartController _cartController;
        private Mock<IHttpContextAccessor> _httpContextAccessorMock;

        [SetUp]
        public void Setup()
        {
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _cartController = new CartController(_httpContextAccessorMock.Object);
        }

        [Test]
        public async Task AddToCart_AddsItemToCartAndRedirectsToIndex()
        {
            // Arrange
            var item = new ProductIndexServiceModel { Id = 3, Name = "Product 3" };
            var cartItems = new List<ProductIndexServiceModel>();
            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(s => s.TryGetValue("CartItems", out It.Ref<byte[]>.IsAny)).Returns(true);
            sessionMock.Setup(s => s.Set("CartItems", It.IsAny<byte[]>())).Callback<string, byte[]>((key, value) =>
            {
                var json = Encoding.UTF8.GetString(value);
                cartItems = JsonConvert.DeserializeObject<List<ProductIndexServiceModel>>(json);
                cartItems.Add(item);
            });
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(c => c.Session).Returns(sessionMock.Object);
            _httpContextAccessorMock.SetupGet(a => a.HttpContext).Returns(httpContextMock.Object);

            // Act
            var result = await _cartController.AddToCart(item) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.ActionName, Is.EqualTo(nameof(CartController.Index)));
            Assert.IsTrue(cartItems.Contains(item));
        }

        [Test]
        public async Task Index_ReturnsViewWithCartItems()
        {
            // Arrange
            var cartItems = new List<ProductIndexServiceModel>
    {
        new ProductIndexServiceModel { Id = 1, Name = "Product 1" },
        new ProductIndexServiceModel { Id = 2, Name = "Product 2" }
    };
            var cartItemsJson = JsonConvert.SerializeObject(cartItems);

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(s => s.TryGetValue("CartItems", out It.Ref<byte[]>.IsAny))
                       .Returns((string key, out byte[] value) =>
                       {
                           value = Encoding.UTF8.GetBytes(cartItemsJson);
                           return true;
                       });

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(c => c.Session).Returns(sessionMock.Object);
            _httpContextAccessorMock.SetupGet(a => a.HttpContext).Returns(httpContextMock.Object);

            // Act
            var result = await _cartController.Index() as ViewResult;
            var model = result.Model as List<ProductIndexServiceModel>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(model.Count, Is.EqualTo(cartItems.Count));
            Assert.That(model[0].Id, Is.EqualTo(cartItems[0].Id));
            Assert.That(model[0].Name, Is.EqualTo(cartItems[0].Name));
            Assert.That(model[1].Id, Is.EqualTo(cartItems[1].Id));
            Assert.That(model[1].Name, Is.EqualTo(cartItems[1].Name));
        }


        [Test]
        public async Task RemoveFromCart_RemovesItemFromCartAndRedirectsToIndex()
        {
            // Arrange
            var cartItems = new List<ProductIndexServiceModel>
    {
        new ProductIndexServiceModel { Id = 1, Name = "Product 1" },
        new ProductIndexServiceModel { Id = 2, Name = "Product 2" }
    };
            var cartItemsJson = JsonConvert.SerializeObject(cartItems);
            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(s => s.TryGetValue("CartItems", out It.Ref<byte[]>.IsAny))
                       .Returns(true);
            sessionMock.Setup(s => s.Set("CartItems", It.IsAny<byte[]>()))
                       .Callback<string, byte[]>((key, value) =>
                       {
                           if (key == "CartItems")
                           {
                               var json = Encoding.UTF8.GetString(value);
                               cartItems = JsonConvert.DeserializeObject<List<ProductIndexServiceModel>>(json);
                           }
                       });
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(c => c.Session).Returns(sessionMock.Object);
            _httpContextAccessorMock.SetupGet(a => a.HttpContext).Returns(httpContextMock.Object);

            var itemToRemove = cartItems[0]; // Select an item to remove

            // Act
            var result = await _cartController.RemoveFromCart(itemToRemove.Id, itemToRemove.Name) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.ActionName, Is.EqualTo(nameof(CartController.Index)));

            // Verify item removal
            Assert.IsTrue(cartItems.Exists(item => item.Id == itemToRemove.Id && item.Name == itemToRemove.Name));
        }
    }
}
