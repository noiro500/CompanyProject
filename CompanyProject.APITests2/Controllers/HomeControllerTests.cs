using CompanyProject.API.Controllers;
using CompanyProject.API.Infrastructure.RefitInterfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CompanyProject.APITests2.Controllers
{
    public class HomeControllerTests
    {
        private readonly IContentServiceContent _contentServiceContent;

        public HomeControllerTests(IContentServiceContent contentService)
        {
            _contentServiceContent = contentService;
        }
        [Fact()]
        public void IndexTest()
        {
            var controller = new HomeController(_contentServiceContent);
            controller.RouteData.Values.Add("action", "Index");

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.Equal("index", controller.ViewBag.pageNameForCard);
            Assert.IsAssignableFrom<Task<IActionResult>>(viewResult.Model);
        }
    }
}