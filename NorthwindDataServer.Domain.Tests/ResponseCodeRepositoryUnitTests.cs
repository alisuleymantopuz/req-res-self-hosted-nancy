using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindDataServer.Domain.Common;
using System.Linq;

namespace NorthwindDataServer.Domain.Tests
{
    [TestClass]
    public class ResponseCodeRepositoryUnitTests
    {
        [TestMethod]
        public void Response_Shoul_Be_Listed_Return_Success()
        {
            var container = Bootstrapper.Initialize();

            var responseCodeRepository = container.Resolve<IResponseCodeRepository>();

            var responseCodes = responseCodeRepository.All();

            responseCodes.Should().NotBeNull();

            responseCodes.Count().Should().BeGreaterThan(0);
        }
    }
}
