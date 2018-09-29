using System;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using Moq;
using GigHub.Persistence;
using GigHub.Tests.Extensions;

namespace GigHub.Tests.Controllers.API
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;

        public GigsControllerTests()
        {
            var mockUoW = new Mock<IUnitOfWork>);
            var _controller = new GigsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com");
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
