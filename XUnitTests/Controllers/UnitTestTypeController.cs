using Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static XUnitTests.Controllers.UnitTestController;

namespace XUnitTests.Controllers {
    public class UnitTestTypeController {

        [Fact]
        public void InvalidCheckTypeShouldReturnUnsupportedMedia() {
            var controller = GetFunctionalTypeController("post1");
            var result = controller.CreateType(CheckType.Empty());
            Assert.IsType<UnsupportedMediaTypeResult>(result);
        }


    }
}