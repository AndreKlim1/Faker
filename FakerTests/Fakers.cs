using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.DTOs;

namespace Tests
{
    public class Fakers
    {
        [Fact]
        public void Create_DTO_With_Public_Properties()
        {
            var faker = new Faker.Faker.Faker();
            var dto = faker.Create<WithPublicProperties>();

            Assert.NotNull(dto);
            Assert.NotEqual(default(int), dto.IntProperty);
            Assert.NotEqual(default(DateTime), dto.DateTimeProperty);
            Assert.NotNull(dto.StringProperty);
            Assert.NotNull(dto.IntList);
            Assert.NotNull(dto.StringList);
        }

        [Fact]
        public void Create_DTO_With_Private_Constructor()
        {
            var faker = new Faker.Faker.Faker();
            var dto = faker.Create<WithPrivateConstructor>();
            Assert.NotNull(dto);
            Assert.NotEqual(default(int), dto.IntProperty);
            Assert.NotEqual(default(string), dto.StringProperty);
            Assert.NotEqual(default(DateTime), dto.DateTimeProperty);
            Assert.NotNull(dto.IntList);
            Assert.NotNull(dto.StringList);
        }

        [Fact]
        public void Create_DTO_With_Multiple_Constructors()
        {
            var faker = new Faker.Faker.Faker();
            var dto = faker.Create<WithMultipleConstructors>();

            Assert.NotNull(dto);
            Assert.NotEqual(default(int), dto.IntProperty);
            Assert.NotEqual(default(string), dto.StringProperty);
            Assert.NotEqual(default(DateTime), dto.DateTimeProperty);
            Assert.NotNull(dto.IntList);
            Assert.NotNull(dto.StringList);
        }
    }
}
