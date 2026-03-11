using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Menuu
    {
        public string Nimetus { get; set; }
        public List<string> Koostisosad { get; set; }
        public double Hind { get; set; }

        // Konstruktor: aitab uut objekti luua ühe koodireaga
        public Menuu(string nimetus, List<string> kostisosad, double hind)
        {
            Nimetus = nimetus;
            Koostisosad = kostisosad;
            Hind = hind;
        }
        // Lisame mugavuse mõttes meetodi, mis teeb objektist otse failisõbraliku tekstirea
        public string VormindaFailiJaoks()
        {
            // Tulemus: "Pitsa;juust, tomat, vorst;8.50"
            string ainedKoos = string.Join(", ", Koostisosad);
            return $"{Nimetus};{ainedKoos};{Hind.ToString("F2").Replace(',', '.')}";
        }
    }
}
