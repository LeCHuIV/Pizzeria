using SqlData.Modele;

namespace SqlData
{
    public interface IPizze
    {
        Task DodajPizze(Pizza pizza);
        Task<List<Pizza>> GetPizzas();
    }
}