using KingHotel.Application.Commands.User;
using KingHotel.Domain.Entity;
using KingHotel.Domain.IRepository;
using KingHotel.Domain.IService.Auth;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace KingHotel.Tests.Application.Commands
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task CreateUser_Executed_ReturnUserId()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand
            {
                Name = "Esveraldo",
                Email = "esveraldo@email.com",
                Password = "Testando@@1",
                Role = "operator",
                Number  = "217",
                Street = "Boiaca",
                City = "Rio de Janeiro",
                ZipCode = "21331-600",
                Document = 0
            };

            
            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object, authService.Object);
            //Act

            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            Assert.NotNull(id);
            userRepository.Verify(u => u.Create(It.IsAny<User>()), Times.Once);
        }
    }
}
