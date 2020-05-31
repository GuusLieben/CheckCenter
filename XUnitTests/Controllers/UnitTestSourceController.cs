using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static XUnitTests.Controllers.UnitTestController;

namespace XUnitTests.Controllers {
    public class UnitTestSourceController {

        [Fact]
        public void InvalidSourceValuesShouldThrowException()
        {
            var controller = GetFunctionalSourceController("source");
            Assert.ThrowsAny<Exception>(() => controller.CreateSource(Source.Mock(CheckType.Mock(), State.Mock())));
        }

        [Fact]
        public void UpdateSourceShouldThrowException()
        {
            var controller = GetFunctionalSourceController("source");
            var source = Source.Mock(CheckType.Mock(), State.Mock());
            Assert.ThrowsAny<Exception>(() => controller.UpdateSource(source, source.Id));
        }

        [Fact]
        public void DeleteSourceShouldNotReturnTrue()
        {
            var controller = GetFunctionalSourceController("source");
            var source = Source.Mock(CheckType.Mock(), State.Mock());

            var result = controller.DeleteSource(source, source.Id);
            Assert.False(result == null, "result should not be null");
        }

    }
}