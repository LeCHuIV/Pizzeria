using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData.Modele
{
    public class Pizza
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }
        public string IMG { get; set; }
    }
}
