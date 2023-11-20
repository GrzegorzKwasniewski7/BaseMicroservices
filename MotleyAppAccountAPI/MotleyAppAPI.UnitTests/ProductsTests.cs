using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MotleyAppAPI.UnitTests
{
    public class ProductsTests
    {
        [Fact]
        public async Task CreateProduct_ReturnsABadRequestStatus()
        {
            // Arrange
            //var mockRepo = new Mock<IBrainstormSessionRepository>();
            //mockRepo.Setup(repo => repo.ListAsync())
            //    .ReturnsAsync(GetTestSessions());
            //var controller = new HomeController(mockRepo.Object);

            //// Act
            //var result = await controller.Index();

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(2, model.Count());
        }        
    }
}