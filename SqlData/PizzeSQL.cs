using SqlData.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public class PizzeSQL : IPizzeSQL
    {
        private ISqlDataAccess Db { get; }
        public PizzeSQL(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<List<PizzaSQL>> GetPizzas()
        {

            string sql = "select * from pizze";
            return Db.LoadData<PizzaSQL, dynamic>(sql, new { });
        }
        public Task AddPizza(PizzaSQL pizza)
        {
            string sql = @"insert into pizze (ID,Name, Price,Description,ImageUrl)
                        values(@ID,@Name, @Price,@Description,@ImageUrl);";
            return Db.SaveData(sql, pizza);
        }
    }
}
