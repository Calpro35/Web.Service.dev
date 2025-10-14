using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Service.Cap7.Controllers;
using Web.Service.Cap7.Requests;

namespace Web.Service.Cap7.Test
{
    public class UserControllerTest
    {
        private readonly UserController _userController;

        private readonly Mock<IMediator> _mockMediator;

        public UserControllerTest()
        {
            _mockMediator = new Mock<IMediator>();
            _userController = new UserController(_mockMediator.Object);
        }

        [Fact]
        public void RegisterAsync_ReturnsIActionResult_WhenRegisterAsyncIsValid()
        {
            //Action
            var userRequest = GetUserRequest();
            var token = GetCancellationToken();
            var result = _userController.RegisterAsync(userRequest, token);

            //Assert
            var createdResult = Assert.IsType<Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(createdResult);

            Assert.NotNull(model);
        }

        [Fact]
        public void LoginAsync_ReturnsIActionResult_WhenRegisterAsyncIsValid()
        {
            //Action
            var userRequest = GetLoginUserRequest();
            var token = GetCancellationToken();
            var result = _userController.LoginAsync(userRequest, token);

            //Assert
            var okResult = Assert.IsType<Task<IActionResult>>(result);
            var model = Assert.IsAssignableFrom<Task<IActionResult>>(okResult);

            Assert.NotNull(model);
        }

        private NewUserRequest GetUserRequest()
        {
            return new NewUserRequest(Name: "Agostinho", Email: "agostinhosilva@gmail.com", Password: "123456",
                        Confirmation: "true", Role: Models.Enums.UserRoles.User);
        }

        private LoginUserRequest GetLoginUserRequest()
        {
            return new LoginUserRequest(Email: "agostinhosilva@gmail.com", Password: "123456");
        }

        private CancellationToken GetCancellationToken()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            return token;
        }
    }
}