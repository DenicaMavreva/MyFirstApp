using CCA.Controllers;
using CCA.Models;
using CCA.Services;
using System.Threading.Tasks;
using Xunit;

namespace CCA.Tests
{
    public class CCATests
    {
        [Fact]
        public async Task<iactionResult> CoursesController()
        {
            //assert
            var controller = new CoursesController();

            //Act
            var result = await controller.Create();
        }
    }
}
