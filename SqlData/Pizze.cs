using SqlData.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public class Pizze : IPizze
    {
        private ISqlDataAccess Db { get; }
        public Pizze(ISqlDataAccess db)
        {
            Db = db;
        }

        public Task<List<Pizza>> GetPizzas()
        {

            string sql = "select * from pizze";
            return Db.LoadData<Pizza, dynamic>(sql, new { });
        }
        public Task DodajPizze(Pizza pizza)
        {
            string sql = @"insert into pizze (ID,Name, Price,Description,ImageUrl)
                        values(@ID,@Name, @Price,@Description,@ImageUrl);";
            return Db.SaveData(sql, pizza);
        }
    }
}
