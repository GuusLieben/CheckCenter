using System;
using CheckCenter.Repositories.EF;
using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests
{
    public class UnitTestTypeRepository
    {

        [Fact]
        public void CreateTypeTest_ReturnFalse()
        {
            var typeRepo = GetTypeRepo("Type_TestDb");
            var result = typeRepo.CreateType(CheckType.Empty());

            Assert.False(result == null, "ID shouldn't be null");
        }
    }
}
