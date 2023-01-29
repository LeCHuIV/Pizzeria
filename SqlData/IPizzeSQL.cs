using SqlData.Modele;

namespace SqlData
{
    public interface IPizzeSQL
    {
        Task AddPizza(PizzaSQL pizza);
        Task<List<PizzaSQL>> GetPizzas();
    }
}