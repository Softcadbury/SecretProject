namespace Tests.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Results;
    using Controller.ApiControllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository.Models;

    [TestClass]
    public class TestUserController
    {
        private UserController userController;

        [TestInitialize]
        public void SetUp()
        {
            userController = new UserController();
        }

        [TestMethod]
        public void UserController_Get_ExistingUser_Success()
        {
            // Arrange
            const string UserName = "Softcadbury";
            const int UserId = 1;

            // Act
            IHttpActionResult result = userController.Get(UserId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));

            var negotiatedResult = result as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(negotiatedResult);
            Assert.AreEqual(UserName, negotiatedResult.Content.UserName);
        }
    }
}