using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naidis_IKTpv25
{
    public class Osa3_funktsioonid
    {
        public static Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double summa = arvud.Sum();
            double keskmine = arvud.Average();
            double korrutis = 1;
            foreach (double arv in arvud)
            {
                korrutis *= arv;
            }
            return Tuple.Create(summa, keskmine, korrutis);
        }
        public static (double summa, double keskmine, double korrutis) AnalüüsiArve1(double[] arvud)
        {
            double summa = arvud.Sum();
            double keskmine = arvud.Average();
            double korrutis = 1;
            foreach (double arv in arvud)
            {
                korrutis *= arv;
            }
            return (summa, keskmine, korrutis);
        }
        public static Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
        {
            int summa=inimesed.Sum(i=>i.Vanus);
            double keskmine_vanus = inimesed.Average(i => i.Vanus);
            Inimene vanim = inimesed.OrderByDescending(i => i.Vanus).First();
            Inimene noorim = inimesed.OrderBy(i => i.Vanus).First();
            return Tuple.Create(summa, keskmine_vanus, noorim, vanim);
        }
    }
    
}
