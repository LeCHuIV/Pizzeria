using Microsoft.AspNetCore.Routing;
using NuGet.ContentModel;
using SqlData.Modele;
using SqlData;
using NUnit.Framework;
using NSubstitute;

namespace Pizzeria
{
    public class PizzaTests
    {

        private PizzeSQL _service;
        private SqlDataAccess _db;

        [SetUp]
        public void Setup()
        {
            _db = Substitute.For<SqlDataAccess>();
            _service = new PizzeSQL(_db);
        }

        [Test]
        public async Task AddPizza_Should_Insert_Pizza_To_Db()
        {
            // Arrange
            Pizza pizza = new Pizza() { ID = 1, Name = "Pepperoni", Price = 15, Description = "Spicy pizza with pepperoni and mozzarella cheese", IMG = "http://example.com/pepperoni.jpg" };

            // Act
            await _service.AddPizza(pizza);

            // Assert
            _db.Received(1).SaveData(Arg.Any<string>(), pizza);
        }

        [Test]
        public async Task GetPizzas_Should_Return_All_Pizzas_From_Db()
        {
            // Arrange
            var pizzas = new List<Pizza>()
        {
            new Pizza() { ID = 1, Name = "Pepperoni", Price = 15, Description = "Spicy pizza with pepperoni and mozzarella cheese", IMG = "http://example.com/pepperoni.jpg" },
            new Pizza() { ID = 2, Name = "Margherita", Price = 12, Description = "Classic pizza with tomato sauce, mozzarella cheese and basil", IMG = "http://example.com/margherita.jpg" },
        };
            _db.LoadData<Pizza, dynamic>(Arg.Any<string>(), Arg.Any<dynamic>()).Returns(pizzas);

            // Act
            var result = await _service.GetPizzas();

            // Assert
            _db.Received(1).LoadData<Pizza, dynamic>(Arg.Any<string>(), Arg.Any<dynamic>());
            Assert.AreEqual(result, pizzas);
        }
    }
}
