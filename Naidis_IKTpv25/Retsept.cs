using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Retsept
    {
        public string Nimi { get; set; }
        public List<string> Koostisosad { get; set; }

        public Retsept(string nimi, List<string> koostisosad)
        {
            Nimi = nimi;
            Koostisosad = koostisosad;
        }
    }
}
