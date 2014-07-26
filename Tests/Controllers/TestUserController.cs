namespace Tests.Controllers
{
    using Controller.ApiControllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository.Models;
    using System.Web.Http;
    using System.Web.Http.Results;

    [TestClass]
    public class TestUserController
    {
        private UserController _userController;

        [TestInitialize]
        public void SetUp()
        {
            _userController = new UserController();
        }

        [TestMethod]
        public void UserController_Get_ExistingUser_Success()
        {
            // Arrange
            string userName = "Softcadbury";
            int userId = 1;

            // Act
            IHttpActionResult result = _userController.Get(userId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));

            OkNegotiatedContentResult<User> negotiatedResult = result as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(negotiatedResult);
            Assert.AreEqual<string>(userName, negotiatedResult.Content.Name);
        }
    }
}