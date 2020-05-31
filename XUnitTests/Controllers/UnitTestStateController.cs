using Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static XUnitTests.Controllers.UnitTestController;

namespace XUnitTests.Controllers
{
    public class UnitTestStateController
    {

        [Fact]
        public void InvalidStateShouldReturnUnsupportedMedia()
        {
            var controller = GetFunctionalStateController("post1");
            var result = controller.CreateState(State.Empty());
            Assert.IsType<UnsupportedMediaTypeResult>(result);
        }


    }
}