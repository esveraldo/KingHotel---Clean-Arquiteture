using KingHotel.Application.Queries.Users;
using KingHotel.Domain.Entity;
using KingHotel.Domain.IRepository;
using KingHotel.Domain.VOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace KingHotel.Tests.Application.Queries
{
    public class GetAllUsersTest
    {
        [Fact]
        public async Task userViewModelExists_Return_UserViewModel()
        {
            //Arrange
            var address = new Address("127", "Boiaca", "Rio de Janeiro", "21331-600");
            var users = new List<User>
            {
                new User("Esveraldo", "esveraldo@email.com", "Testando@@1", "operator", address, 0)
            };

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetAll().Result).Returns(users);

            var getAllUsersQuery = new GetAllUsersQuery(); 
            var getAllUsersQueryCommandHandler = new GetAllUsersQueryHandler(userRepository.Object);
            //Act
            var userViewModel = await getAllUsersQueryCommandHandler.Handle(getAllUsersQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userViewModel);
            Assert.NotEmpty(userViewModel);
            Assert.Equal(users.Count, userViewModel.Count);

            userRepository.Verify(u => u.GetAll().Result, Times.Once);
        }
    }
}
