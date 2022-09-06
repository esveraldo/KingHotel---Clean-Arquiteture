using KingHotel.Domain.Entity;
using KingHotel.Domain.VOs;
using Xunit;

namespace KingHotel.Tests.Domain.Entities
{
    public class UserTest
    {
        [Fact]
        public void Can_create_user_with_Test()
        {
            var address = new Address("127", "Boiaca", "Rio de Janeiro", "21331-600");
            var user = new User("Esveraldo", "esveraldo@email.com", "Testando@@1", "operator", address, 0);

            user.UpdateUser("Esveraldo", "esveraldo@teste.com", "Testando@@1", "operator", "127", "Boiaca", "Rio de Janeiro", "21331-600", 0, 0);
            user.UpdatedAtMethod();

            Assert.NotNull(user);
            Assert.Equal((int)user.Document, 0);
            Assert.Equal(user.Email, "esveraldo@teste.com");
            Assert.NotEqual(user.Email, "esveraldo@email.com");
        }
    }
}
