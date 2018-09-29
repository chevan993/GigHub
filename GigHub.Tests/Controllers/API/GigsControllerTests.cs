using System;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using Moq;
using GigHub.Persistence;
using System.Web.Http;

namespace GigHub.Tests.Controllers.API
{
    [TestClass]
    public class GigsControllerTests
    {
        public GigsControllerTests()
        {
            var identity = new GenericIdentity("user1@domain.com");
            identity.AddClaim(
                new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "user1@domain.com"));
            identity.AddClaim(
                new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));

            var principal = new GenericPrincipal(identity, null);
            var mockUoW = new Mock<IUnitOfWork>);
            var controller = new GigsController(mockUoW.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
