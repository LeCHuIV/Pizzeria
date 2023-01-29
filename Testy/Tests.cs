using NUnit.Framework;
using NSubstitute;
using SqlData.Modele;
using SqlData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Testy
{
    public class PizzaTests
    {
        [Test]
        public void TestWeryfikacjP1()
        {
            Assert.True(1 == 1);
        }

        private PizzeSQL _service;
        private ISqlDataAccess _db;

        [SetUp]
        public void Setup()
        {
            _db = Substitute.For<ISqlDataAccess>();
            _service = new PizzeSQL(_db);
        }
        [Test]
        public async Task GetPizzas_Should_Return_All_Pizzas_From_Db()
        {
            // Arrange
            var pizzas = new List<PizzaSQL>()
            {
                new PizzaSQL() { ID = 1, Name = "Pepperoni", Price = 15, Description = "Spicy pizza with pepperoni and mozzarella cheese", IMG = "http://example.com/pepperoni.jpg" },
                new PizzaSQL() { ID = 2, Name = "Margherita", Price = 12, Description = "Classic pizza with tomato sauce, mozzarella cheese and basil", IMG = "http://example.com/margherita.jpg" },
            };
            _db.LoadData<PizzaSQL, dynamic>(Arg.Any<string>(), Arg.Any<dynamic>()).Returns(pizzas);

            // Act
            var result = await _service.GetPizzas();

            // Assert
            _db.Received(1).LoadData<PizzaSQL, dynamic>(Arg.Any<string>(), Arg.Any<dynamic>());
            Assert.AreEqual(result, pizzas);
        }

        [Test]
        public async Task AddPizza_Should_Insert_Pizza_To_Db()
        {
            // Arrange
            PizzaSQL pizza = new PizzaSQL() { ID = 1, Name = "Pepperoni", Price = 15, Description = "Spicy pizza with pepperoni and mozzarella cheese", IMG = "http://example.com/pepperoni.jpg" };

            // Act
            await _service.AddPizza(pizza);

            // Assert
            _db.Received(1).SaveData(Arg.Any<string>(), pizza);
        }
    }
}
