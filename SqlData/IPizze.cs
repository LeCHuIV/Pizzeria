using SqlData.Modele;

namespace SqlData
{
    public interface IPizzeSQL
    {
        Task AddPizza(Pizza pizza);
        Task<List<Pizza>> GetPizzas();
    }
}