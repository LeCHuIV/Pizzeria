namespace Pizzeria.Shared
{
    public class Metody
    {
        static string path = @"C:\Studia\Magisterka\Semestr 3\Czysty kod\Pizzeria2\Pizzeria\Pizzeria\Zamowienie.csv";
        public static Zamowienia DodanieDoZamowienia(Pizza pizza)
        {
            Zamowienia zamowienie = new Zamowienia();
            
            if (!File.Exists(path))
            {
                string createText = "Numer Zamówienia;Data złożenia zamówienia;Wartość";
                File.WriteAllText(path, createText);
            }
            String[] csv = File.ReadAllLines(path);
            zamowienie.Wartosc += pizza.Cena;
            zamowienie.Czas = DateTime.Now;
            csv.Append($"{zamowienie.Numer};{zamowienie.Czas};{zamowienie.Wartosc}");
            File.WriteAllLines(path, csv);

            return zamowienie;
        }

        public void ZapisZamowienia(Zamowienia zamowienie, String[] csv)
        {
            File.WriteAllLines(path, csv);
        }
    }
}
