namespace Pizzeria.Shared
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }
        public string Img { get; set; }
        public static Pizza FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            Pizza pizza = new Pizza();
            pizza.ID = Convert.ToInt16(values[0]);
            pizza.Nazwa = Convert.ToString(values[1]);
            pizza.Cena = Convert.ToDecimal(values[2]);
            pizza.Opis = Convert.ToString(values[3]);
            pizza.Img = Convert.ToString(values[4]);
            return pizza;
        }
    }
}
