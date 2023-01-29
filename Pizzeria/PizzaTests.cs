using NUnit.Framework;
using NSubstitute;
using SqlData.Modele;
using SqlData;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pizzeria
{
    [TestFixture]
    public class PizzeSQLTests
    {
        private PizzeSQL _pizzeSQL;
        private ISqlDataAccess _mockDb;
        private PizzeSQL _db;

        [SetUp]
        public void SetUp()
        {
            _mockDb = Substitute.For<ISqlDataAccess>();
            _pizzeSQL = new PizzeSQL(_mockDb);
        }

        [Test]
        public async Task GetPizzas_ReturnsListOfPizzas()
        {
            // Act
            List<PizzaSQL> pizze = await _db.GetPizzas();

            // Assert
            NUnit.Framework.Assert.True(pizze.Count > 1);
        }

        [Test]
        public async Task AddPizza_AddsPizzaToDb()
        {
            // Arrange
            var pizza = new PizzaSQL { ID = 1, Name = "Margherita", Price = 10.99m, Description = "Tomato sauce, mozzarella cheese and basil", ImageUrl = "https://example.com/margherita.jpg" };

            // Act
            await _pizzeSQL.AddPizza(pizza);

            // Assert
            await _mockDb.Received().SaveData(Arg.Any<string>(), pizza);
        }
    }

}
